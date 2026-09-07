#!/usr/bin/env python3
"""Validate a Vehicles catalogue and its archive, including every hash and GUID reference."""
import argparse
import hashlib
import json
from pathlib import Path
import re
import zipfile
import jsonschema

REPO = Path(__file__).resolve().parents[2]
BASE = 'https://raw.githubusercontent.com/MisterPxl/astra-content/main/'


def validate(root):
    schemas = {p.stem.removesuffix('.schema'): json.loads(p.read_text()) for p in (REPO / 'schemas').glob('*.json')}
    def read(path, kind):
        data = json.loads(path.read_text())
        jsonschema.validate(data, schemas[kind])
        return data
    def ref(url, digest, size=None):
        assert url.startswith(BASE), url
        path = root / url.removeprefix(BASE)
        data = path.read_bytes()
        assert hashlib.sha256(data).hexdigest() == digest, path
        assert size is None or len(data) == size, path
        return path
    pointer = read(root / 'catalog.json', 'catalog')
    index = read(ref(pointer['indexUrl'], pointer['indexSha256']), 'index')
    assert index['revision'] == pointer['revision']
    manifests = {}
    for entry in index['versions']:
        manifest = read(ref(entry['url'], entry['sha256'], entry['bytes']), 'manifest')
        assert (manifest['id'], manifest['version']) == (entry['id'], entry['version'])
        manifests[entry['url']] = manifest
    for page_ref in index['pages']:
        page = read(ref(page_ref['url'], page_ref['sha256'], page_ref['bytes']), 'page')
        for summary in page['packs']:
            manifest = manifests[summary['manifestUrl']]
            ref(summary['manifestUrl'], summary['manifestSha256'])
            assert summary['compressedBytes'] == manifest['archive']['bytes']
            assert summary['recommendedVersion'] == manifest['version']
    manifest = next(m for m in manifests.values() if m['id'] == 'astra.vehicles')
    archive = root / 'archives/astra.vehicles-1.0.0.zip'
    assert hashlib.sha256(archive.read_bytes()).hexdigest() == manifest['archive']['sha256']
    assert archive.stat().st_size == manifest['archive']['bytes']
    with zipfile.ZipFile(archive) as z:
        doc = json.loads(z.read('pack.json'))
        jsonschema.validate(doc, schemas['pack'])
        assert {k:v for k,v in doc.items() if k != 'files'} == {k:v for k,v in manifest.items() if k != 'archive'}
        assert len(doc['files']) == manifest['archive']['fileCount']
        assert sum(f['bytes'] for f in doc['files']) == manifest['archive']['expandedBytes']
        assert set(z.namelist()) == {'pack.json'} | {'payload/' + f['path'] for f in doc['files']}
        guids = set()
        files = {}
        for entry in doc['files']:
            data = z.read('payload/' + entry['path'])
            assert len(data) == entry['bytes']
            assert hashlib.sha256(data).hexdigest() == entry['sha256']
            files[entry['path']] = data
            if entry['path'].endswith('.meta'):
                guid = re.search(rb'^guid: (\w+)', data, re.M).group(1).decode()
                assert guid == entry['guid'] and guid not in guids
                guids.add(guid)
        assert len([p for p in files if p.endswith('.prefab')]) == 8
        assert len([p for p in files if p.endswith('.unity')]) == 3
        assert files['LICENSES/LICENSE.txt'] == (REPO / 'packs/vehicles/LICENSE.txt').read_bytes()
        assert not any('/Tests/' in p for p in files)
        assert not any(p.startswith(('Packages/', 'ProjectSettings/')) for p in files)
    print(f"Validated catalogue, manifest, MIT notice, {len(doc['files'])} payload files, 8 prefabs, 3 scenes; SHA-256 {manifest['archive']['sha256']}")

if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('catalogue', type=Path)
    validate(parser.parse_args().catalogue.resolve())
