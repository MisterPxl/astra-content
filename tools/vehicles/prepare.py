#!/usr/bin/env python3
"""Assemble MotionTest into an isolated Astra Vehicles author/consumer project."""
import argparse
import hashlib
import json
from pathlib import Path
import re
import shutil
import subprocess
import uuid

HERE = Path(__file__).resolve().parent
REPO = HERE.parents[1]
PACK_ID = 'astra.vehicles'


def meta(path, relative):
    guid = uuid.uuid5(uuid.NAMESPACE_URL, PACK_ID + '/' + relative).hex
    Path(str(path) + '.meta').write_text('fileFormatVersion: 2\nguid: ' + guid + '\n' +
        ('folderAsset: yes\nDefaultImporter:\n  externalObjects: {}\n' if path.is_dir() else ''))
    return guid


def copy(source, target):
    target.parent.mkdir(parents=True, exist_ok=True)
    if source.is_dir():
        shutil.copytree(source, target)
    else:
        shutil.copy2(source, target)
    sidecar = Path(str(source) + '.meta')
    if sidecar.exists():
        shutil.copy2(sidecar, str(target) + '.meta')


def split_type(root, relative, name, marker):
    """Move a known Unity object type into a matching file; fail on source drift."""
    source = root / relative
    text = source.read_text()
    start = text.index(marker)
    declaration = text.index('class ' + name + ' ', start)
    brace = text.index('{', declaration)
    level, end = 1, brace + 1
    while level:
        level += (text[end] == '{') - (text[end] == '}')
        end += 1
    namespace = re.search(r'namespace ([\w.]+)', text).group(1)
    target = source.with_name(name + '.cs')
    if target.exists():
        raise ValueError('Split target already exists: ' + str(target))
    target.write_text('using System;\nusing UnityEngine;\n\nnamespace ' + namespace + '\n{\n' + text[start:end] + '\n}\n')
    source.write_text(text[:start] + text[end:])
    return meta(target, str(target.relative_to(root)))


