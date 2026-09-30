# FPS

Deux entrées de catalogue pour un FPS de style MW2 jouable contre des bots.

- **`astra.fps` 1.0.0** (catégorie `Gameplay`) : simulation FPS en C# pur (armes, santé,
  modes, bots), vues Unity et pont vers le framework Astra (`Fps.Core`, `Fps.Unity`,
  `Fps.Astra`).
- **`astra.template.fps` 1.0.0** (catégorie `Templates`) : template de genre avec sélection de
  mode, **The Pit** et **Team Deathmatch** contre bots, HUD, armes et un `composition.json`.
  Il dépend exactement de `astra.fps` 1.0.0, que le Hub importe dans la même transaction.

Licence : MIT. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **Input System 1.19.0** (backend actif),
**AI Navigation 2.0.11**, **ugui 2.0.0**, et pour le template **URP 17.4.0**. `astra.fps`
référence les assemblies du framework Astra `Astra.Framework.Game.HUD.Runtime`,
`Astra.Framework.Game.Spawning.Runtime` et `Astra.Framework.Game.Characters.Runtime` : le
projet consommateur doit embarquer le framework, avec `ISpawningService.RegisterFactory`.
Plateforme déclarée : macOS.

Après l'import du template, appliquer `Assets/AstraContent/astra.template.fps/composition.json`
avec Astra Setup (action « Apply composition with Setup » de la fiche du Hub).

Limites connues de cette première version : les bots patrouillent, poursuivent et détectent mais
ne tirent pas ; grenades et couteau sont liés à l'input sans gameplay ; l'art est primitif.

Archives publiées via GitHub Releases, tags `fps-v1.0.0` et `template-fps-v1.0.0`.
