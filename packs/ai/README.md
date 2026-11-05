# AI Decision & Perception

Trois entrées de catalogue : le moteur de décision `astra.ai` (catégorie `Gameplay`) et deux ponts
(catégorie `Bridges`) vers Adventure et Quests.

## Catalogue `gameplay-v31` : compatibilité framework 4.x

Versions publiées le 5 novembre 2026. Les packs ci-dessous acceptent `astra-framework`
`[3.0.0, 5.0.0)` et leurs dépendances de contenu ciblent les versions corrigées.
Les anciennes versions restent disponibles dans le catalogue.

- `astra.ai` **1.0.1** : [release `ai-v1.0.1`](https://github.com/MisterPxl/astra-content/releases/tag/ai-v1.0.1), 137 fichiers, 90713 octets, SHA-256 `fe3438db3d3235fba83ce3698ad6c81b6e2733d9296e4b4b5fbd725155cf91c8` ; dépendances : aucune.
- `astra.adventure.ai` **1.0.1** : [release `adventure-ai-v1.0.1`](https://github.com/MisterPxl/astra-content/releases/tag/adventure-ai-v1.0.1), 18 fichiers, 14278 octets, SHA-256 `fa4889098045588d34f10ec39be08cfe0e75577e887b20cd6f08ace9c84490c4` ; dépendances : `astra.ai [1.0.1, 2.0.0)`, `astra.adventure [2.1.1, 3.0.0)`.
- `astra.ai.quests` **1.0.1** : [release `ai-quests-v1.0.1`](https://github.com/MisterPxl/astra-content/releases/tag/ai-quests-v1.0.1), 27 fichiers, 16471 octets, SHA-256 `b4eb89c96e15e96e21013be89f1e38b5bcd5cb1c4fe595c268ec9d370eaffa0d` ; dépendances : `astra.ai [1.0.1, 2.0.0)`, `astra.quests [2.1.1, 3.0.0)`.

Qualification sur des consommateurs propres Astra Framework 4.1.0 : imports Hub et
vérification des scripts, scènes, matériaux et GUID ; dépendances minimales et les plus
récentes pour les packs dépendants ; smokes et Aegis 0 erreur / 0 avertissement pour les
compositions. Archives publiques téléchargées sans authentification et contrôlées par SHA-256.

## Catalogue `gameplay-v30` : première publication

Requiert le framework à partir du tag `framework-game-2026-11-02` (modèle Core :
`framework-core-2026-11-02`), garanti par le prérequis de capacité `astra-framework` [3.0.0, 4.0.0).
Le pack déclare aussi l'assembly `Astra.Framework.Core.Debug.CommandLine.Runtime` (arguments des
commandes de debug) : le Hub refuse l'import sur un framework plus ancien avant toute copie.

- `astra.ai` **1.0.0** : release `ai-v1.0.0`, 137 fichiers, 90545 octets, SHA-256 `33e61aea0846afcc4e4f5a975c6857dc6b756b4cb98331602f452cc4c1aeca5f` ; dépendances de contenu (plages) : aucune.
- `astra.adventure.ai` **1.0.0** : release `adventure-ai-v1.0.0`, 18 fichiers, 14122 octets, SHA-256 `809901f01ff1248dc56c8d09885b3c350a82241de701b49d35344dfd862c41ab` ; dépendances de contenu (plages) : `astra.ai` [1.0.0, 2.0.0), `astra.adventure` [2.1.0, 3.0.0).
- `astra.ai.quests` **1.0.0** : release `ai-quests-v1.0.0`, 27 fichiers, 16308 octets, SHA-256 `47b834cc1161ab24043980364a83b7661a5df972f5f48a7fdd379a2b85170cc6` ; dépendances de contenu (plages) : `astra.ai` [1.0.0, 2.0.0), `astra.quests` [2.1.0, 3.0.0).

## `astra.ai`

- **Core** en C# pur, sans Unity (`noEngineReferences`) : machine à états hiérarchique, Utility AI
  (axes normalisés, courbes échantillonnées, veto à zéro, momentum), séquences, blackboard typé,
  perception, RNG xorshift interne. Même graine, même décision.
- **Authoring** : assets State, Utility Option et Brain Definition, nœuds polymorphes
  `[SerializeReference]`. `Tools > Astra > AI > Create Guard Example` génère un exemple
  patrouille/combat/recherche et un panneau HUD ; `Brain Debugger` simule un cerveau sans entrer en
  Play ; `Validate Selected Catalog` signale les erreurs d'authoring.
- **Astra** : module `ai.module` (tick pendant le Gameplay uniquement, échelle de temps du jeu),
  valeurs de HUD, sauvegarde des agents persistants (`astra.ai.state` : RNG, blackboard, perception,
  progression des actions, cooldowns), commandes de debug `ai.summary`, `ai.inspect`,
  `ai.force_state`, `ai.set_blackboard`, visibles dans Helios.
- **Aegis** (si `com.misterpxl.aegis` 1.x est installé) : identifiants dupliqués, états
  inatteignables, options Utility invalides.

Aucune recherche de scène : la phase ou le spawner qui instancie un agent l'attache avec
`agent.Bind(runtime, seed)`.

## `astra.adventure.ai`

Ennemis Adventure pilotés par `astra.ai` : perception (vision, champ de vision, ligne de vue,
audition), patrouille sur chemin, poursuite avec sprint, attaque à l'épée et à l'arc, dégâts en quarts
de cœur. La défaite émet `enemy.defeated` une seule fois ; un ennemi persistant reste vaincu après un
chargement et revient si l'on charge une sauvegarde antérieure à sa défaite. Le préfab de l'ennemi
porte ses références ; la phase l'attache au héros avec `enemy.Bind(ai.Runtime, hero)`.

## `astra.ai.quests`

Module `ai.quests.bridge` : les signaux de l'IA deviennent des signaux de progression
(`ai.agent.state.entered`, `ai.agent.defeated`, `ai.agent.alerted`). Objectif `DefeatAiAgentObjective`
(par agent, cerveau, tag ou n'importe lequel) et condition `AiAgentInStateCondition`.

Licence : code sous **MIT**, sans asset tiers. Prérequis qualifiés : **Unity 6000.4.0f1**,
**ugui 2.0.0**, **Valkyrie 2.1.0**. Qualification : 139 tests EditMode et 4 parcours PlayMode sur des
consommateurs vierges, Aegis sans finding.
