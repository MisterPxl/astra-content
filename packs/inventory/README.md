# Inventory, Equipment & Crafting 1.0.0

Pack public `astra.inventory` **1.0.0** (catégorie `Gameplay`) : un inventaire data-driven pour
Astra, avec équipement et artisanat. Il ne contient aucun contenu de jeu.

## Catalogue `gameplay-v30`

- `astra.inventory` **1.0.0** : release `inventory-v1.0.0`, 112 fichiers (111 + `pack.json`), 78845 octets,
  SHA-256 `c0b3b2a6df80be48798b00818311ff08d05121489c841e75320dd9bc252cba85`. Aucune dépendance de contenu.

## Contenu

- **Core C# pur et déterministe** : piles avec limites de slots et de poids, conteneurs, ajout
  atomique (échec sans effet partiel, ou `AddUpTo` pour garder ce qui tient).
- **Équipement par slots typés**, avec échange atomique.
- **Effets d'utilisation ouverts** : `[SerializeReference] IItemUseEffectAuthoring`, pour ajouter un
  effet sans toucher au code partagé.
- **Tables de loot pondérées** déterministes (graine explicite) et **recettes de craft** atomiques.
- **Assets Unity ouverts** (définitions d'objets, recettes, tables) éditables dans l'Inspector.
- **Module Astra** : sauvegarde (`astra.inventory.state`), valeurs de HUD, vues UGUI, commandes de
  debug.
- **Règles Aegis** : validité des identifiants et des recettes.

Mise en place : importer `astra.inventory` depuis le Content Hub, ajouter le module d'inventaire à la
composition Astra, puis créer vos définitions d'objets, recettes et tables de loot. Les ponts
[Inventory ↔ Quests](../inventory-quests/README.md) et
[Inventory ↔ Dialogue](../inventory-dialogue/README.md) relient l'inventaire à la progression et aux
conversations.

Licence : code sous **MIT**. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, URP, **ugui 2.0.0**, **Valkyrie 2.1.0**
(`com.misterpxl.valkyrie`) et le framework Astra à partir de 2.1.0, avec les assemblies
`Astra.Framework.Core.Save.Runtime`, `Astra.Framework.Core.UI.Runtime`,
`Astra.Framework.Game.HUD.Runtime` et `Astra.Framework.Game.Flow.Runtime`. Plateforme qualifiée :
macOS.

Qualification : 66 tests EditMode (Core 39, module Astra 22, Aegis 5), import et vérification des assets sur un
consommateur vierge (112 fichiers, GUID conservés).

Archive publiée via GitHub Releases sous le tag `inventory-v1.0.0`.
