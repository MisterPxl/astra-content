# Astra Water

Pack Content Hub **astra.water** : eau stylisée pour URP, compagnon visuel d'Astra Grass et Astra Snow, sans dépendance vers eux.

## Ce que fait le shader `Astra/Water`

- Vagues de **Gerstner** (jusqu'à 4) déplacées dans le vertex shader, normales analytiques. Les mêmes formules tournent côté CPU pour la flottaison.
- Couleur par **profondeur** (peu profond vers profond) et **réfraction** de la scène, via les textures profondeur et opaque d'URP.
- **Écume** de rivage (différence de profondeur), de crête (hauteur de vague) et d'ondulation, masquée par un bruit animé.
- **Ondulations** propagées : simulation d'équation d'onde compute sur la zone du plan d'eau, où les objets porteurs d'un `WaterInteractor` créent des anneaux proportionnels à leur vitesse.
- Fresnel avec réflexion d'environnement URP, reflet solaire, normales de détail procédurales, ombres reçues, brouillard.

## Composants

- `WaterSurface` : sur le renderer du plan d'eau. Il porte les vagues, la simulation d'ondulations et pousse tout au renderer par `MaterialPropertyBlock`, donc plusieurs plans d'eau peuvent coexister. `GetHeight(worldPos)` donne la hauteur de vague pour le gameplay.
- `WaterInteractor` : objet avec collider. Rayon déduit des bounds ; la force suit la vitesse (Rigidbody ou delta de position). Il s'enregistre seul dans `WaterInteractionSystem`.
- `WaterFloater` : flottaison multi-points sur un Rigidbody, pour caisses, tonneaux ou barques.
- `WaterGridMeshGenerator` : grille pour le plan d'eau et fond de lac en cuvette pour la démo.

## Réglages URP nécessaires

Le shader a besoin de **Depth Texture** et **Opaque Texture** sur l'asset URP actif. Le pack ne modifie jamais ces réglages : l'inspecteur du `WaterSurface` affiche un avertissement et un bouton explicite si l'un des deux manque. Sans eux, l'eau reste visible mais sans couleur de profondeur, écume de rivage ni réfraction.

## Démarrage rapide

1. **Tools > Astra > Water > Build Feature Lake** — scène `Demo/Generated/Lake.unity`.
2. Play : **WASD** déplace le marcheur, **Espace** saute (éclaboussure), **Tab** bascule la vue de dessus, **R** calme la surface.
3. **Tools > Astra > Water > Create Water Surface** ajoute un plan d'eau prêt à l'emploi dans la scène active.

Les scènes de jeu doivent vivre hors du dossier du pack (**Create Water Demo** en fait une copie).

## Prérequis

- Unity **6000.4.0f1**, **Universal Render Pipeline** 17.4+.
- Compute shaders pour les ondulations (sans compute, les vagues et le rendu fonctionnent, sans anneaux).
