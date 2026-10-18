# Melee

Deux entrées de catalogue pour un platform fighter local de deux à quatre joueurs.

- **`astra.melee` 4.0.0** (catégorie `Gameplay`) : simulation déterministe en C# pur
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
- **`astra.template.melee` 4.0.0** (catégorie `Templates`) : template de genre avec lobby,
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
