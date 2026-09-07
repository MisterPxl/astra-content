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

Le dépôt est initialisé avec un catalogue valide, **sans pack publié pour le moment**.
Le premier contenu prévu est **`astra.adventure`**, un pack unique comprenant
le contrôleur, l’intégration Input System et la démo humanoïde animée.
Sa qualification locale est terminée ; sa licence de code et sa publication
restent à finaliser. Aucun candidat de test local n’est distribué par ce dépôt.

## Organisation

- `catalog.json` : pointeur vers la révision courante.
- `catalogs/<revision>/` : index et pages immuables de métadonnées.
- `schemas/` : contrats JSON V1 du Hub.
- `manifests/<pack-id>/<version>.json` : manifestes des futures versions publiées.
- `thumbnails/<pack-id>/` : futurs aperçus légers.
- **GitHub Releases** : archives ZIP des packs, hors de l’historique Git.

Chaque pack déclarera sa licence, ses attributions et ses prérequis dans son
manifeste et ses notices incluses. La visibilité publique de ce dépôt ne choisit
pas une licence pour le code des futurs packs.

Voir [le guide de publication](CONTRIBUTING.md) et [les releases](https://github.com/MisterPxl/astra-content/releases).
