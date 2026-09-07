# Publier un pack

Le dépôt contient les métadonnées et les petites miniatures. Les sources d’auteur,
FBX, textures volumineuses, caches et ZIP restent hors de l’historique Git.

1. Définir la licence du code et du contenu, conserver les notices et attributions
   des tiers, puis qualifier le pack dans un projet consommateur vierge.
2. Exporter avec l’URL HTTPS définitive de l’archive GitHub Release. Le manifeste
   et le document `pack.json` doivent correspondre ; ne pas publier le candidat
   local avec ses adresses `127.0.0.1` ou sa notice de licence provisoire.
3. Créer une release par pack/version, par exemple `adventure-v1.0.0`, et joindre
   le ZIP. Télécharger l’archive sans authentification et vérifier son SHA-256.
4. Ajouter le manifeste immuable sous `manifests/<id>/<version>.json`, puis les
   pages et l’index d’une nouvelle révision sous `catalogs/<revision>/`.
5. Valider les JSON avec les schémas du dossier `schemas/`, contrôler les tailles,
   empreintes et URLs, puis tester leur lecture par le Hub.
6. Mettre à jour `catalog.json` en dernier, lorsque toutes les ressources sont
   accessibles publiquement. Conserver les anciennes révisions et versions.

Une version publiée est immuable : ne pas remplacer son ZIP, son manifeste ou
les pages d’une révision déjà référencée. Publier une nouvelle version/révision.
Une dépendance à un autre pack indique sa version exacte. Les packages Unity
restent des prérequis et ne sont pas ajoutés automatiquement par le Hub.

Le pack Adventure est une seule unité `astra.adventure`. Ses assemblies internes
peuvent rester distinctes sans devenir plusieurs entrées de catalogue.

Le pack Vehicles suit le même principe : une seule unité `astra.vehicles` pour
Core, Car, Boat et Plane. Sa recette d'assemblage et de qualification est dans
[`packs/vehicles/README.md`](packs/vehicles/README.md).
