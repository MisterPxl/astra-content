# Inventory ↔ Dialogue 1.0.0

Pack public `astra.inventory.dialogue` **1.0.0** (catégorie `Bridges`) : le pont entre
[Inventory](../inventory/README.md) et les conversations d'[Astra Dialogue](../dialogue/README.md).
Il ne contient aucun contenu de jeu.

## Catalogue `gameplay-v30`

- `astra.inventory.dialogue` **1.0.0** : release `inventory-dialogue-v1.0.0`, 21 fichiers (+ `pack.json`),
  13561 octets, SHA-256 `9a30623182da6625f0cc209afa06757bffa49911dda048a6950c172eceb916ca` ;
  dépendances de contenu (plages) : `astra.inventory` [1.0.0, 2.0.0), `astra.dialogue` [0.1.5, 0.2.0).

## Contenu

- **Conditions** de dialogue : Possède un objet (Has item), Argent (Has currency), Équipé
  (Has equipped item), Peut fabriquer (Can craft recipe).
- **Actions** de dialogue : donner (Give item), prendre (Take item), modifier l'argent
  (Modify currency), tirer une table de loot (Roll loot table).
- **`InventoryDialogueContextProvider`** : provider Astra qui expose l'inventaire de l'application à
  un `DialogueRunner` ; chaînable avec un autre provider via `Inner`.

Mise en place : installer `astra.inventory` et `astra.dialogue`, puis poser le provider sur le PNJ
avec son `DialogueRunner`.

Licence : code sous **MIT**. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **ugui 2.0.0**, **Valkyrie 2.1.0**, framework Astra à
partir de 2.1.0 et assemblies `Astra.Framework.Core.App.Runtime`,
`Astra.Framework.Core.Initialization.Runtime` et `Astra.Framework.Core.Services.Runtime`.
Plateforme qualifiée : macOS. Qualification : 15 tests EditMode.

Archive publiée via GitHub Releases sous le tag `inventory-dialogue-v1.0.0`.
