# Quests & Achievements

Pack public `astra.quests` **1.1.0** (catégorie `Gameplay`) : quêtes et succès pilotés par les
données, pour n'importe quel jeu Astra. Le contenu est fait de ScriptableObjects ; le jeu lève
des signaux, remonte des stats et peut remplacer les vues par défaut.

- **`Quests.Core`** : C# pur, sans Unity. Signaux, stats, conditions, objectifs, règles d'échec,
  politiques de répétition, récompenses, services de quêtes et de succès, quêtes chronométrées et
  quotidiennes, paliers, état de sauvegarde.
- **`Quests.Unity`** : assets de définition, nœuds d'authoring `[SerializeReference]` choisis dans
  un menu (un nouveau contenu ne modifie aucun code partagé), `ProgressCatalogAsset`, `QuestGiver`,
  `SignalEmitter`, presenters et contrats de vues.
- **`Quests.Astra`** : modules `quests.progression`, `quests.quests` et `quests.achievements`
  (sauvegardes slot et profil, pause des chronomètres hors gameplay, localisation, popups journal
  et galerie, widgets HUD de suivi et de notification, plateformes de succès remplaçables).
- **`Quests.Editor`** : Progression Browser (**Tools > Astra > Quests**), et règles **Aegis**
  (compilées seulement si `com.misterpxl.aegis` 1.x est installé) : quête inatteignable, signal
  orphelin, ids en double, cycles de prérequis, clés de localisation manquantes.
- **`Demo/`** : écran de démonstration (module `quests.demo`) à ajouter à la main dans la
  composition ; à supprimer avant de livrer.

La 1.1.0 ajoute les deux règles Aegis « Quête inatteignable » et « Signal orphelin », et passe le
tracker et le toast d'achievement au HUD typé (le widget dérive de `HudWidgetView`, s'ajoute par
`IGameHudService.Add` et s'affiche par `Show<T>` / `Hide<T>`). Elle requiert le framework Game à
partir du tag `framework-game-2026-10-15` : sur un framework plus ancien, l'import ne compile pas.
`astra.quests` 1.0.0 et 1.0.1 restent disponibles pour ces projets (la 1.0.1 expose `Progression`
sur `ProgressionModule`, nécessaire au pont dialogue).

Ce pack n'est pas un template : il ne modifie pas la composition du projet. Le guide du pack
(`README.md`, en français) décrit la démo en cinq étapes, l'utilisation dans un jeu, le
remplacement de l'UI et les points d'extension. Le pont avec les conversations est le pack
[Quests ↔ Dialogue](../quests-dialogue/README.md).

Licence : code sous **MIT**. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **ugui 2.0.0** et **Valkyrie 2.1.0**
(`com.misterpxl.valkyrie`). Le pack référence les assemblies du framework Astra
`Astra.Framework.Core.Save.Profile.Runtime`, `Astra.Framework.Core.UI.Runtime`,
`Astra.Framework.Core.Localization.Runtime`, `Astra.Framework.Game.HUD.Runtime`,
`Astra.Framework.Game.Flow.Runtime` et `Astra.Framework.Game.FlowPresentation.Runtime` : le
projet consommateur doit embarquer le framework Game Flow Foundation. Plateformes déclarées :
macOS, Android et iOS.

Archive publiée via GitHub Releases sous le tag `quests-v1.1.0` (`quests-v1.0.0` et
`quests-v1.0.1` restent disponibles).
