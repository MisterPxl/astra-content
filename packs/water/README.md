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

Version **0.2.1** : la dépendance passe sur `astra.shaders.core` 0.1.1, sans autre changement.
Archive : `water-v0.2.1`, 64 fichiers, 428422 octets,
SHA-256 `7dd707b65abe5f5e15d784c481063157772d48c149cb32f04f10881022c3e755`.

Version **0.2.0** : le bruit de la surface et de l'écume vient de `astra.shaders.core` 0.1.0, que le Hub importe dans la même transaction ; le motif des normales et de l'écume change.
Archive : `water-v0.2.0`, 64 fichiers, 428353 octets,
SHA-256 `a708325b1c695391e428088d2943f483620d60a70e4827f50aad8560d4d32283`.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Water/README.md`.
