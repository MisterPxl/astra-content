# Adventure

Deux entrées de catalogue pour un jeu d'action-aventure à la troisième personne.

- **`astra.adventure` 1.1.0** (catégorie `Gameplay`) : contrôleur action-aventure, Input System et
  démo humanoïde animée avec caméra, escalade, épée et arc (contenu de la 1.0.0), plus l'assembly
  `Adventure.Astra`, pont vers le framework Astra (caméra, entrées Gameplay, santé en quarts de
  cœur, zones de dégâts et d'arrivée, fin de run), le rig orbital extrait de la caméra de la démo
  et des ajouts non cassants (`IsExhausted`, `HitLanded`, `AdventureArrow.Landed`,
  `AdventureOrbitRig.Pivot`). La 1.1.0 requiert le framework Game Flow Foundation
  (`Game.FlowPresentation`) : le Hub refuse l'import sur une copie plus ancienne.
  `astra.adventure` 1.0.0 reste disponible pour un usage autonome, hors framework.
- **`astra.template.adventure` 1.0.0** (catégorie `Templates`) : template de genre avec démarrage,
  menu puis un parcours linéaire (épée, cibles, ronces, escalade, arc, sanctuaire) et un HUD
  inspiré de Breath of the Wild (cœurs, roue d'endurance, réticule d'arc), avec un
  `composition.json` (identifiants de module `astra.game.*` et `adventure.module`). Il dépend
  exactement de `astra.adventure` 1.1.0, que le Hub importe dans la même transaction. Le guide
  d'extension est livré dans le pack (`README.md` en anglais, `README.fr.md` en français), avec
  ses limites actuelles.

Licences : code et démo Astra sous **MIT** ; modèles, textures et animations Quaternius sous
**CC0-1.0** avec notices incluses dans le pack (le template réutilise le héros du pack
`astra.adventure`).

Prérequis qualifiés : **Unity 6000.4.0f1**, **URP 17.4.0**, **Input System 1.19.0** (backend
actif), **ugui 2.0.0**, et pour la 1.1.0 et le template les assemblies du framework Astra
`Astra.Framework.Game.Characters.Runtime`, `Game.HUD.Runtime` et `Game.FlowPresentation.Runtime`.
Plateforme déclarée : macOS.

Après l'import du template, appliquer
`Assets/AstraContent/astra.template.adventure/composition.json` avec Astra Setup (action
« Apply composition with Setup » de la fiche du Hub).

Archives publiées via GitHub Releases, tags `adventure-v1.1.0` et `template-adventure-v1.0.0`
(`adventure-v1.0.0` reste disponible). Le guide complet du pack est
[PackReadme.md](PackReadme.md).
