# Inventory ↔ Quests 1.0.0

Pack public `astra.inventory.quests` **1.0.0** (catégorie `Bridges`) : le pont entre
[Inventory](../inventory/README.md) et la progression de [Quests & Achievements](../quests/README.md).
Il ne contient aucun contenu de jeu.

## Catalogue `gameplay-v30`

- `astra.inventory.quests` **1.0.0** : release `inventory-quests-v1.0.0`, 35 fichiers (+ `pack.json`),
  26028 octets, SHA-256 `61d1604cfb33115156a4f2c40bdcd55ff2e92f6c366426db546053c73293b041` ;
  dépendances de contenu (plages) : `astra.inventory` [1.0.0, 2.0.0), `astra.quests` [2.0.1, 3.0.0).

## Contenu

- **Objectifs de quête** : Collecter un objet (acquis ou possédé), Fabriquer une recette, Équiper
  un objet.
- **Conditions** : Possède un objet, Objet équipé.
- **Récompenses** : Donner un objet, Donner une table de loot (graine déterministe).
- **`InventoryProgressionObserver`** : transforme chaque changement d'inventaire en signaux de quête
  (clés code) et, en option, en stats par objet.
- **Module Astra** `inventory.quests.bridge` et son étape d'initialisation, qui relient
  `IInventoryService` à `IProgression`.

Mise en place : installer `astra.inventory` et `astra.quests` (le Hub propose le pont quand les deux
sont présents), puis ajouter le module `inventory.quests.bridge` à la composition.

Licence : code sous **MIT**. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **ugui 2.0.0**, **Valkyrie 2.1.0**, framework Astra à
partir de 2.1.0 et assemblies `Astra.Framework.Core.App.Runtime`,
`Astra.Framework.Core.Initialization.Runtime` et `Astra.Framework.Core.Services.Runtime`.
Plateforme qualifiée : macOS. Qualification : 26 tests EditMode.

Archive publiée via GitHub Releases sous le tag `inventory-quests-v1.0.0`.
