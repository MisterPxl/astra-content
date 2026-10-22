# Astra Shaders Core

Pack Content Hub **astra.shaders.core** : bibliothèque HLSL pour URP partagée par les packs de shaders
Astra (`astra.shaders.stylized`, `astra.shaders.fx`, `astra.shaders.ui`) et les packs d'environnement
(Grass, Snow, Water, Sky). Elle ne contient aucun matériau : seulement des fichiers `.hlsl` à inclure.

## Inclure la bibliothèque

Depuis un shader d'un autre pack, toujours par un **chemin relatif** :

```hlsl
#include "../../astra.shaders.core/ShaderLibrary/AstraNoise.hlsl"
```

Le chemin marche parce que les packs sont voisins : `Assets/Packs/<id>/` dans le projet auteur,
`Assets/AstraContent/<id>/` quand le Hub les installe. Ne déplacez pas les dossiers des packs. Un pack qui
inclut la bibliothèque la déclare dans `contentDependencies` ; `Tools/check_shader_includes.py` le vérifie.

## Fichiers

| Fichier | Contenu |
|---|---|
| `AstraHash.hlsl` | Hash « without Sine » de Dave Hoskins, `AstraHash<sorties><entrées>` (`AstraHash12` : `float2` vers `float`). Résultats dans `[0, 1)`. |
| `AstraNoise.hlsl` | Bruit de valeur 2D et 3D, bruit de valeur périodique (pavable), bruit de gradient, Voronoi (distance, cellule, distance au bord), FBM 2D et 3D. |
| `AstraMath.hlsl` | `AstraInverseLerp`, `AstraRemap`, `AstraRemapClamped`, `AstraRotate2D`, `AstraRotateAroundAxis`. |
| `AstraTriplanar.hlsl` | Poids, échantillonnage couleur et normal map en triplanar (après `Core.hlsl` d'URP). |
| `AstraDither.hlsl` | Dither de Bayer 4×4 et `AstraDitherClip` pour les fondus sans transparence. |
| `AstraEffects.hlsl` | Flash et dissolve : propriétés à déclarer (`ASTRA_FLASH_PROPERTIES`, `ASTRA_DISSOLVE_PROPERTIES`) et fonctions. |
| `AstraShadows.hlsl` | `AstraShadowClipPosition` pour les shaders qui ont leur propre étage de sommets. |
| `AstraShadowCasterPass.hlsl`, `AstraDepthOnlyPass.hlsl`, `AstraDepthNormalsPass.hlsl` | Passes complètes, avec déformation, découpe et normale par pixel optionnelles (voir `AstraPassCommon.hlsl`). |
| `AstraShaderGraph.hlsl` | Variantes `_float` / `_half` pour les nœuds Custom Function de Shader Graph. |

## Passes partagées

Une passe sans crochet :

```hlsl
Pass
{
    Name "ShadowCaster"
    Tags { "LightMode" = "ShadowCaster" }
    ZWrite On
    ZTest LEqual
    ColorMask 0
    HLSLPROGRAM
    #pragma vertex AstraShadowCasterVertex
    #pragma fragment AstraShadowCasterFragment
    #pragma multi_compile_vertex _ _CASTING_PUNCTUAL_LIGHT_SHADOW
    #include "../../astra.shaders.core/ShaderLibrary/AstraShadowCasterPass.hlsl"
    ENDHLSL
}
```

Avec déformation des sommets (la même que la passe éclairée, sinon l'ombre et la profondeur décrochent) :

```hlsl
#include "../../astra.shaders.core/ShaderLibrary/AstraPassCommon.hlsl"
#define ASTRA_PASS_DISPLACE
void AstraPassDisplace(AstraPassAttributes input, inout float3 positionWS, inout float3 normalWS)
{
    positionWS += normalWS * 0.1;
}
#include "../../astra.shaders.core/ShaderLibrary/AstraShadowCasterPass.hlsl"
```

`ASTRA_PASS_CLIP` (alpha test, dissolve) et `ASTRA_PASS_NORMAL` (normale par pixel de DepthNormals)
suivent le même modèle.

## Shaders de debug

**Tools > Astra > Shaders > Create Debug Materials** écrit un matériau par shader de debug dans le dossier
choisi (jamais dans le dossier du pack ni sous `Assets/AstraContent`). Aucun ne demande de texture ; tous
projettent des ombres et écrivent la profondeur et les normales (SSAO compris).

| Shader | Usage |
|---|---|
| `Astra/Debug/UVChecker` | Damier procédural sur UV0 ou UV1 : la couleur des cases code leur position (rouge selon U, vert selon V), un repère blanc marque le coin (0, 0) de chaque case, des rayures magenta signalent les UV hors de `[0, 1]`. Étirements, coutures et îlots retournés. |
| `Astra/Debug/PrototypeGrid` | Grille en coordonnées monde, sans UV : lignes fines tous les mètres, épaisses tous les dix, léger damier d'un mètre. Éclairée (soleil, ombres, ambiance) pour le blocking de niveaux. |
| `Astra/Debug/VertexColor` | Couleurs de sommets : RGB ou un canal (R, G, B, A) en gris. |
| `Astra/Debug/TexelDensity` | Texels par mètre d'une texture de la taille donnée sur UV0, comparés à une cible : bleu en dessous, vert sur la cible, rouge au-dessus (saturés à ×0,5 et ×2). |

Le Rendering Debugger d'URP couvre déjà overdraw, albédo et normales : ils ne sont pas dupliqués ici.

## Démo

**Tools > Astra > Shaders > Build Demo** génère `ShadersShowcase.unity` et ses matériaux (dans `Demo/Generated`
du pack en création, sous `Assets/ShadersCoreGenerated` quand le pack est installé par le Hub). Trois rangées :

- au fond, les bruits de `AstraNoise.hlsl` qui défilent : valeur, gradient, FBM, Voronoi (cellules et bords) ;
- au milieu, les quatre shaders de debug (le sol et la marche sont en Prototype Grid) ;
- devant, triplanar, déplacement par bruit (`ASTRA_PASS_DISPLACE`), fondu dither et dissolve
  (`ASTRA_PASS_CLIP` : l'ombre suit), flash.

Les shaders de `Demo/Shaders` servent d'exemples d'utilisation de la bibliothèque et des passes partagées. En
Play, `MaterialPropertyPulse` anime le fondu, le flash et le dissolve par un `MaterialPropertyBlock`, comme le
feront les composants de `astra.shaders.fx`.

## Shader Graph

Dans un nœud Custom Function : Type **File**, Source `ShaderLibrary/AstraShaderGraph.hlsl`, Name sans
suffixe (`AstraValueNoise2`, `AstraVoronoi2`, `AstraDissolve`…). Shader Graph choisit `_float` ou `_half`.

## Licence

MIT. Le hash est adapté de « Hash without Sine » de David Hoskins (MIT, `LICENSES/HashWithoutSine.txt`).
