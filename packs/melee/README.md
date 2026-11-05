# Melee

Deux entrées de catalogue pour un platform fighter local de deux à quatre joueurs.

## Catalogue `gameplay-v31` : compatibilité framework 4.x

Versions publiées le 5 novembre 2026. Les packs ci-dessous acceptent `astra-framework`
`[3.0.0, 5.0.0)` et leurs dépendances de contenu ciblent les versions corrigées.
Les anciennes versions restent disponibles dans le catalogue.

- `astra.melee` **4.1.1** : [release `melee-v4.1.1`](https://github.com/MisterPxl/astra-content/releases/tag/melee-v4.1.1), 111 fichiers, 118592 octets, SHA-256 `af3975237b183c8bb9a92b6f9b19a66e8e720bd24134c3bdef3a772b7357db8d` ; dépendances : aucune.
- `astra.template.melee` **4.1.1** : [release `template-melee-v4.1.1`](https://github.com/MisterPxl/astra-content/releases/tag/template-melee-v4.1.1), 237 fichiers, 6998695 octets, SHA-256 `49f45cf04686d19da19445efc64b5578477030b7359dc3a751ff0e26e91863de` ; dépendances : `astra.melee [4.1.1, 5.0.0)`.

Qualification sur des consommateurs propres Astra Framework 4.1.0 : imports Hub et
vérification des scripts, scènes, matériaux et GUID ; dépendances minimales et les plus
récentes pour les packs dépendants ; smokes et Aegis 0 erreur / 0 avertissement pour les
compositions. Archives publiques téléchargées sans authentification et contrôlées par SHA-256.

## Catalogue `gameplay-v30` : framework 3.0.0

Requiert le framework à partir du tag `framework-game-2026-11-02` (modèle Core :
`framework-core-2026-11-02`), garanti par le prérequis de capacité `astra-framework` [3.0.0, 4.0.0) :
le Hub refuse l'import sur un framework 2.x, pour lequel la 4.0.1 reste listée. Les retours de gameplay
passent par le package Pulse (`com.misterpxl.pulse` [1.0.0, 2.0.0), tag `v1.0.0`), à déclarer dans le
manifeste du projet. Les spawns n'utilisent plus `SpawnCategory`, retiré du framework.

- `astra.melee` **4.1.0** : release `melee-v4.1.0`, 111 fichiers, 118478 octets, SHA-256 `bf83e7aa98f9c5bb73cbb4176640ae2d3bcad1fa47744994624322ad0304bec0` ; dépendances de contenu (plages) : aucune.
- `astra.template.melee` **4.1.0** : release `template-melee-v4.1.0`, 237 fichiers, 6998590 octets, SHA-256 `e52d4b2a19c31dc3cc354f6aeb76a1c481e8d2d202f7682b6fe5a6d211ddb224` ; dépendances de contenu (plages) : `astra.melee` [4.1.0, 5.0.0).

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.melee` **4.0.1** (au lieu de 4.0.0) : release `melee-v4.0.1`, 111 fichiers, 118084 octets, SHA-256 `d92b167db93017f5fc1351b36e3943fd4b8819ce77b35edf06d8592bcb6006df` ; dépendances de contenu (plages) : aucune.
- `astra.template.melee` **4.0.1** (au lieu de 4.0.0) : release `template-melee-v4.0.1`, 237 fichiers, 6998450 octets, SHA-256 `2dd3a9c7a7212d1f5e8af3f6e8ea19ed8fb66f8bdcfc7681c05b7bc4e1477dfb` ; dépendances de contenu (plages) : `astra.melee` [4.0.1, 5.0.0).

- **`astra.melee` 4.0.1** (catégorie `Gameplay`) : simulation déterministe en C# pur
  (`Melee.Core`), vues Unity et pont vers le framework Astra. Contrôle aérien retuné,
  direction au décollage et au double saut, feedback de saut, HUD qui se cale à l'écran.
  La 4.0.0 fait d'une capacité un asset (`MoveAsset`, jusqu'à 32 par combattant, déclencheur par
  bouton, direction du stick et contexte sol ou air, coups multiples) : `MoveId` disparaît, une
  capacité est identifiée par son index et l'on en ajoute sans code ni reconstruction du
  controller. La 3.0.0 séparait la sélection du stage et celle du combattant en deux écrans à
  grille, la 2.x ajoutait le choix de combattant et de stage, les joueurs CPU et le spectateur
  (versions jamais publiées seules ; toutes les notes sont cumulées dans la 4.0.0). La 1.3.0 passe le HUD au HUD typé : le widget dérive de `HudWidgetView`, s'ajoute par
  `IGameHudService.Add` et s'affiche par `Show<T>` / `Hide<T>` (clé texte retirée). Elle requiert
  le framework Game à partir du tag `framework-game-2026-10-15` : sur un framework plus ancien,
  l'import ne compile pas. La 1.2.1 pilotait le lobby et le stage par des phases de gameplay
  (Lobby, Stage) et enregistrait les services du match sur le scope run ; règles de jeu
  inchangées depuis la 1.2.0.
- **`astra.template.melee` 4.0.1** (catégorie `Templates`) : template de genre avec lobby,
  stage, combattant, cartes joueur et un `composition.json` (identifiants de module
  `astra.game.*` et `melee.module`). Il dépend exactement de
  `astra.melee` 4.0.0, que le Hub importe dans la même transaction. Le guide d'extension est
  livré dans le pack (`README.md` en anglais, `README.fr.md` en français) : combattants, coups,
  stage, règles, contrôles et limites actuelles.

Licences : code et contenu du template sous **MIT** ; le modèle, les textures et les animations
Quaternius du template sous **CC0-1.0** (`LICENSES/` et `Art/Quaternius/PROVENANCE.json` dans
l'archive).

Prérequis qualifiés : **Unity 6000.4.0f1**, **Input System 1.19.0** (backend actif), et pour
le template **URP 17.4.0** et **ugui 2.0.0**. `astra.melee` référence l'assembly du framework
Astra `Astra.Framework.Game.HUD.Runtime` et, depuis la 1.2.1, `Astra.Framework.Game.FlowPresentation.Runtime`
(prérequis déclaré par les deux packs) : le projet consommateur doit embarquer le framework
Game Flow Foundation, à partir du tag `framework-game-2026-10-15` pour la 1.3.0.
`astra.melee` 1.2.1 et `astra.template.melee` 1.2.2 restent disponibles pour les projets dont
le framework n'a pas encore le HUD typé (et 1.2.0 / 1.2.0 et 1.2.1 sans Game Flow Foundation).
Plateforme déclarée : macOS. Deux joueurs peuvent partager un clavier (schémas gauche et droit).

Après l'import du template, appliquer `Assets/AstraContent/astra.template.melee/composition.json`
avec Astra Setup (action « Apply composition with Setup » de la fiche du Hub).

Archives publiées via GitHub Releases, tags `melee-v4.0.0` et `template-melee-v4.0.0`
(`melee-v1.3.0`, `template-melee-v1.3.0`, `melee-v1.2.0`, `melee-v1.2.1`, `template-melee-v1.2.0`, `template-melee-v1.2.1` et
`template-melee-v1.2.2` restent disponibles).
