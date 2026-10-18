# Soft Body 2D & 3D

Pack public `astra.softbody` **0.3.0** (catégorie `Gameplay`) : simulation de corps mous par
CPU (XPBD) en 2D et en 3D, pour de la gelée, des ballons sous pression et des objets plastiques.
Il n'a aucune dépendance au framework Astra, à Aegis, à Valkyrie ou à Helios : il s'importe dans
tout projet Unity 6000.4 URP.

| Dimension | Préparation et rendu | Découpe |
|---|---|---|
| 2D | Sprites ou contours édités, UV de la texture, maillage de rendu séparé optionnel | Segments libres finis, fentes et fragments séparés |
| 3D | Maillages fermés personnalisés, volume en voxels, rendu lié à un maillage source séparé, matériaux de sous-maillage | Plans libres, surfaces de fragments reconstruites, matériau intérieur dédié |

- **Matériaux** : `JellySoft`, `JellyFirm`, `Balloon` (pression modifiable, perdue quand une
  découpe ouvre le ballon) et `Plastic` (déformation conservée au-delà du seuil).
- **Outils d'éditeur** : **Tools / Astra / Soft Body / Prepare 2D Sprite** (analyse du maillage,
  peinture de densité locale, épingles), préparation de maillages 3D, génération des playgrounds.
- **Interaction** : forces, impulsions, attaches vers un Transform, épingles, pression,
  qualité à l'exécution (Low, Medium, High), mode physique ou visuel seul, découpes en file avec
  budgets de fragments et de particules.
- **Samples** : deux playgrounds (`SoftBodyPlayground2D`, `SoftBodyPlayground3D`) et leurs assets
  originaux ; ils se retirent d'un bloc.

La 0.3.0 réduit les coûts (requêtes de contacts une fois par tick, grille de hachage entre objets,
buffers qui grandissent sans troncature silencieuse, environ 9,5 Mo alloués en moins par découpe
3D) et ajoute des garde-fous numériques en 2D. **Changement de comportement** : en 2D, le réveil
et les contacts respectent désormais la matrice de couches Physics2D, comme en 3D. L'événement 3D
`CutRejectedWithGeometry` signale une découpe refusée avec sa géométrie.

Mesures locales (macOS, Apple M2 Max, Metal, 1280×720 URP, Unity 6000.4.0f1) : le p95 de frame
reste à l'intervalle de 60 Hz dans chaque scénario de dix corps, le p95 du dernier tick physique
baisse de 15 à 40 % contre la 0.2.0 reconstruite en URP, et la découpe 3D répétée tourne
autour de 59,4 FPS avec des pics. Ces chiffres sont propres à ces scénarios, pas une garantie
matérielle. Le guide du pack (`README.md`, `README3D.md`, `QUALIFICATION.md`, en anglais) donne
les budgets, l'API et les limites.

Licence : code, textures et maillages de démonstration originaux sous **MIT**. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **URP 17.4.0**, **Input System 1.19.0** (les samples
le référencent ; le backend d'entrée doit être actif) et les modules Unity physique 3D, Physics
2D et capture d'écran. Plateforme qualifiée : macOS standalone. **Limites** : Windows, mobile,
tactile et multitouch, déformation squelettique, repacking d'atlas et précision voxel ne sont pas
qualifiés ; une découpe 3D peut être refusée avec un diagnostic explicite.

Archive publiée via GitHub Releases sous le tag `softbody-v0.3.0`. C'est la seule version
publiée.
