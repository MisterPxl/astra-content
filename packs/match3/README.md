# Match3

Deux entrées de catalogue pour un puzzle match-3 tactile.

## Catalogue `gameplay-v31` : compatibilité framework 4.x

Versions publiées le 5 novembre 2026. Les packs ci-dessous acceptent `astra-framework`
`[3.0.0, 5.0.0)` et leurs dépendances de contenu ciblent les versions corrigées.
Les anciennes versions restent disponibles dans le catalogue.

- `astra.match3` **4.1.1** : [release `match3-v4.1.1`](https://github.com/MisterPxl/astra-content/releases/tag/match3-v4.1.1), 151 fichiers, 97565 octets, SHA-256 `f9480a7aa261f0afa9de0b52aa9f298480e55f2d17e7e53516919ecd6a2ea7a8` ; dépendances : aucune.
- `astra.template.match3` **4.1.1** : [release `template-match3-v4.1.1`](https://github.com/MisterPxl/astra-content/releases/tag/template-match3-v4.1.1), 67 fichiers, 52171 octets, SHA-256 `ee8c19371f4b619dd13bf383a5533f02bfbafb1491c496eea694e80e3efb07e3` ; dépendances : `astra.match3 [4.1.1, 5.0.0)`.

Qualification sur des consommateurs propres Astra Framework 4.1.0 : imports Hub et
vérification des scripts, scènes, matériaux et GUID ; dépendances minimales et les plus
récentes pour les packs dépendants ; smokes et Aegis 0 erreur / 0 avertissement pour les
compositions. Archives publiques téléchargées sans authentification et contrôlées par SHA-256.

## Catalogue `gameplay-v30` : framework 3.0.0

Requiert le framework à partir du tag `framework-game-2026-11-02` (modèle Core :
`framework-core-2026-11-02`), garanti par le prérequis de capacité `astra-framework` [3.0.0, 4.0.0) :
le Hub refuse l'import sur un framework 2.x, pour lequel la 4.0.1 reste listée. Les retours de gameplay
passent par le package Pulse (`com.misterpxl.pulse` [1.0.0, 2.0.0), tag `v1.0.0`), à déclarer dans le
manifeste du projet.

- `astra.match3` **4.1.0** : release `match3-v4.1.0`, 151 fichiers, 97444 octets, SHA-256 `ad7216c889bdd553566916f4d59996bc2f2b23dda1cf950b272046e376754086` ; dépendances de contenu (plages) : aucune.
- `astra.template.match3` **4.1.0** : release `template-match3-v4.1.0`, 67 fichiers, 52064 octets, SHA-256 `ce360cbdc415d43778432f4bb9a9da406142408d6a1afbb72665422ca79d45f1` ; dépendances de contenu (plages) : `astra.match3` [4.1.0, 5.0.0).

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
