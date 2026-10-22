# Shaders Core

Pack public `astra.shaders.core` pour Astra Content Hub (catégorie `Shaders`). Bibliothèque HLSL
pour URP partagée par les packs de shaders Astra ([Stylized](../shaders-stylized/README.md),
[FX](../shaders-fx/README.md), [UI](../shaders-ui/README.md)) et les packs d'environnement
([Grass](../grass/README.md), [Snow](../snow/README.md), [Water](../water/README.md),
[Sky](../sky/README.md)) : hash sans sinus, bruits 2D et 3D (valeur, valeur périodique, gradient,
Voronoi, FBM), projection triplanaire, dither de Bayer 4×4, flash et dissolve, passes partagées
`ShadowCaster`, `DepthOnly` et `DepthNormals` avec crochets de déformation et de découpe, fonctions
pour Shader Graph, quatre shaders de debug (`UVChecker`, `PrototypeGrid`, `VertexColor`,
`TexelDensity`) et scène de démonstration `ShadersShowcase.unity`.

Licence : bibliothèque, shaders et démo Astra sous MIT ; hash adapté de « Hash without Sine » de
David Hoskins sous MIT (`LICENSES/` dans le pack).

Prérequis : Unity 6000.4.0f1 et Universal Render Pipeline 17.4+. Plateformes déclarées : macOS,
Android et iOS ; le Hub ne modifie ni les packages ni les réglages de rendu.

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.shaders.core` **0.1.2** (au lieu de 0.1.1) : release `shaders-core-v0.1.2`, 108 fichiers, 111208 octets, SHA-256 `738b231e8c49773629219a3be12842049e87606ac747ca404716201bb9c205de` ; dépendances de contenu (plages) : aucune.

Version **0.1.1** : scène de démonstration `ShadersShowcase.unity` (**Tools > Astra > Shaders > Build Demo**) présentant les bruits de la bibliothèque, les quatre shaders de debug, le triplanaire, le déplacement par bruit, le fondu dither, le flash et le dissolve, avec des shaders d'exemple dans `Demo/Shaders` et `MaterialPropertyPulse` en Play. Dans un pack installé par le Hub, la démo est générée sous `Assets/ShadersCoreGenerated` sans écrire dans le pack.
Archive : `shaders-core-v0.1.1`, 108 fichiers, 110928 octets,
SHA-256 `1d284e73a8ec6c60dac61ebbb0b587174fbe29c9b7c0acc6b75fa1ed65c1e815`.
La 0.1.0 (`shaders-core-v0.1.0`) reste téléchargeable.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la conception et la validation sont
décrites dans le dépôt `AI_Testing_Sandbox`, `Documentation/Astra/ContentHub/Shaders/README.md` et
`Documentation/Astra/ShadersValidation.md`.
