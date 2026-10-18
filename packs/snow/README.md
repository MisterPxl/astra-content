# Snow

Pack public `astra.snow` pour Astra Content Hub. Neige stylisée pour URP : sol déformable
par les interacteurs (traces persistantes avec remplissage progressif, calculées en compute),
couverture de neige sur n'importe quel objet selon la normale, scintillement et épaisseur
réglables, démo Snowfield.

Licence : code, shaders et contenu de démonstration Astra sous MIT
(`LICENSES/LICENSE.txt` dans le pack). Aucun asset tiers.

Prérequis : Unity 6000.4.0f1, Universal Render Pipeline 17.4+ et le module Physics.
Qualifié sur macOS ; le Hub ne modifie ni les packages ni les réglages de rendu.

Version **0.2.0** : les passes d'ombre et de profondeur utilisent les fragments partagés de `astra.shaders.core` 0.1.0, que le Hub importe dans la même transaction. Le motif du scintillement change (hash du core) et DepthNormals gère les normales octaédriques.
Archive : `snow-v0.2.0`, 56 fichiers, 248762 octets,
SHA-256 `c664a2ad61bad24090f9f6b52d1231d5bc894ec9bdd0b7b09e39f5441473d3b0`.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Snow/README.md`.
