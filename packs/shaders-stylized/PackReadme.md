# Astra Shaders Stylized

Pack Content Hub **astra.shaders.stylized** : shaders toon pour URP (Forward et Forward+), écrits en HLSL sur
la bibliothèque `astra.shaders.core`. Ne déplacez pas le dossier du pack : ses shaders incluent la bibliothèque
par un chemin relatif.

## Shaders

| Shader | Usage |
|---|---|
| `Astra/Stylized/Toon` | Lumière principale en deux ou trois bandes (seuil et douceur réglables) ou par texture de rampe, ombres teintées par `Shadow Tint` au lieu d'être assombries, lumières additionnelles, rim, spéculaire en bande, émission, base map, normal map, brouillard. |
| `Astra/Stylized/ToonTriplanar` | Même éclairage, avec une texture de dessus (faces tournées vers le haut) et une texture de côté projetées sans UV, en espace monde (par défaut) ou objet. Terrain, rochers, blocking. |

Les deux projettent des ombres et écrivent la profondeur et les normales (SSAO compris).

### Contour

`Outline` active une coque inversée : le mesh redessiné face avant masquée, poussé le long de ses normales,
dans une passe `SRPDefaultUnlit` qu'URP dessine après la passe opaque. Largeur en mètres (`World Units`) ou
constante à l'écran (`Screen Pixels`). L'inspecteur du matériau désactive la passe quand le contour est coupé :
un matériau créé par script appelle `material.SetShaderPassEnabled("SRPDefaultUnlit", false)` lui-même, sinon il
paie un draw call vide.

Sur un mesh à arêtes vives (cube, low poly), la coque s'ouvre aux coins. **Tools > Astra > Shaders > Bake
Outline Normals** sur un mesh ou des objets sélectionnés écrit une copie du mesh avec des normales lissées dans
UV3, à côté du mesh source (jamais dans un dossier de pack ; pour un mesh intégré à Unity, un dossier est
demandé) et l'assigne aux objets sélectionnés. Cochez ensuite `Use Baked Outline Normals (UV3)` sur le matériau.
Le mesh source doit être lisible (Read/Write). Sur un mesh skinné, les normales cuites restent celles de la pose de
référence.

### Flash et dissolve

Les propriétés `_AstraFlash*` et `_AstraDissolve*` de `astra.shaders.core` sont exposées ; les composants de
`astra.shaders.fx` (`AstraHitFlash`, `AstraDissolve`) les pilotent par `MaterialPropertyBlock` sans dupliquer le
matériau. Le flash marche sur tout matériau toon. Le dissolve demande la case `Dissolve (alpha clip)` : un
`clip()` dans une passe coûte le rejet précoce de profondeur, il n'est donc compilé que pour les matériaux qui
le demandent.

## Démo

`Demo/Generated/Stylized.unity`, faite de primitives : personnages en deux bandes, trois bandes, rampe, normal
map et émission, contours en mètres et en pixels, cube à arêtes vives avec et sans normales cuites, sol et
rochers triplanar. **N** passe du jour (soleil) à la nuit (lune et lampes colorées), **Espace** met l'orbite de la
caméra en pause, les flèches la tournent. **Tools > Astra > Shaders > Build Stylized Demo** la régénère (sous
`Assets/AstraStylizedDemo` quand le pack est installé par le Hub).

## Galerie

`Demo/Generated/StylizedGallery.unity` : une scène fixe, sans interaction, qui montre les réglages côte à côte.
Une étagère par thème, six objets étiquetés par étagère : bandes (deux, trois, rampe, seuil, adoucissement), ombre
et reflets (couleur d'ombre, rim, spéculaire), contours (en mètres, en pixels, arête vive, normales cuites),
triplanaire (espace monde ou objet, couverture du dessus, netteté) et effets (flash, dissolve, émission, normal
map). **Tools > Astra > Shaders > Build Stylized Gallery** la régénère (sous `Assets/AstraStylizedDemo` quand le
pack est installé par le Hub).

## Budgets

Mesurés sur Apple M2 Max, URP du projet auteur (Forward+, ombres douces, 4 cascades) :

- variants de fragment après stripping URP, build macOS de la démo et de la galerie : Toon 29, ToonTriplanar 13
  (budget 64 par shader) ;
- même scène en 1080p (soleil avec ombres, 8 lumières ponctuelles, 61 objets) : Toon 0,87 × le temps d'URP Lit ;
  le contour ajoute une passe et un draw call par objet.

## Licence

MIT, voir `LICENSES/LICENSE.txt`.
