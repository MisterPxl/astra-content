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

**[Adventure 2.0.2](packs/adventure/README.md)** (`astra.adventure`) regroupe un
contrôleur action-aventure, Input System et une démo humanoïde animée avec caméra,
escalade, épée et arc, avec depuis la 1.1.0 un pont vers le framework Astra
(`Adventure.Astra`). Il est livré avec son **template de genre**
(`astra.template.adventure` 2.0.2, catégorie **Templates**) : parcours de démarrage et HUD
cœurs, roue d'endurance et réticule d'arc. La 1.0.0 reste disponible hors framework. Le code et
la démo Astra sont distribués sous **licence MIT** ; les modèles, textures et animations
Quaternius conservent leurs notices **CC0-1.0**.

**[Dialogue 0.1.5](packs/dialogue/README.md)** (`astra.dialogue`) regroupe Dialogue
Studio (éditeur de conversations à bulles), un moteur d'exécution avec conditions et
actions extensibles, des échanges XLSX à comparaison à trois versions, une présentation
UI Toolkit et la démo du verger. Code et démo distribués sous **licence MIT** ; indifférent
au pipeline de rendu, sans Input System.

**[Quests & Achievements 2.0.1](packs/quests/README.md)** (`astra.quests`) apporte des quêtes
et des succès pilotés par les données (signaux, stats, conditions, récompenses, quêtes
chronométrées, paliers), avec journal, galerie, suivi HUD et règles Aegis. Son pont
**[Quests ↔ Dialogue 1.2.1](packs/quests-dialogue/README.md)** (`astra.quests.dialogue`,
catégorie **Bridges**) relie la progression aux conversations d'Astra Dialogue : conditions,
actions et objectifs de dialogue. Code sous **licence MIT**, sans asset tiers.

