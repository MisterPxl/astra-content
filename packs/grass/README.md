# Grass

Pack public `astra.grass` pour Astra Content Hub. Herbe stylisée en touffes pour URP :
peinture au pinceau sur n'importe quel mesh ou Terrain, texture et atlas de brins
remplaçables, color shading, vent avec rafales, interacteurs qui couchent les brins et
laissent des trails persistants, correction de perspective pour la vue de dessus, rendu
GPU indirect avec culling compute et niveaux de détail, repli sans compute.

Licence : code, shaders et contenu de démonstration Astra sous MIT
(`LICENSES/LICENSE.txt` dans le pack). Aucun asset tiers.

Prérequis : Unity 6000.4.0f1, Universal Render Pipeline 17.4+ et le module Physics.
Qualifié sur macOS ; le Hub ne modifie ni les packages ni les réglages de rendu.

Version **0.1.2** : les menus de l'éditeur trouvent le pack là où le Hub l'installe (`Assets/AstraContent/astra.grass`) et n'écrivent plus dans le pack installé ni dans `Assets/_Project/Features` ; les assets générés vont sous `Assets/GrassGenerated` ou le dossier de la démo.
Archive : `grass-v0.1.2`, 101 fichiers, 137320 octets,
SHA-256 `009edc10331d7f9060d800fcc1387c7785a0ed31d129e9eb757bac6299407c4a`.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Grass/README.md`.
