# Adventure

Deux entrées de catalogue pour un jeu d'action-aventure à la troisième personne, et deux ponts
(catégorie `Bridges`) vers Dialogue et Quests.

## Catalogue `gameplay-v30` : framework 3.0.0

Requiert le framework à partir du tag `framework-game-2026-11-02` (modèle Core :
`framework-core-2026-11-02`), garanti par le prérequis de capacité `astra-framework` [3.0.0, 4.0.0) :
le Hub refuse l'import sur un framework 2.x, pour lequel la 2.0.2 reste listée. Les retours de gameplay
passent par le package Pulse (`com.misterpxl.pulse` [1.0.0, 2.0.0), tag `v1.0.0`), à déclarer dans le
manifeste du projet.

- `astra.adventure` **2.1.0** : release `adventure-v2.1.0`, 223 fichiers, 16038633 octets, SHA-256 `a65f07d5ee8a152ea5263205c0a37a19058e699b9cfe3fd3f5b9e3439ae6ab64` ; dépendances de contenu (plages) : aucune.
- `astra.template.adventure` **2.1.0** : release `template-adventure-v2.1.0`, 60 fichiers, 129419 octets, SHA-256 `45afccaf500eb456839d99a211e6a07af1f09605157183d0e63ab18226dd9ec5` ; dépendances de contenu (plages) : `astra.adventure` [2.1.0, 3.0.0).
- `astra.adventure.dialogue` **1.0.0** (nouveau, `Bridges`) : release `adventure-dialogue-v1.0.0`, 16 fichiers, 11877 octets, SHA-256 `72e33eb17a2e13ceed5a11698aaa84f53fd3610c606a05f2340fae9d6967c5b8` ; dépendances de contenu (plages) : `astra.adventure` [2.1.0, 3.0.0), `astra.dialogue` [0.1.5, 0.2.0).
- `astra.adventure.quests` **1.0.0** (nouveau, `Bridges`) : release `adventure-quests-v1.0.0`, 20 fichiers, 13853 octets, SHA-256 `4ad30fe64b3ace2db8a5ec5c39601b3b6ec3ceb6bdd3c09e80e69b1cf1c10f47` ; dépendances de contenu (plages) : `astra.adventure` [2.1.0, 3.0.0), `astra.quests` [2.1.0, 3.0.0).

Le pont vers l'IA, `astra.adventure.ai`, est décrit sur la page [AI](../ai/README.md).

- **`astra.adventure.dialogue`** : une zone de déclenchement (`AdventureDialogueZone`, option `Once`)
  ou un objet interactif (`AdventureDialogueInteractable`, à portée d'interaction du héros) lance une
  conversation d'un `DialogueRunner`. Pendant la conversation, le héros est figé et le curseur libéré ;
  à la fin (complétée, annulée ou en échec), contrôle et curseur reviennent à leur état d'avant. Une
  référence manquante est une erreur explicite.
- **`astra.adventure.quests`** : `AdventureQuestSignalZone` (entrée du héros dans un trigger),
  `AdventureQuestTargetReporter` (coups portés, à l'épée ou à l'arc) et `AdventureQuestRunObserver`
  (fin de run réussie ou échouée) lèvent un signal et/ou alimentent une stat de la progression. Les
  composants sont visibles par les règles Aegis de Quests (signal non orphelin, stat alimentée).

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.adventure` **2.0.2** (au lieu de 2.0.1) : release `adventure-v2.0.2`, 223 fichiers, 16038244 octets, SHA-256 `01b32f7be9087c2463caa84fcfca22471c5351a597d6a49c2f68a49ef7f9684a` ; dépendances de contenu (plages) : aucune.
- `astra.template.adventure` **2.0.2** (au lieu de 2.0.1) : release `template-adventure-v2.0.2`, 60 fichiers, 129303 octets, SHA-256 `f12e9fe61dfa864b97f3841f680604794cfcc4af322796c21d9e4d55d0c5bf1e` ; dépendances de contenu (plages) : `astra.adventure` [2.0.2, 3.0.0).

- **`astra.adventure` 2.0.2** (catégorie `Gameplay`) : contrôleur action-aventure, Input System et
  démo humanoïde animée avec caméra, escalade, épée et arc (contenu de la 1.0.0), plus l'assembly
  `Adventure.Astra`, pont vers le framework Astra (caméra, entrées Gameplay, santé en quarts de
  cœur, zones de dégâts et d'arrivée, fin de run), le rig orbital extrait de la caméra de la démo
  et des ajouts non cassants (`IsExhausted`, `HitLanded`, `AdventureArrow.Landed`,
  `AdventureOrbitRig.Pivot`). La 2.0.0 publie les valeurs de HUD (`AdventureHudValuesAsset` : santé en quarts de cœur,
  flèches, arc), exigées par `AdventureModule`, et retire `_bowGroup`, `_arrowCount` et
  `BowVisible` de `AdventureCombatElement`. La 2.0.1 fait référencer les images Fill et Flash
  par un composant `AdventureHeartCell` du modèle de cœur, au lieu de les chercher par nom
  d'enfant. La 1.2.0 passe le HUD au HUD typé : le widget dérive de
  `HudWidgetView`, s'ajoute par `IGameHudService.Add` et s'affiche par `Show<T>` / `Hide<T>`
  (clé texte retirée). Elle requiert le framework Game à partir du tag
  `framework-game-2026-10-15` : sur un framework plus ancien, l'import ne compile pas. La 1.1.0
  avait ajouté `Adventure.Astra` et requiert le framework Game Flow Foundation
  (`Game.FlowPresentation`) : le Hub refuse l'import sur une copie plus ancienne.
  `astra.adventure` 1.0.0 reste disponible pour un usage autonome, hors framework.
- **`astra.template.adventure` 2.0.2** (catégorie `Templates`) : template de genre avec démarrage,
  menu puis un parcours linéaire (épée, cibles, ronces, escalade, arc, sanctuaire) et un HUD
  inspiré de Breath of the Wild (cœurs, roue d'endurance, réticule d'arc), avec un
  `composition.json` (identifiants de module `astra.game.*` et `adventure.module`). Il dépend
  de `astra.adventure` dans la plage [2.0.2, 3.0.0), que le Hub importe dans la même transaction. Le guide
  d'extension est livré dans le pack (`README.md` en anglais, `README.fr.md` en français), avec
  ses limites actuelles.

Licences : code et démo Astra sous **MIT** ; modèles, textures et animations Quaternius sous
**CC0-1.0** avec notices incluses dans le pack (le template réutilise le héros du pack
`astra.adventure`).

Prérequis qualifiés : **Unity 6000.4.0f1**, **URP 17.4.0**, **Input System 1.19.0** (backend
actif), **ugui 2.0.0**, et pour la 1.1.0, la 1.2.0 et le template les assemblies du framework Astra
`Astra.Framework.Game.Characters.Runtime`, `Game.HUD.Runtime` et `Game.FlowPresentation.Runtime`.
Plateforme déclarée : macOS.

Après l'import du template, appliquer
`Assets/AstraContent/astra.template.adventure/composition.json` avec Astra Setup (action
« Apply composition with Setup » de la fiche du Hub).

Archives publiées via GitHub Releases, tags `adventure-v2.0.1` et `template-adventure-v2.0.1`
(`adventure-v1.2.0`, `template-adventure-v1.1.0`, `adventure-v1.0.0`, `adventure-v1.1.0` et `template-adventure-v1.0.0` restent disponibles). Le guide complet du pack est
[PackReadme.md](PackReadme.md).
