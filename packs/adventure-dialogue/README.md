# Adventure ↔ Dialogue 1.0.0

Pack public `astra.adventure.dialogue` **1.0.0** (catégorie `Bridges`) : le pont entre
[Adventure](../adventure/README.md) et [Astra Dialogue](../dialogue/README.md). Il ne contient aucun
contenu de jeu.

## Catalogue `gameplay-v30`

- `astra.adventure.dialogue` **1.0.0** : release `adventure-dialogue-v1.0.0`, 16 fichiers (+ `pack.json`),
  11799 octets, SHA-256 `34a74fce1c4476b3f1021902f14d28be9c842d96924b613a8bd4a63b4cb2a48d` ;
  dépendances de contenu (plages) : `astra.adventure` [2.0.2, 3.0.0), `astra.dialogue` [0.1.5, 0.2.0).

## Contenu

- **`AdventureDialogueZone`** : lance une conversation à l'entrée du héros.
- **`AdventureDialogueInteractable`** : lance une conversation par `Interact(AdventureActor)`, à
  portée d'interaction.
- Pendant la conversation, le héros est figé et le curseur libéré ; ils sont restaurés à la fin, à
  l'annulation ou à l'échec. Rien n'est rendu si la run s'est terminée entre-temps.

Mise en place : installer `astra.adventure` et `astra.dialogue`, puis poser une zone ou un objet
interactif avec un `DialogueRunner` dans la scène.

Licence : code sous **MIT**. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **ugui 2.0.0**, module physique Unity et framework Astra
à partir de 2.1.0. Plateforme qualifiée : macOS. Qualification : 15 tests EditMode.

Archive publiée via GitHub Releases sous le tag `adventure-dialogue-v1.0.0`.
