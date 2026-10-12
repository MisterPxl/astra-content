# Snow

Pack public `astra.snow` pour Astra Content Hub. Neige stylisée pour URP : sol déformable
par les interacteurs (traces persistantes avec remplissage progressif, calculées en compute),
couverture de neige sur n'importe quel objet selon la normale, scintillement et épaisseur
réglables, démo Snowfield.

Licence : code, shaders et contenu de démonstration Astra sous MIT
(`LICENSES/LICENSE.txt` dans le pack). Aucun asset tiers.

Prérequis : Unity 6000.4.0f1, Universal Render Pipeline 17.4+ et le module Physics.
Qualifié sur macOS ; le Hub ne modifie ni les packages ni les réglages de rendu.

Version **0.1.2** : les menus de l'éditeur trouvent le pack là où le Hub l'installe (`Assets/AstraContent/astra.snow`) et n'écrivent plus dans le pack installé ni dans `Assets/_Project/Features` ; les assets générés vont sous `Assets/SnowGenerated` ou le dossier de la démo.
Archive : `snow-v0.1.2`, 56 fichiers, 248523 octets,
SHA-256 `613baeeda293aa7ed50ad4d783e2ccb6593fb60086ba7f0d2f099bf474080a06`.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Snow/README.md`.
