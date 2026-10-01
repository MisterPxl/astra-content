# Water

Pack public `astra.water` pour Astra Content Hub. Eau stylisée pour URP : vagues de Gerstner
partagées CPU/GPU, couleur par profondeur et réfraction de la scène, écume de rivage, de
crête et d'ondulation, ondulations propagées en compute par les interacteurs, Fresnel et
réflexion d'environnement, flottaison multi-points, démo Lake.

Licence : code, shaders et contenu de démonstration Astra sous MIT
(`LICENSES/LICENSE.txt` dans le pack). Aucun asset tiers.

Prérequis : Unity 6000.4.0f1, Universal Render Pipeline 17.4+ et le module Physics.
Le shader attend **Depth Texture** et **Opaque Texture** sur l'asset URP actif ; l'inspecteur
du `WaterSurface` le signale et propose de les activer, sans le faire seul. Qualifié sur
macOS ; le Hub ne modifie ni les packages ni les réglages de rendu.

Version **0.1.1** : démo compatible Input System, Legacy et Both. Input System 1.19+ est un prérequis explicite.
Archive : `water-v0.1.1`, 60 fichiers, 424833 octets,
SHA-256 `1cc485eb30b02ec1b751ee777477b5406485cfedd25fe3c761f0bee451d82eb1`.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Water/README.md`.
