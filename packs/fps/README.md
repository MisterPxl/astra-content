# FPS

Deux entrées de catalogue pour un FPS de style MW2 jouable contre des bots.

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.fps` **2.0.1** (au lieu de 2.0.0) : release `fps-v2.0.1`, 155 fichiers, 99814 octets, SHA-256 `720d9c8911a41ef2d009586ab1eae507d67bf0136e2457ed9b4383fc0d8925fe` ; dépendances de contenu (plages) : aucune.
- `astra.template.fps` **2.0.1** (au lieu de 2.0.0) : release `template-fps-v2.0.1`, 163 fichiers, 265500 octets, SHA-256 `764584970747d9436d5baf5a783d4e2965e9af7db1d2be64a7bba9a08b75c298` ; dépendances de contenu (plages) : `astra.fps` [2.0.1, 3.0.0).

- **`astra.fps` 2.0.1** (catégorie `Gameplay`) : simulation FPS en C# pur (armes, santé,
  modes, bots), vues Unity et pont vers le framework Astra (`Fps.Core`, `Fps.Unity`,
  `Fps.Astra`). La 2.0.0 publie les valeurs de HUD (`FpsHudValuesAsset` : munitions, rechargement, santé,
  équipement, statut ; exigé par `FpsModule`), met les emplacements d'arme en assets
  (`LoadoutSlotAsset`, panneau LOADOUT généré depuis la liste) et expose `BurstShotCount` sur
  `WeaponDefinitionAsset`. Changements cassants : l'énumération `LoadoutSlot` et les accesseurs
  Primary / Secondary disparaissent ; les armes et loadouts 1.x sont relus. La 1.3.0 passe le HUD au HUD typé : le widget dérive de `HudWidgetView`, s'ajoute par
  `IGameHudService.Add` et s'affiche par `Show<T>` / `Hide<T>` (clé texte retirée) ; elle requiert
  le framework Game à partir du tag `framework-game-2026-10-15`, sur un framework plus ancien
  l'import ne compile pas. La 1.2.0 ajoutait le changement d'arme à la molette, des modèles d'armes en
  primitives (M4A1, USP .45, Intervention), l'échange d'arme au sol avec ramassage, la lunette
  de l'Intervention, un éditeur de loadout et des impacts qui suivent la surface touchée ;
  identifiant de module `fps.module`. Elle incluait la 1.1.0, jamais publiée : bots qui tirent,
  grenades frag et flash, couteau. Depuis la 1.2.0, elle requiert le framework Game Flow
  Foundation (`Game.FlowPresentation`) : le Hub refuse l'import sur une copie plus ancienne.
- **`astra.template.fps` 2.0.1** (catégorie `Templates`) : template de genre avec sélection de
  mode, **The Pit** et **Team Deathmatch** contre bots armés, HUD, armes, panneau LOADOUT et un
  `composition.json` (identifiants de module `astra.core.preferences`, `astra.game.characters`,
  `astra.game.spawning` et `fps.module` ; `PreferencesModule` persiste le loadout). Il dépend
  de `astra.fps` dans la plage [2.0.1, 3.0.0), que le Hub importe dans la même transaction. Le guide
  d'extension est livré dans le pack (`README.md` en anglais, `README.fr.md` en français).

Licence : MIT. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **Input System 1.19.0** (backend actif),
**AI Navigation 2.0.11**, **ugui 2.0.0**, et pour le template **URP 17.4.0**. `astra.fps`
référence les assemblies du framework Astra `Astra.Framework.Game.HUD.Runtime`,
`Astra.Framework.Game.Spawning.Runtime` et `Astra.Framework.Game.Characters.Runtime` et, depuis
la 1.2.0, `Astra.Framework.Game.FlowPresentation.Runtime` (prérequis déclaré par les deux packs) :
le projet consommateur doit embarquer le framework Game Flow Foundation, à partir du tag
`framework-game-2026-10-15` pour la 1.3.0 et la 2.0.0. `astra.fps` 1.3.0, `astra.template.fps` 1.3.0,
`astra.fps` 1.2.0 et `astra.template.fps` 1.2.0
restent disponibles pour les projets dont le framework n'a pas encore le HUD typé, et la 1.0.0
de chacun pour ceux sans Game Flow Foundation. Plateforme déclarée : macOS.

Après l'import du template, appliquer `Assets/AstraContent/astra.template.fps/composition.json`
avec Astra Setup (action « Apply composition with Setup » de la fiche du Hub).

Limites connues : un seul pistolet dans l'armurerie ; une arme ramassée au sol est perdue à la
mort ; pas de ramassage en TDM et les bots ne ramassent pas d'armes ; l'art est primitif.

Archives publiées via GitHub Releases, tags `fps-v2.0.0` et `template-fps-v2.0.0`
(`fps-v1.3.0`, `template-fps-v1.3.0`, `fps-v1.2.0`, `template-fps-v1.2.0`, `fps-v1.0.0` et `template-fps-v1.0.0` restent disponibles).
