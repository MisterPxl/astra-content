# Astra Shaders

Quatre packs publics de la catégorie **Shaders** pour **Astra Content Hub** dans Unity (URP 17.4+) :
une bibliothèque HLSL partagée et trois packs d'effets et de rendu qui s'appuient dessus.

| Pack | Version (`gameplay-v26`) | Description | Fiche publique |
| --- | --- | --- | --- |
| `astra.shaders.core` | **0.1.2** (`shaders-core-v0.1.2`) | Bibliothèque HLSL partagée (hash, bruits, Voronoi, FBM, triplanaire, dither, flash, dissolve, passes `ShadowCaster` / `DepthOnly` / `DepthNormals`, wrappers Shader Graph), 4 shaders de debug et démo `ShadersShowcase.unity`. | [packs/shaders-core](../shaders-core/README.md) |
| `astra.shaders.stylized` | **0.1.3** (`shaders-stylized-v0.1.3`) | Shaders `Toon` et `ToonTriplanar` (bandes ou rampe, ombres teintées, Forward+, rim, spéculaire, contour par coque inversée, cuisson des normales d'outline dans UV3), démo et galerie. | [packs/shaders-stylized](../shaders-stylized/README.md) |
| `astra.shaders.fx` | **0.1.3** (`shaders-fx-v0.1.3`) | Shaders `Sprite`, `Shield` (8 impacts), `Trail`, `Distortion` et `ParticleDissolve`, composants `AstraHitFlash`, `AstraDissolve` et `AstraShieldHits` sans allocation par frame, démo et galerie. | [packs/shaders-fx](../shaders-fx/README.md) |
| `astra.shaders.ui` | **0.1.3** (`shaders-ui-v0.1.3`) | Shaders et composants `Graphic` uGUI batchés par UV (`AstraShape`, `AstraRing`, `AstraFoilTilt`, `AstraUIDissolve`), compatibles `Mask`, `RectMask2D` et `CanvasGroup`, démo et galerie. | [packs/shaders-ui](../shaders-ui/README.md) |

`astra.shaders.stylized`, `astra.shaders.fx` et `astra.shaders.ui`, ainsi que les packs
d'environnement ([Grass](../grass/README.md), [Snow](../snow/README.md),
[Water](../water/README.md), [Sky](../sky/README.md)), déclarent une dépendance par plage sur
`astra.shaders.core` `[0.1.2, 0.2.0)`, que le Hub résout et importe dans la même transaction.
