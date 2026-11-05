# Shmup

Deux entrées de catalogue pour un shoot'em up horizontal, solo ou en coopération locale à deux joueurs.

## Catalogue `gameplay-v31` : compatibilité framework 4.x

Versions publiées le 5 novembre 2026. Les packs ci-dessous acceptent `astra-framework`
`[3.0.0, 5.0.0)` et leurs dépendances de contenu ciblent les versions corrigées.
Les anciennes versions restent disponibles dans le catalogue.

- `astra.shmup` **1.2.1** : [release `shmup-v1.2.1`](https://github.com/MisterPxl/astra-content/releases/tag/shmup-v1.2.1), 104 fichiers, 63703 octets, SHA-256 `a153e1d0100b02078e69bca33df3514f74b323339a5ba6e718c1174ceb2136c7` ; dépendances : aucune.
- `astra.template.shmup` **1.2.1** : [release `template-shmup-v1.2.1`](https://github.com/MisterPxl/astra-content/releases/tag/template-shmup-v1.2.1), 107 fichiers, 114620 octets, SHA-256 `14a369b447f928170d2d9ccf1c4b3092a20e86da17ae84a65ee7ee411ac810be` ; dépendances : `astra.shmup [1.2.1, 2.0.0)`.

Qualification sur des consommateurs propres Astra Framework 4.1.0 : imports Hub et
vérification des scripts, scènes, matériaux et GUID ; dépendances minimales et les plus
récentes pour les packs dépendants ; smokes et Aegis 0 erreur / 0 avertissement pour les
compositions. Archives publiques téléchargées sans authentification et contrôlées par SHA-256.

## Catalogue `gameplay-v30` : framework 3.0.0

Requiert le framework à partir du tag `framework-game-2026-11-02` (modèle Core :
`framework-core-2026-11-02`), garanti par le prérequis de capacité `astra-framework` [3.0.0, 4.0.0) :
le Hub refuse l'import sur un framework 2.x, pour lequel la 1.1.2 reste listée. Les retours de gameplay
passent par le package Pulse (`com.misterpxl.pulse` [1.0.0, 2.0.0), tag `v1.0.0`), à déclarer dans le
manifeste du projet. Les spawns n'utilisent plus `SpawnCategory`, retiré du framework : la fabrique
poolée du pack reconnaît ses objets par marqueur de prefab. Les étincelles reçoivent leur durée de vie
dès leur premier tick : elles disparaissent et sont réutilisées.

- `astra.shmup` **1.2.0** : release `shmup-v1.2.0`, 104 fichiers, 63580 octets, SHA-256 `3dc8559680d691ac8d02177abc374e225ae6c12571453137f78604c78c068cd3` ; dépendances de contenu (plages) : aucune.
- `astra.template.shmup` **1.2.0** : release `template-shmup-v1.2.0`, 107 fichiers, 114486 octets, SHA-256 `b7ce5373df99283799fcc0edf35df04e31307b29b3fd9c6c9484a47b8950cf23` ; dépendances de contenu (plages) : `astra.shmup` [1.2.0, 2.0.0).

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.shmup` **1.1.2** (au lieu de 1.1.1) : release `shmup-v1.1.2`, 104 fichiers, 62757 octets, SHA-256 `6512abc8fa6811073861b046efc26f865eb244ce60df747c17b9fd3c131e56c5` ; dépendances de contenu (plages) : aucune.
- `astra.template.shmup` **1.1.2** (au lieu de 1.1.1) : release `template-shmup-v1.1.2`, 107 fichiers, 114335 octets, SHA-256 `3ee77e89585ea0d409ae9f2311a64ea92146c5d628bc64c3a3e602673b22987e` ; dépendances de contenu (plages) : `astra.shmup` [1.1.2, 2.0.0).

- **`astra.shmup` 1.1.2** (catégorie `Gameplay`) : simulation à 60 Hz en C# pur
  (`Shmup.Core` : balles et ennemis poolés, grille spatiale, émetteurs de motifs, trajectoires,
  bonus, RNG déterministe), vues Unity (`Shmup.Unity`) et pont vers le framework Astra
  (`Shmup.Astra` : lobby, phases de gameplay, HUD, retour de fin de partie, identifiant de module
  `shmup.module`). La 1.1.0 passe le HUD au HUD typé : le widget s'ajoute par
  `IGameHudService.Add` et s'affiche par `Show<T>` / `Hide<T>`, et `ShmupHudValuesAsset` publie
  à chaque frame le score, les vies, les bombes, la puissance et le multiplicateur par joueur,
  ainsi que le statut de la partie. `ShmupModule` exige cet asset. La 1.1.1 corrige la simulation : les émetteurs ne gardent plus
  d'état (la spirale tourne par tireur, le compteur repart à zéro à chaque phase de boss) et un
  ennemi tué par une balle est crédité au joueur qui l'a tirée ; le hachage d'état change.
- **`astra.template.shmup` 1.1.2** (catégorie `Templates`) : template de genre avec lobby de un
  à deux joueurs, un secteur horizontal (`SectorOne`), deux vaisseaux (Falcon, Hornet), cinq
  ennemis (Scout, Grunt, Turret, Elite, boss `BossCore` en trois phases), une scène de test de
  charge et un `composition.json` (modules `astra.game.spawning`, `astra.game.multiplayer` et
  `shmup.module`). Il dépend de `astra.shmup` dans la plage [1.1.2, 2.0.0), que le Hub importe dans la même
  transaction. Les clés de HUD vivent dans `Config/Hud` et un élément de HUD (bombes du joueur 1)
  s'ajoute sans code. Le guide d'extension est livré dans le pack (`README.md` en anglais,
  `README.fr.md` en français) : ennemis, motifs de balles, vagues, contrôles et limites actuelles.

Licence : code et contenu du template sous **MIT**. L'art du template est un placeholder généré
dans l'éditeur ; le guide suggère de le remplacer par Kenney Space Shooter Redux (CC0) pour une
production. Aucun asset tiers n'est inclus.

Prérequis qualifiés : **Unity 6000.4.0f1**, **Input System 1.19.0** (backend actif), et pour
le template **URP 17.4.0** et **ugui 2.0.0**. `astra.shmup` référence les assemblies du framework
Astra `Astra.Framework.Game.HUD.Runtime` et `Astra.Framework.Game.FlowPresentation.Runtime`
(prérequis déclaré par les deux packs). La 1.1.0 requiert le framework Game à partir du tag
`framework-game-2026-10-15` (HUD typé) : sur un framework plus ancien, l'import ne compile pas.
`astra.shmup` 1.0.0 et `astra.template.shmup` 1.0.0 restent disponibles pour ces projets.
Plateforme déclarée : macOS.

Après l'import du template, appliquer `Assets/AstraContent/astra.template.shmup/composition.json`
avec Astra Setup (action « Apply composition with Setup » de la fiche du Hub). Le jeu démarre
sur le lobby : appuyer sur Tir pour se déclarer prêt, puis le stage horizontal se charge.

Contrôles (PC) : clavier gauche (WASD, tir H, bombe J, focus K), clavier droit (flèches, tir
pavé 0, bombe pavé 1, focus pavé 2) ou manette (stick gauche, tir Sud, bombe Est, focus gâchette
gauche). Limites actuelles : pas de graze ni de rejeu, un seul secteur dans le template, interface
de boss minimale.

Archives publiées via GitHub Releases, tags `shmup-v1.1.2` et `template-shmup-v1.1.2`
(`shmup-v1.1.1`, `template-shmup-v1.1.1`, `shmup-v1.1.0`, `template-shmup-v1.1.0`, `shmup-v1.0.0` et `template-shmup-v1.0.0` restent disponibles).
