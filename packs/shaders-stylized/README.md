# Shaders Stylized

Pack public `astra.shaders.stylized` pour Astra Content Hub (catégorie `Shaders`). Shaders toon
pour URP (Forward et Forward+) : `Astra/Stylized/Toon` et `Astra/Stylized/ToonTriplanar` (sans UV,
en espace monde ou objet), éclairage en deux ou trois bandes ou par texture de rampe, ombres
teintées, lumières additionnelles, rim, spéculaire en bande, contour par coque inversée (largeur en
mètres ou en pixels, outil **Tools > Astra > Shaders > Bake Outline Normals** pour cuire des
normales lissées dans UV3 sur les maillages à arêtes vives), propriétés de flash et de dissolve
compatibles avec [Shaders FX](../shaders-fx/README.md), scène de démonstration jour/nuit
`Stylized.unity` et scène galerie `StylizedGallery.unity`.

Licence : shaders, outils et contenu de démonstration Astra sous MIT (`LICENSES/LICENSE.txt` dans
le pack). Aucun asset tiers.

Prérequis : Unity 6000.4.0f1, Universal Render Pipeline 17.4+ et Input System 1.19+ (commandes de
la démo). Qualifié sur macOS ; le Hub ne modifie ni les packages ni les réglages de rendu.

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.shaders.stylized` **0.1.3** (au lieu de 0.1.2) : release `shaders-stylized-v0.1.3`, 140 fichiers, 135635 octets, SHA-256 `42351c5c3135a16fc32ef27807a074374b27d480eef9c18843d2fd88e0027d10` ; dépendances de contenu (plages) : `astra.shaders.core` [0.1.2, 0.2.0).

Version **0.1.2** : la dépendance passe sur `astra.shaders.core` 0.1.1, sans autre changement.
Archive : `shaders-stylized-v0.1.2`, 140 fichiers, 135324 octets,
SHA-256 `16d34b3baabfcdc49d24f2e56e13091c6d5bf56aa9c4ed8e4c5fbca3d8039aaa`.

Version **0.1.1** : scène galerie `StylizedGallery.unity` (**Tools > Astra > Shaders > Build Stylized Gallery**) présentant une étagère par thème (bandes, ombre et reflets, contours, triplanaire, effets) avec un objet étiqueté par réglage.
Archive : `shaders-stylized-v0.1.1` (et `shaders-stylized-v0.1.0`), toujours téléchargeables.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la conception et la validation sont
décrites dans le dépôt `AI_Testing_Sandbox`, `Documentation/Astra/ContentHub/Shaders/README.md` et
`Documentation/Astra/ShadersValidation.md`.
