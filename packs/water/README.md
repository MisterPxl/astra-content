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

Archive publiée via GitHub Releases sous le tag `water-v0.1.0` : 60 fichiers, 424 251 octets,
SHA-256 `557ea68384c82a889faecee9deaa1bbab7cf8036158280209fc854c3b9b6563b`. Export
reproductible, import et vérification dans un consommateur URP vierge (scripts, matériaux,
shaders et scène `Demo/Generated/Lake.unity` sans référence manquante).

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Water/README.md`.
