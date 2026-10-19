# Match3

Deux entrées de catalogue pour un puzzle match-3 tactile.

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.match3` **4.0.1** (au lieu de 4.0.0) : release `match3-v4.0.1`, 151 fichiers, 97081 octets, SHA-256 `7dab9bce2c95fa8f3f54fd9bf6ce05af6495db1b98c5f2ca39c608bf7de2924b` ; dépendances de contenu (plages) : aucune.
- `astra.template.match3` **4.0.1** (au lieu de 4.0.0) : release `template-match3-v4.0.1`, 67 fichiers, 51983 octets, SHA-256 `99c2ec2e9b8af9074292c18429332fb3aacf2f7e24617a46ef9c29b566a81f63` ; dépendances de contenu (plages) : `astra.match3` [4.0.1, 5.0.0).

- **`astra.match3` 4.0.1** (catégorie `Gameplay`) : règles, plateau et scoring en C# pur et
  testé. Simulation temps réel à ticks fixes, réservation de cases, swipes pendant les
  cascades, power-ups Royal Match (Rocket, TNT, Propeller, Light Ball) et combos. La 4.0.0 ouvre les types de
  pièces : l'énumération `PieceColor` disparaît au profit de `PieceTypeAsset` (identifiant, nom,
  sprite et teinte facultatifs) et d'une palette de 3 types minimum par niveau
  (`LevelAsset._pieceTypes`) ; l'objectif de collecte devient `CollectPieceTypeGoal`. Réordonner
  les types d'un niveau change le plateau d'un seed. La 3.0.0 (jamais publiée seule) ouvrait les
  niveaux : liste d'objectifs choisis par type, asset de règles (`Match3RulesAsset`) et valeurs
  de HUD publiées (`Match3HudValuesAsset`, exigées par le module). La 2.1.0
  passe le HUD au HUD typé : le widget dérive de `HudWidgetView`, s'ajoute par
  `IGameHudService.Add` et s'affiche par `Show<T>` / `Hide<T>` (clé texte retirée). Elle requiert
  le framework Game à partir du tag `framework-game-2026-10-15` : sur un framework plus ancien,
  l'import ne compile pas. La 2.0.1 avait ajouté l'identifiant de module `match3.module` ;
  règles de jeu inchangées depuis 2.0.0.
- **`astra.template.match3` 4.0.1** (catégorie `Templates`) : template de genre prêt à jouer,
  avec scène de départ, niveaux, prefabs et un `composition.json` (identifiant de module
  `match3.module`, sans avertissement de Setup). Il dépend de `astra.match3` dans la plage [4.0.1, 5.0.0),
  que le Hub importe dans la même transaction. Le guide d'extension est livré dans le pack
  (`README.md` en anglais, `README.fr.md` en français) : niveaux, power-ups, motifs, combos,
  objectifs et limites actuelles.

Licence : MIT. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **Input System 1.19.0** (backend actif), et pour
le template **URP 17.4.0** et **ugui 2.0.0**. `astra.match3` référence l'assembly du
framework Astra `Astra.Framework.Game.HUD.Runtime` et, depuis la 2.0.1,
`Astra.Framework.Game.FlowPresentation.Runtime` (prérequis déclaré par les deux packs) : le
projet consommateur doit embarquer le framework Game Flow Foundation. `astra.match3` 2.0.1 et
`astra.template.match3` 2.0.2 restent disponibles pour les projets dont le framework Game n'a pas encore le HUD typé
(`astra.match3` 2.0.0 et `astra.template.match3` 2.0.0 et 2.0.1, pour ceux sans Game Flow Foundation). Plateformes déclarées : macOS, Android, iOS.

Après l'import du template, appliquer `Assets/AstraContent/astra.template.match3/composition.json`
avec Astra Setup (action « Apply composition with Setup » de la fiche du Hub).

Archives publiées via GitHub Releases, tags `match3-v4.0.0` et `template-match3-v4.0.0`
(`match3-v2.1.0`, `template-match3-v2.1.0`, `match3-v2.0.0`, `match3-v2.0.1`, `template-match3-v2.0.0`, `template-match3-v2.0.1` et
`template-match3-v2.0.2` restent disponibles).