def prepare(args):
    output, source, hub = args.output.resolve(), args.source.resolve(), args.hub.resolve()
    if args.mode == 'tests':
        receipt = json.loads((output / 'ProjectSettings/AstraContent/Receipts/astra.vehicles.json').read_text())
        if receipt['state'] != 'Imported':
            raise ValueError('Import must be verified before installing tests')
        test_root = output / 'Assets/VehiclesQualificationTests'
        test_root.mkdir()
        for kind in ['core', 'car', 'boat', 'plane']:
            copy(source / ('Packages/com.motion.vehicles.' + kind) / 'Tests', test_root / kind)
        copy(HERE / 'VehiclesPlayModeTests.cs', test_root / 'PlayMode/VehiclesPlayModeTests.cs')
        (test_root / 'PlayMode/Astra.Vehicles.PlayMode.Tests.asmdef').write_text(json.dumps({
            'name': 'Astra.Vehicles.PlayMode.Tests', 'references': [],
            'optionalUnityReferences': ['TestAssemblies'], 'defineConstraints': ['UNITY_INCLUDE_TESTS']}))
        return
    if output.exists():
        raise ValueError('Output must be a new directory: ' + str(output))
    for name in ['Assets', 'Packages', 'ProjectSettings']:
        (output / name).mkdir(parents=True)
    versions = json.loads((hub / 'Packages/manifest.json').read_text())['dependencies']
    names = ['com.unity.test-framework', 'com.unity.modules.jsonserialize', 'com.unity.modules.uielements',
             'com.unity.modules.imgui', 'com.unity.modules.imageconversion', 'com.unity.modules.physics',
             'com.unity.modules.audio']
    if args.mode != 'missing-prerequisites':
        names += ['com.unity.inputsystem', 'com.unity.render-pipelines.universal']
    (output / 'Packages/manifest.json').write_text(json.dumps({'dependencies': {n: versions[n] for n in names}}, indent=2))
    copy(hub / 'ProjectSettings/ProjectVersion.txt', output / 'ProjectSettings/ProjectVersion.txt')
    (output / 'ProjectSettings/ProjectSettings.asset').write_text(
        '%YAML 1.1\n%TAG !u! tag:unity3d.com,2011:\n--- !u!129 &1\nPlayerSettings:\n  serializedVersion: 28\n  activeInputHandler: ' +
        ('0' if args.mode == 'missing-prerequisites' else '1') + '\n')
    copy(hub / 'Assets/_Project/Editor/ContentHub', output / 'Assets/ContentHub')
    probe = output / 'Assets/VehiclesPackQualification/Editor'
    copy(HERE / 'VehiclesPackQualification.cs', probe / 'VehiclesPackQualification.cs')
    (probe / 'Astra.Vehicles.Qualification.asmdef').write_text(json.dumps({
        'name': 'Astra.Vehicles.Qualification', 'includePlatforms': ['Editor'], 'references': ['Astra.ContentHub.Editor']}))
    copy(REPO / 'packs/vehicles/metadata.json', output / 'vehicles-metadata.json')
    if args.mode == 'missing-prerequisites':
        return
    copy(hub / 'Assets/Settings', output / 'Assets/Settings')
    if args.mode == 'consumer':
        return
    pack = output / 'Assets/AstraContent/astra.vehicles'
    pack.mkdir(parents=True)
    provenance = {'sourceProject': 'MotionTest', 'sourceCommit': subprocess.check_output(
        ['git', '-C', str(source), 'rev-parse', 'HEAD'], text=True).strip(), 'files': {}}
    for kind in ['core', 'car', 'boat', 'plane']:
        package = source / ('Packages/com.motion.vehicles.' + kind)
        for item in ['Runtime', 'Editor', 'README.md']:
            if (package / item).exists():
                copy(package / item, pack / kind.title() / item)
        for path in package.rglob('*'):
            if path.is_file():
                provenance['files'][str(path.relative_to(source))] = hashlib.sha256(path.read_bytes()).hexdigest()
    copy(source / 'Assets/MotionVehiclesSamples', pack / 'Demo')
    for path in (source / 'Assets/MotionVehiclesSamples').rglob('*'):
        if path.is_file():
            provenance['files'][str(path.relative_to(source))] = hashlib.sha256(path.read_bytes()).hexdigest()
    fixes = {}
    fixes['FlatWaterSurface'] = split_type(pack, 'Boat/Runtime/WaterSurfaces.cs', 'FlatWaterSurface', '    public sealed class FlatWaterSurface')
    fixes['WaterSurfaceBehaviour'] = split_type(pack, 'Boat/Runtime/WaterSurfaces.cs', 'WaterSurfaceBehaviour', '    public abstract class WaterSurfaceBehaviour')
    fixes['PlaneAtmosphereSettings'] = split_type(pack, 'Plane/Runtime/PlaneAtmosphere.cs', 'PlaneAtmosphereSettings', '    [CreateAssetMenu(')
    fixes['JetFlightControlSettings'] = split_type(pack, 'Plane/Runtime/PlaneFlightControl.cs', 'JetFlightControlSettings', '    [CreateAssetMenu(')
    fixes['JetFlightControl'] = split_type(pack, 'Plane/Runtime/PlaneFlightControl.cs', 'JetFlightControl', '    [DisallowMultipleComponent]')
    # Serialized source assets contain embedded MonoScript references or fileID: 0
    # for these types. Replace only blocks identifying the exact moved class.
    for path in (pack / 'Demo').rglob('*'):
        if path.suffix not in ['.asset', '.prefab', '.unity']:
            continue
        text = path.read_text()
        blocks = re.split(r'(?=^--- !u!)', text, flags=re.M)
        for i, block in enumerate(blocks):
            if not block.startswith('--- !u!114 '):
                continue
            match = re.search(r'm_EditorClassIdentifier: (.+)', block)
            if not match:
                continue
            name = re.split(r'[:.]', match.group(1).strip())[-1]
            if name in fixes:
                blocks[i] = re.sub(r'm_Script: \{[^}]*\}', 'm_Script: {fileID: 11500000, guid: ' + fixes[name] + ', type: 3}', block)
        path.write_text(''.join(blocks))
    # All authoring menus target the installed demo folder, including regeneration.
    for path in pack.rglob('*.cs'):
        if 'Editor' in path.parts:
            text = path.read_text().replace('Assets/MotionVehiclesSamples', 'Assets/AstraContent/astra.vehicles/Demo')
            text = text.replace('EnsureFolder("Assets", "MotionVehiclesSamples");', '')
            path.write_text(text)
    for path in pack.rglob('README.md'):
        path.write_text(path.read_text().replace('Assets/MotionVehiclesSamples', 'Assets/AstraContent/astra.vehicles/Demo'))
    copy(REPO / 'packs/vehicles/PackReadme.md', pack / 'README.md')
    copy(REPO / 'packs/vehicles/LICENSE.txt', pack / 'LICENSES/LICENSE.txt')
    (pack / 'PROVENANCE.json').write_text(json.dumps(provenance, indent=2) + '\n')
    for path in [pack] + sorted(pack.rglob('*')):
        if path.is_symlink():
            raise ValueError('Symlinks are not allowed: ' + str(path))
        if path.suffix != '.meta' and not Path(str(path) + '.meta').exists():
            meta(path, str(path.relative_to(pack)))


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, required=True)
    parser.add_argument('--hub', type=Path, required=True)
    parser.add_argument('--output', type=Path, required=True)
    parser.add_argument('--mode', choices=['author', 'consumer', 'missing-prerequisites', 'tests'], required=True)
    prepare(parser.parse_args())
