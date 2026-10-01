# Astra Snow

Pack Content Hub **astra.snow** : neige stylisée pour URP (desktop et mobile), compagnon visuel d'Astra Grass mais sans dépendance vers lui.

## Deux shaders

| Shader | Usage |
| --- | --- |
| `Astra/Snow Ground` | Sol de neige déformable. Les objets porteurs d'un `SnowInteractor` laissent des traces qui se comblent lentement. Ombres bleutées, scintillement, rebord clair des empreintes. |
| `Astra/Snow Coverage` | Neige qui recouvre les props selon la normale (monde ou objet), avec épaisseur, bord bruité et le même éclairage que le sol. |

## Composants

- `SnowSurface` : à poser sur le renderer du sol. Il possède la carte de déformation (résolution, profondeur max, vitesse de comblement) et publie les globales `_AstraSnowDeformMap` / `_AstraSnowDeformParams`. La zone couverte est celle du renderer, plus une marge.
- `SnowInteractor` : à poser sur tout objet avec collider. Rayon déduit des bounds, surchargeable. Il s'enregistre seul dans `SnowInteractionSystem`.
- Le sol doit avoir assez de sommets pour la déformation : `SnowGridMeshGenerator` en fournit un, ou utiliser un mesh subdivisé.

## Démarrage rapide

1. **Tools > Astra > Snow > Build Feature Snowfield** — scène `Demo/Generated/Snowfield.unity`.
2. Play : **WASD** déplace le marcheur, **Tab** bascule la vue de dessus, **R** remet la neige à neuf.
3. **Tools > Astra > Snow > Create Snow Surface** ajoute un sol prêt à l'emploi dans la scène active.

Les scènes de jeu doivent vivre hors du dossier du pack (**Create Snow Demo** en fait une copie).

## Prérequis

- Unity **6000.4.0f1**, **Universal Render Pipeline** 17.4+.
- Compute shaders pour la déformation (sans compute, le sol reste lisse et les shaders fonctionnent).

Prérequis démo : **Input System 1.19+**. Commandes compatibles avec Input System, Legacy et Both.
