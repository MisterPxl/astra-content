# Adventure ↔ Quests 1.0.0

Pack public `astra.adventure.quests` **1.0.0** (catégorie `Bridges`) : le pont entre
[Adventure](../adventure/README.md) et la progression de [Quests & Achievements](../quests/README.md).
Il ne contient aucun contenu de jeu.

## Catalogue `gameplay-v30`

- `astra.adventure.quests` **1.0.0** : release `adventure-quests-v1.0.0`, 20 fichiers (+ `pack.json`),
  13777 octets, SHA-256 `2f891b77a43bbd89d24df04998b8efbe339ed1dd669d0cbb806f09c1e97fa96e` ;
  dépendances de contenu (plages) : `astra.adventure` [2.0.2, 3.0.0), `astra.quests` [2.0.1, 3.0.0).

## Contenu

- **`AdventureQuestSignalZone`** : le héros entre dans une zone.
- **`AdventureQuestTargetReporter`** : le héros porte un coup (épée ou flèche).
- **`AdventureQuestRunObserver`** : la run se termine ou échoue.
- Chacun lève un signal et/ou alimente une stat de la progression, et expose ses usages à Aegis.

Mise en place : installer `astra.adventure` et `astra.quests`, puis poser les composants dans la
scène en les référençant au `ProgressionModule` de la composition.

Licence : code sous **MIT**. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **ugui 2.0.0**, **Valkyrie 2.1.0**, module physique Unity,
framework Astra à partir de 2.1.0 et assembly `Astra.Framework.Core.App.Runtime`. Plateforme
qualifiée : macOS. Qualification : 21 tests EditMode.

Archive publiée via GitHub Releases sous le tag `adventure-quests-v1.0.0`.
