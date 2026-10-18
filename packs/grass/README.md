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

Version **0.2.1** : rendu corrigé et allégé. Les buffers des touffes visibles grandissent quand on peint au-delà de leur capacité (le shader écrivait hors limites), plus aucune allocation par caméra et par image, la carte des traces n'avance qu'une fois par image depuis la première caméra de jeu, et seules les caméras de jeu et la vue Scene dessinent l'herbe. `GrassInteractionSystem.SelectNearest` remplit une liste fournie (l'ancienne surcharge renvoyant un tableau est retirée).
Archive : `grass-v0.2.1`, 103 fichiers, 140832 octets,
SHA-256 `add66fd78e693a386a0c7ae963cecfab4880caeae8ba74bd6599a4aa2dde86d5`.

Version **0.2.0** : les passes d'ombre et de profondeur utilisent les fragments partagés de `astra.shaders.core` 0.1.0, que le Hub importe dans la même transaction. La scène de démo Meadow est régénérée (profil d'herbe et profil de qualité présents) et Build Feature Meadow remplace `MeadowFieldData.asset` au lieu d'en créer une copie.
Archive : `grass-v0.2.0`, 103 fichiers, 139359 octets,
SHA-256 `35a918da713f9c788562b7a1106e9f458855fe12b6864805e43314becb7275e9`.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Grass/README.md`.
