# Shaders UI

Pack public `astra.shaders.ui` pour Astra Content Hub (catégorie `Shaders`). Shaders et composants
`Graphic` pour uGUI dont les paramètres passent par les UV du maillage afin de regrouper des
centaines d'éléments dans un seul draw call : `AstraShape` (`Astra/UI/Shape`, rectangle SDF avec
rayon par coin, bordure, dégradé linéaire ou radial et ombre portée), `AstraRing`
(`Astra/UI/Ring`, jauge circulaire continue ou segmentée avec piste de fond), `AstraFoilTilt`
(`Astra/UI/Foil`, carte holographique qui suit le pointeur) et `AstraUIDissolve`
(`Astra/UI/Dissolve`, dissolution d'image ou de texte avec bord brûlant et désactivation des
clics). Compatibles `Mask`, `RectMask2D` et `CanvasGroup`, avec scène de démonstration `Ui.unity`
et scène galerie `UiGallery.unity`.

Licence : shaders, composants et contenu de démonstration Astra sous MIT (`LICENSES/LICENSE.txt`
dans le pack). Aucun asset tiers.

Prérequis : Unity 6000.4.0f1, Universal Render Pipeline 17.4+, uGUI 2.0+ et Input System 1.19+
(commandes de la démo). Qualifié sur macOS ; le Hub ne modifie ni les packages ni les réglages de
rendu.

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.shaders.ui` **0.1.3** (au lieu de 0.1.2) : release `shaders-ui-v0.1.3`, 86 fichiers, 93266 octets, SHA-256 `8b2554955e83992e8d5e21778aa5613f8c5eee502776ec1cb04b385de35a9193` ; dépendances de contenu (plages) : `astra.shaders.core` [0.1.2, 0.2.0).

Version **0.1.2** : la dépendance passe sur `astra.shaders.core` 0.1.1, sans autre changement.
Archive : `shaders-ui-v0.1.2`, 86 fichiers, 92969 octets,
SHA-256 `2c95a44540b790400c14e2bf9c8c753ae103c26d43f7b253e0f07c8f655bb021`.

Version **0.1.1** : scène galerie `UiGallery.unity` (**Tools > Astra > Shaders > Build UI Gallery**) présentant une rangée par thème (formes, dégradés, anneaux, foil, dissolve et découpe) avec un élément étiqueté par réglage.
Archive : `shaders-ui-v0.1.1` (et `shaders-ui-v0.1.0`), toujours téléchargeables.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la conception et la validation sont
décrites dans le dépôt `AI_Testing_Sandbox`, `Documentation/Astra/ContentHub/Shaders/README.md` et
`Documentation/Astra/ShadersValidation.md`.
