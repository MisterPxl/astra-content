# Vehicles — astra.vehicles 1.0.0

Un seul pack MIT réunit tout le contenu véhicules de MotionTest : voitures,
bateaux, avions légers et jets, avec leurs variantes arcade. Il contient huit
prefabs, trois scènes, les configurations, matériaux et meshes procéduraux,
les commandes clavier/manette, la caméra et la télémétrie.

Le [guide utilisateur inclus](PackReadme.md) décrit les contrôles et prérequis.
La [licence MIT](LICENSE.txt) couvre le code et les modèles procéduraux.
Les sources volumineuses et l'archive restent hors de l'historique de ce dépôt.

## Assemblage

Les quatre packages Motion deviennent des dossiers `Core`, `Car`, `Boat` et
`Plane` dans la même archive. Leurs assemblies et namespaces restent distincts.
Les trois démos sont copiées sous `Demo`, avec leurs GUID d'origine. Les tests
restent dans le projet de qualification, hors du pack distribué.

Cinq types Unity sont extraits dans des fichiers portant leur nom :
`WaterSurfaceBehaviour`, `FlatWaterSurface`, `PlaneAtmosphereSettings`,
`JetFlightControlSettings` et `JetFlightControl`. Cela corrige les scripts sans
référence persistante des assets d'origine. Leurs GUID sont déterministes et les
références sérialisées sont réparées sans modifier MotionTest.

Le générateur existant produit également `ArcadePlaningBoat.prefab`, absent des
assets d'origine. Les menus de génération sont inclus et ciblent le dossier du
pack installé. Le guide précise qu'ils remplacent leurs assets générés.

`PROVENANCE.json` dans l'archive contient le commit MotionTest et les SHA-256 des
fichiers source réellement copiés. Les modifications locales de la scène voiture
sont incluses ; le fichier UPM supprimé dans MotionTest n'est pas nécessaire à
l'assemblage. Les projets source ne sont pas modifiés.

## Reproduire la qualification

Utiliser Python 3 et Unity 6000.4.0f1. Le paramètre `--hub` désigne le projet Astra
contenant `Assets/_Project/Editor/ContentHub` et ses réglages URP de qualification.
Le dossier de sortie doit être nouveau, hors des sources.

```sh
python3 -m venv .venv
.venv/bin/python -m pip install -r tools/vehicles/requirements.txt
.venv/bin/python tools/vehicles/qualify.py \
  --source /chemin/MotionTest \
  --hub /chemin/AI_Testing_Sandbox \
  --output /chemin/qualification-vehicles \
  --unity /Applications/Unity/Hub/Editor/6000.4.0f1/Unity.app/Contents/MacOS/Unity
```

La commande prépare un auteur isolé, génère le bateau arcade, exporte deux fois,
compare les empreintes, vérifie le refus d'import sans prérequis, importe via la
transaction réelle du Hub, relance Unity, vérifie le reçu et les références,
puis lance les tests EditMode et PlayMode. Elle vérifie enfin les schémas JSON,
les tailles, toutes les empreintes et la concordance entre manifeste et `pack.json`.
Elle n'effectue aucune publication.

Unity peut mettre à jour les APIs de Shader Graph au premier démarrage. Le runner
n'accepte pas le seul code de sortie 0 : il exige le marqueur de réussite de
chaque étape et relance une fois après une mise à jour API détectée.

Les mêmes sources sont réexportables ; les nouveaux assets créés par les outils
Unity reçoivent des GUID lors de la génération. Le test de déterminisme compare
les deux ZIP produits à partir d'un même état auteur finalisé.

Voir [le bilan de validation](Validation.md) et le [guide de publication](../../CONTRIBUTING.md).

Après publication, `VehiclesPackQualification.VerifyPublic` dans un projet de
qualification contrôle le catalogue public, résout `astra.vehicles@1.0.0`,
télécharge l'archive avec le client réel du Hub et vérifie son extraction.
