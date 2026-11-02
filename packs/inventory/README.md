# Inventory

Trois entrées de catalogue : l'inventaire `astra.inventory` (catégorie `Gameplay`) et deux ponts
(catégorie `Bridges`) vers Quests et Dialogue.

## Catalogue `gameplay-v30` : première publication

Requiert le framework à partir du tag `framework-game-2026-11-02` (modèle Core :
`framework-core-2026-11-02`), garanti par le prérequis de capacité `astra-framework` [3.0.0, 4.0.0) :
le Hub refuse l'import sur un framework plus ancien avant toute copie.

- `astra.inventory` **1.0.0** : release `inventory-v1.0.0`, 112 fichiers, 78942 octets, SHA-256 `463be644331bff0e6bb87c0ce1b5fcd8a688f2aac78b0c016e0bb14df77dc854` ; dépendances de contenu (plages) : aucune.
- `astra.inventory.quests` **1.0.0** : release `inventory-quests-v1.0.0`, 35 fichiers, 26108 octets, SHA-256 `b2f6d98cb2f08295a26cbf08f939f40aaba2148f3929954238303c16bca96d82` ; dépendances de contenu (plages) : `astra.inventory` [1.0.0, 2.0.0), `astra.quests` [2.1.0, 3.0.0).
- `astra.inventory.dialogue` **1.0.0** : release `inventory-dialogue-v1.0.0`, 21 fichiers, 13643 octets, SHA-256 `3019bb6d19ebcb04e588da31b3706b89db36038d35837fa6b0f1106c4899c396` ; dépendances de contenu (plages) : `astra.inventory` [1.0.0, 2.0.0), `astra.dialogue` [0.1.5, 0.2.0).

## `astra.inventory`

Inventaire, équipement et fabrication pilotés par les données, pour n'importe quel jeu Astra.

- **Core** en C# pur (`noEngineReferences`) : piles, conteneur à limites de cases et de poids,
  équipement à slots typés avec échange atomique, recettes, tables de loot à graine, monnaie,
  effets d'utilisation ouverts (`IItemUseEffect`), instantanés. Toute opération réussit entièrement
  ou laisse l'inventaire intact.
- **Unity** : assets Item, Item Category, Equipment Slot, Crafting Recipe, Loot Table et Inventory
  Catalog (**Create > Astra > Inventory**) ; effets `[SerializeReference]` ; vues uGUI d'inventaire,
  d'équipement et de fabrication.
- **Astra** : module `inventory.module`, service `IInventoryService`, sauvegarde
  `astra.inventory.state`, valeurs de HUD, commandes `inventory.summary` et `inventory.clear`.
- **Éditeur et Aegis** : **Tools > Astra > Inventory > Validate Selected Catalog** ; règles
  `Astra.Inventory.DuplicateId` et `Astra.Inventory.RecipeValidity` (si `com.misterpxl.aegis` 1.x est
  installé).

Tout est identifiant porté par un asset : une nouvelle catégorie, un slot ou un effet s'ajoute sans
toucher au pack.

## `astra.inventory.quests`

Module `inventory.quests.bridge` : chaque changement d'inventaire lève un signal de quête
(`item_added`, `item_crafted`, `item_equipped`...), et un objet peut alimenter une stat. Objectifs
`Collect item`, `Craft recipe` et `Equip item` ; conditions `Has item` et `Has equipped item` ;
récompenses `Grant item` et `Grant loot table`.

## `astra.inventory.dialogue`

Conditions de dialogue `Has item`, `Has currency`, `Has equipped item` et `Can craft recipe` ;
actions `Give item`, `Take item`, `Modify currency` et `Roll loot table`.
`InventoryDialogueContextProvider` expose l'inventaire de l'application à un `DialogueRunner` et peut
envelopper le provider de Quests ↔ Dialogue sur le même PNJ.

Licence : code sous **MIT**, sans asset tiers. Prérequis qualifiés : **Unity 6000.4.0f1**,
**ugui 2.0.0**, **Valkyrie 2.1.0**. Qualification : consommateurs vierges avec dépendances les plus
récentes et minimales, parcours PlayMode de Quests (6/6) et de Dialogue (5/5).
