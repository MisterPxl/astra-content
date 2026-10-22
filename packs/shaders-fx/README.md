# Shaders FX

Pack public `astra.shaders.fx` pour Astra Content Hub (catégorie `Shaders`). Shaders d'effets pour
URP (Universal Renderer) et composants runtime sans allocation par frame : `Astra/Fx/Sprite`
(teinte, flash, contour alpha, dissolve), `Astra/Fx/Shield` (fresnel, intersection de profondeur,
motif hexagonal ou Voronoi, jusqu'à 8 ondes d'impact), `Astra/Fx/Trail` (dégradé tête-queue et
érosion par bruit), `Astra/Fx/Distortion` (brume de chaleur et onde de choc sur la texture opaque),
`Astra/Fx/ParticleDissolve` (dissolve par particule via `Custom1.xy` et fondu de profondeur),
composants `AstraHitFlash`, `AstraDissolve` et `AstraShieldHits` partageant `AstraPropertyBlocks`,
scène de démonstration `Fx.unity` et scène galerie `FxGallery.unity`.

Licence : shaders, composants et contenu de démonstration Astra sous MIT (`LICENSES/LICENSE.txt`
dans le pack). Aucun asset tiers.

Prérequis : Unity 6000.4.0f1, Universal Render Pipeline 17.4+ et Input System 1.19+ (commandes de
la démo). Qualifié sur macOS ; le Hub ne modifie ni les packages ni les réglages de rendu.

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.shaders.fx` **0.1.3** (au lieu de 0.1.2) : release `shaders-fx-v0.1.3`, 161 fichiers, 202856 octets, SHA-256 `44f1e4812d4ca7e1971509adade417da3d35d254783169c1ff8ec3eb80f8a76e` ; dépendances de contenu (plages) : `astra.shaders.core` [0.1.2, 0.2.0).

Version **0.1.2** : la dépendance passe sur `astra.shaders.core` 0.1.1, sans autre changement.
Archive : `shaders-fx-v0.1.2`, 161 fichiers, 202538 octets,
SHA-256 `e2293c3c1c8c311b964f3cbec7fd28dbdca7ae6872242b709c23d5605e2bb7e6`.

Version **0.1.1** : scène galerie `FxGallery.unity` (**Tools > Astra > Shaders > Build Fx Gallery**) présentant une étagère par shader (sprite, bouclier, traînée, distorsion, particules) devant un mur rayé, avec un exemple étiqueté par réglage.
Archive : `shaders-fx-v0.1.1` (et `shaders-fx-v0.1.0`), toujours téléchargeables.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la conception et la validation sont
décrites dans le dépôt `AI_Testing_Sandbox`, `Documentation/Astra/ContentHub/Shaders/README.md` et
`Documentation/Astra/ShadersValidation.md`.
