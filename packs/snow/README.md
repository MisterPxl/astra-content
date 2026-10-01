# Snow

Pack public `astra.snow` pour Astra Content Hub. Neige stylisée pour URP : sol déformable
par les interacteurs (traces persistantes avec remplissage progressif, calculées en compute),
couverture de neige sur n'importe quel objet selon la normale, scintillement et épaisseur
réglables, démo Snowfield.

Licence : code, shaders et contenu de démonstration Astra sous MIT
(`LICENSES/LICENSE.txt` dans le pack). Aucun asset tiers.

Prérequis : Unity 6000.4.0f1, Universal Render Pipeline 17.4+ et le module Physics.
Qualifié sur macOS ; le Hub ne modifie ni les packages ni les réglages de rendu.

Archive publiée via GitHub Releases sous le tag `snow-v0.1.0` : 52 fichiers, 244 719 octets,
SHA-256 `89529431e84bf3e3575bba9e72434f72f6e0665846790a560bcdbfca9a2d838f`. Export
reproductible, import et vérification dans un consommateur URP vierge (scripts, matériaux,
shaders et scène `Demo/Generated/Snowfield.unity` sans référence manquante).

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Snow/README.md`.
