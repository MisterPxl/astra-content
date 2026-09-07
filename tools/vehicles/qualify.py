#!/usr/bin/env python3
"""Run the complete isolated Unity export/import qualification (never publishes)."""
import argparse
from pathlib import Path
import subprocess
import sys
import xml.etree.ElementTree as ET

HERE = Path(__file__).resolve().parent


def main():
    p = argparse.ArgumentParser(description=__doc__)
    p.add_argument('--source', type=Path, required=True)
    p.add_argument('--hub', type=Path, required=True)
    p.add_argument('--output', type=Path, required=True)
    p.add_argument('--unity', type=Path, required=True)
    args = p.parse_args()
    output = args.output.resolve()
    output.mkdir()  # Refuse to overwrite any earlier evidence or author project.
    catalogue = output / 'catalogue'
    def prepare(mode, project):
        subprocess.run([sys.executable, str(HERE / 'prepare.py'), '--source', str(args.source.resolve()),
            '--hub', str(args.hub.resolve()), '--mode', mode, '--output', str(project)], check=True)
    def unity(project, method, marker):
        for attempt in range(2):
            log = output / (project.name + '-' + method + '-' + str(attempt) + '.log')
            result = subprocess.run([str(args.unity), '-batchmode', '-nographics', '-quit', '-projectPath', str(project),
                '-executeMethod', 'VehiclesPackQualification.' + method, '-vehiclesCatalogue', str(catalogue), '-logFile', str(log)])
            text = log.read_text(errors='replace')
            if result.returncode == 0 and marker in text:
                return
            # Unity 6 API Updater may finish a first launch without executing the method.
            if attempt == 0 and '[API Updater] Updated Files:' in text:
                continue
            raise RuntimeError('Unity qualification failed: ' + str(log))
        raise RuntimeError('Unity API update did not settle')
    author, consumer, missing = [output / n for n in ['author', 'consumer', 'missing']]
    prepare('author', author)
    unity(author, 'Generate', 'VEHICLES_GENERATED')
    unity(author, 'Export', 'VEHICLES_EXPORTED')
    prepare('missing-prerequisites', missing)
    unity(missing, 'MissingPrerequisites', 'VEHICLES_MISSING_PREREQUISITES_VERIFIED')
    prepare('consumer', consumer)
    unity(consumer, 'Setup', 'VEHICLES_PROJECT_PREPARED')
    unity(consumer, 'Import', 'VEHICLES_IMPORT_COPY_READY')
    unity(consumer, 'Verify', 'VEHICLES_IMPORT_VERIFIED')
    prepare('tests', consumer)
    for platform in ['EditMode', 'PlayMode']:
        result = output / (platform + '.xml')
        subprocess.run([str(args.unity), '-batchmode', '-nographics', '-projectPath', str(consumer),
            '-runTests', '-testPlatform', platform, '-testResults', str(result),
            '-logFile', str(output / (platform + '.log'))], check=True)
        report = ET.parse(result).getroot()
        if report.get('result') != 'Passed' or int(report.get('total', '0')) == 0:
            raise RuntimeError('Failed or empty test suite: ' + str(result))
    subprocess.run([sys.executable, str(HERE / 'validate.py'), str(catalogue)], check=True)
    print('Qualified catalogue: ' + str(catalogue))

if __name__ == '__main__':
    main()
