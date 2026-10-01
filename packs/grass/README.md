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

Archive publiée via GitHub Releases sous le tag `grass-v0.1.0` : 97 fichiers, 132 110 octets,
SHA-256 `21633d3e9fa8fb46aa9ef9ff188fb749f4ab0b94c3613025416cc463c704b993`. Export
reproductible, import et vérification dans un consommateur URP vierge (scripts, matériaux,
shaders et scène `Demo/Generated/Meadow.unity` sans référence manquante).

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Grass/README.md`.
