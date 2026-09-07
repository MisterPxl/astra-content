# Astra Content

Catalogue public des packs éditables pour **Astra Content Hub** dans Unity.

## Connecter le Hub

Dans **Tools > Astra > Content Hub > Open**, renseigner cette URL de catalogue :

```text
https://raw.githubusercontent.com/MisterPxl/astra-content/main/catalog.json
```

Les métadonnées sont accessibles en HTTPS, sans compte GitHub. Le Hub télécharge
les archives uniquement à la demande et installe les fichiers éditables sous
`Assets/AstraContent/<pack-id>/`, avec leurs métadonnées Unity.

## État du catalogue

**[Vehicles 1.0.0](packs/vehicles/README.md)** (`astra.vehicles`) regroupe les
voitures, bateaux, avions légers et jets de MotionTest, avec leurs variantes
arcade : huit prefabs, trois scènes, physique, clavier/manette, caméra et télémétrie.
Le code et les modèles procéduraux sont distribués sous **licence MIT**.

Prérequis qualifiés : **Unity 6000.4.0f1**, **URP 17.4.0**, **Input System 1.19.0**,
backend Input System actif et cible macOS. Les prérequis sont à préparer avant
l'import ; le Hub ne modifie pas les packages ni les réglages du projet.

Le pack `astra.adventure` reste prévu ; sa licence de code et sa publication
restent à finaliser.

## Organisation

- `catalog.json` : pointeur vers la révision courante.
- `catalogs/<revision>/` : index et pages immuables de métadonnées.
- `schemas/` : contrats JSON V1 du Hub.
- `manifests/<pack-id>/<version>.json` : manifestes des versions publiées.
- `thumbnails/<pack-id>/` : futurs aperçus légers.
- **GitHub Releases** : archives ZIP des packs, hors de l’historique Git.

Chaque pack déclare sa licence, ses attributions et ses prérequis dans son
manifeste et ses notices incluses. La visibilité publique de ce dépôt ne choisit
pas une licence pour le code des futurs packs.

Voir [le guide de publication](CONTRIBUTING.md) et [les releases](https://github.com/MisterPxl/astra-content/releases).
