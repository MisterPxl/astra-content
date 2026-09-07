# Astra Content

Catalogue privé des packs éditables pour **Astra Content Hub** dans Unity.

## Accès au catalogue

Le dépôt est privé et seul le compte propriétaire `MisterPxl` figure parmi ses
collaborateurs. L’URL du catalogue est :

```text
https://raw.githubusercontent.com/MisterPxl/astra-content/main/catalog.json
```

Cette URL exige désormais une authentification GitHub. Le Hub actuel prend en
charge les catalogues publics HTTPS et les fixtures locales ; son accès à ce
dépôt privé reste à implémenter. Le catalogue local reste utilisable pendant ce
temps. Ne pas intégrer de jeton dans une URL ou dans les fichiers versionnés.

Le Hub installe les packs éditables sous `Assets/AstraContent/<pack-id>/`, avec
leurs métadonnées Unity.

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
manifeste et ses notices incluses. La visibilité privée du dépôt est indépendante
du choix de licence pour le code des futurs packs.

Voir [le guide de publication](CONTRIBUTING.md) et [les releases](https://github.com/MisterPxl/astra-content/releases).
