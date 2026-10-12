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

Version **0.1.2** : les menus de l'éditeur trouvent le pack là où le Hub l'installe (`Assets/AstraContent/astra.water`) et n'écrivent plus dans le pack installé ni dans `Assets/_Project/Features` ; les assets générés vont sous `Assets/WaterGenerated` ou le dossier de la démo.
Archive : `water-v0.1.2`, 64 fichiers, 428159 octets,
SHA-256 `99aad3c57b18d1a75f1abb1c7aebed35751fc03629c5128cf6c6233db477e44c`.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Water/README.md`.
