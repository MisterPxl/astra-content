# Quests ↔ Dialogue

Pack public `astra.quests.dialogue` **1.2.1** (catégorie `Bridges`) : le pont entre la
progression de [Quests & Achievements](../quests/README.md) et les conversations d'
[Astra Dialogue](../dialogue/README.md). Il ne contient aucun contenu de jeu.

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.quests.dialogue` **1.2.1** (au lieu de 1.2.0) : release `quests-dialogue-v1.2.1`, 36 fichiers, 23483 octets, SHA-256 `46982de644ab172f4be02b9b02ee38687ed3f32fef9b014244519a5d3d095d01` ; dépendances de contenu (plages) : `astra.quests` [2.0.1, 3.0.0), `astra.dialogue` [0.1.5, 0.2.0).

- **Conditions** de dialogue : progression (quêtes, stats, succès) et objectif de quête terminé.
- **Actions** de dialogue : accepter, proposer, rendre ou faire échouer une quête, lever un
  signal, accorder des récompenses.
- **Objectifs de quête** (catégorie Dialogue) : « Conversation completed » (la conversation est
  allée jusqu'au bout, `Count` fois) et « Choice picked » (un choix précis a été pris, sélectionné
  dans une liste « Passage › texte du choix » ; si le choix disparaît, le build de la quête échoue
  avec « Pick the choice again »).
- **`ProgressionDialogueContextProvider`** : provider Astra à poser sur le PNJ avec son
  `DialogueRunner`. Il observe toutes les conversations que lance le runner, sans signal à créer ;
  un champ optionnel lève en plus un signal du projet à chaque fin de conversation.
- **Preview éditeur** « Quests progression » dans Dialogue Studio pour tester les conditions
  liées aux quêtes.

La 1.2.0 requiert `astra.quests` 2.0.0 (valeurs de HUD) ; le code du pont et son API publique
sont inchangés. La 1.1.0 ajoute les deux objectifs ci-dessus, la visibilité des usages par Aegis (une quête
proposée ou acceptée par un dialogue reste atteignable, un signal levé par un dialogue n'est pas
orphelin) et un smoke PlayMode headless. La démo annoncée en 1.0.0 n'existait pas ; elle est
retirée de la documentation et de la composition.

Mise en place : installer `astra.quests` et `astra.dialogue` (le Hub propose le pont quand les
deux sont présents), ajouter `quests.progression` (et `quests.quests` pour le tracker) à la
composition, puis sur le PNJ un `DialogueRunner` et un `ProgressionDialogueContextProvider` qui
référence le même `ProgressionModule` que la composition.

Dépendances exactes : **`astra.quests` 2.0.0** et **`astra.dialogue` 0.1.4**, que le Hub importe
dans la même transaction. La 1.1.0 dépendait de `astra.quests` 1.1.0 et la 1.0.0 de `astra.quests` 1.0.1 et
`astra.dialogue` 0.1.3 ; elles restent disponibles. Comme `astra.quests` 2.0.0, la 1.2.0 requiert le framework Game à partir
du tag `framework-game-2026-10-15` (HUD typé).

Licence : code sous **MIT**. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **ugui 2.0.0** et **Valkyrie 2.1.0**
(`com.misterpxl.valkyrie`), plus les assemblies du framework Astra
`Astra.Framework.Core.App.Runtime`, `Astra.Framework.Core.Initialization.Runtime`,
`Astra.Framework.Core.UI.Runtime` et `Astra.Framework.Game.Flow.Runtime`. Plateforme déclarée :
macOS.

Archive publiée via GitHub Releases sous le tag `quests-dialogue-v1.2.0`
(`quests-dialogue-v1.0.0` et `quests-dialogue-v1.1.0` restent disponibles).