**[Inventory 1.0.0](packs/inventory/README.md)** (`astra.inventory`, catégorie **Gameplay**) apporte
un inventaire data-driven : piles avec limites de slots et de poids, équipement par slots typés,
effets d'utilisation ouverts, tables de loot pondérées déterministes, recettes de craft, sauvegarde,
valeurs de HUD, vues UGUI et règles Aegis. Quatre ponts (catégorie **Bridges**) le relient au reste du
catalogue : **[Inventory ↔ Quests 1.0.0](packs/inventory-quests/README.md)** (`astra.inventory.quests`,
objectifs Collecter / Fabriquer / Équiper, conditions et récompenses d'objets),
**[Inventory ↔ Dialogue 1.0.0](packs/inventory-dialogue/README.md)** (`astra.inventory.dialogue`,
conditions et actions d'inventaire dans les conversations),
**[Adventure ↔ Dialogue 1.0.0](packs/adventure-dialogue/README.md)** (`astra.adventure.dialogue`,
zone et objet interactif qui lancent une conversation) et
**[Adventure ↔ Quests 1.0.0](packs/adventure-quests/README.md)** (`astra.adventure.quests`, zone,
rapporteur de coups et observateur de fin de run qui alimentent la progression). Code sous
**licence MIT**, sans asset tiers.

**[Soft Body 2D & 3D 0.3.1](packs/softbody/README.md)** (`astra.softbody`) simule des corps mous
(gelée, ballons sous pression, plastique) en 2D et en 3D, avec préparation de sprites et de
maillages, découpe libre et playgrounds. Pack URP sans dépendance au framework Astra, code et
exemples sous **licence MIT**.

**[Vehicles 1.0.1](packs/vehicles/README.md)** (`astra.vehicles`) regroupe les
voitures, bateaux, avions légers et jets de MotionTest, avec leurs variantes
arcade : huit prefabs, trois scènes, physique, clavier/manette, caméra et télémétrie.
Le code et les modèles procéduraux sont distribués sous **licence MIT**.

**[Match3 4.0.1](packs/match3/README.md)** (`astra.match3`), **[Melee 4.0.1](packs/melee/README.md)**
(`astra.melee`), **[FPS 2.0.1](packs/fps/README.md)** (`astra.fps`),
**[Deckbuilder 3.0.1](packs/deckbuilder/README.md)** (`astra.deckbuilder`),
**[Shmup 1.1.2](packs/shmup/README.md)** (`astra.shmup`) et
**[Tactics 2.1.0](packs/tactics/README.md)** (`astra.tactics`) sont des packs de gameplay
livrés avec leur **template de genre** (`astra.template.match3`, `astra.template.melee`,
`astra.template.fps`, `astra.template.deckbuilder`, `astra.template.shmup`, `astra.template.tactics`), publiés dans la catégorie **Templates** du Hub : le template tire son pack
de gameplay, puis Astra Setup applique sa composition. Code et contenu sous **licence MIT** ; les
assets Quaternius de Melee Template restent en **CC0-1.0**.

**[Grass 0.2.3](packs/grass/README.md)** (`astra.grass`), **[Snow 0.2.2](packs/snow/README.md)**
(`astra.snow`), **[Water 0.2.2](packs/water/README.md)** (`astra.water`) et
**[Sky 0.2.2](packs/sky/README.md)** (`astra.sky`) forment la catégorie
**Environment** : herbe peinte au pinceau avec vent, interacteurs et rendu GPU indirect ; neige
déformable avec couverture des objets ; eau à vagues de Gerstner, réfraction, écume, ondulations
et flottaison ; ciel jour/nuit avec étoiles, lune, nuages, réflexions et horloge de jeu. Quatre
packs URP indépendants, code et démos sous **licence MIT**, sans asset tiers.

**[Shaders Core 0.1.2](packs/shaders-core/README.md)** (`astra.shaders.core`),
**[Shaders Stylized 0.1.3](packs/shaders-stylized/README.md)** (`astra.shaders.stylized`),
**[Shaders FX 0.1.3](packs/shaders-fx/README.md)** (`astra.shaders.fx`) et
**[Shaders UI 0.1.3](packs/shaders-ui/README.md)** (`astra.shaders.ui`) forment la catégorie
**[Shaders](packs/shaders/README.md)** : bibliothèque HLSL partagée (hash, bruits, Voronoi, FBM,
triplanaire, dither, passes `ShadowCaster` / `DepthOnly` / `DepthNormals`) et shaders de debug ;
éclairage toon avec contour par coque inversée et variante triplanaire ; effets sprite, bouclier,
traînée, distorsion et particules avec composants sans allocation par frame ; formes SDF, anneaux
segmentés, cartes holographiques et dissolve pour uGUI en un seul draw call. Code, shaders et démos
sous **licence MIT** (hash adapté de David Hoskins sous MIT).

Catalogue `gameplay-v30` : contrat Content Hub V2, lisible par le Hub du framework à partir du tag `framework-game-2026-10-19` (Core : `framework-core-2026-10-19`). Les versions antérieures des packs (contrat V1) ne sont plus listées ; leurs archives restent téléchargeables.

Prérequis qualifiés : **Unity 6000.4.0f1**, **URP 17.4.0**, **Input System 1.19.0**,
backend Input System actif et cible macOS. Les prérequis sont à préparer avant
l'import ; le Hub ne modifie pas les packages ni les réglages du projet.

## Organisation

- `catalog.json` : pointeur vers la révision courante.
- `catalogs/<revision>/` : index et pages immuables de métadonnées.
- `schemas/` : contrats JSON V2 du Hub (dépendances de contenu par plages de versions).
- `manifests/<pack-id>/<version>.json` : manifestes des versions publiées.
- `thumbnails/<pack-id>/` : aperçus légers affichés dans le Hub.
- **GitHub Releases** : archives ZIP des packs, hors de l’historique Git.

Chaque pack déclare sa licence, ses attributions et ses prérequis dans son
manifeste et ses notices incluses. La visibilité publique de ce dépôt ne choisit
pas une licence pour le code des futurs packs.

Voir [le guide de publication](CONTRIBUTING.md) et [les releases](https://github.com/MisterPxl/astra-content/releases).
