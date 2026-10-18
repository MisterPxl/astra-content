# Deckbuilder

Deux entrées de catalogue pour un roguelite deckbuilder solo, entièrement en UI.

- **`astra.deckbuilder` 3.0.0** (catégorie `Gameplay`) : simulation de run et de combat au tour
  en C# pur (`Deckbuilder.Core` : cartes, énergie, intentions ennemies, statuts, carte d'étages,
  récompenses, boutique, repos, méta-progression, RNG déterministe), vues Unity UI et démo
  (`Deckbuilder.Unity`), et pont vers le framework Astra (`Deckbuilder.Astra` : écrans, popups,
  HUD, sauvegarde du run, entrée **Continue** du menu principal, identifiant de module
  `deckbuilder.module`). La 3.0.0 fait des types de nœud de la carte des assets (`NodeKindAsset` : handler, route et
  placement par étages et poids), sans énumération ni table d'identifiants, et ajoute le type
  événement (`EventNodeHandler`, `EventDefinitionAsset`, `EventScreenView`) ; l'élite se fait sans
  code. Changements cassants : `DeckbuilderModule.NodeKinds` et `Routes`, `RunConfig.BossEncounter`
  retirés, sauvegardes de run en version 2 (les anciennes sont écartées avec un avertissement).
  La 2.0.0 (jamais publiée seule) publie les valeurs de HUD (`DeckbuilderHudValuesAsset`, exigé
  par le module). La 1.1.0 laisse le personnage piloter le combat (`MaxEnergy`,
  `DrawPerTurn`), fait passer tous les statuts par `ModifyDamageDealt` puis `ModifyDamageTaken`
  dans l'ordre de `RunConfig > Statuses` (arrondi à l'inférieur après chaque statut ; Faiblesse et
  Vulnérabilité réutilisables sous un autre identifiant ; 10 dégâts avec les deux font désormais
  10 au lieu de 11) et sérialise `ShopRules` et `RestRules` dans `RunConfigAsset`. Côté code :
  `ShopGenerator.Create` prend un `ShopRules`, `StatusCatalog` accepte une liste ordonnée et
  `CombatMath.OpeningDrawCount` devient `DefaultDrawPerTurn`. Le HUD passe au HUD typé (le widget
  dérive de `HudWidgetView`, s'ajoute par `IGameHudService.Add` et s'affiche par `Show<T>` /
  `Hide<T>`) : la 1.1.0 requiert le framework Game à partir du tag `framework-game-2026-10-15`,
  sur un framework plus ancien l'import ne compile pas.
- **`astra.template.deckbuilder` 3.0.0** (catégorie `Templates`) : template de genre prêt à
  jouer, avec configuration de run, cartes, ennemis, rencontres, boss, prefabs d'écrans, textes
  `fr` / `en` et un `composition.json` (identifiants de module `astra.core.localization` et
  `deckbuilder.module`). Il dépend exactement de `astra.deckbuilder` 3.0.0, que le Hub importe
  dans la même transaction. Le guide d'extension est livré dans le pack (`README.md` en anglais,
  `README.fr.md` en français). La 1.1.0 expose `Shop Rules` et `Rest Rules` dans `RunConfig`,
  prend en compte `MaxEnergy` et `DrawPerTurn` du personnage, et met le guide à jour (ordre des
  statuts, limites levées).

Licences : code et contenu sous **MIT**, sans asset tiers (`LICENSES/` dans chaque archive).

Prérequis qualifiés : **Unity 6000.4.0f1**, **Input System 1.19.0** (backend actif),
**ugui 2.0.0**, **Valkyrie 2.1.0** (`com.misterpxl.valkyrie`, inspecteur des listes d'effets)
pour le pack de gameplay, et **URP 17.4.0** pour le template. Les deux packs déclarent le
prérequis `assembly` `Astra.Framework.Game.FlowPresentation.Runtime` : le projet consommateur
doit embarquer le framework Game Flow Foundation, sinon le Hub refuse l'import avant toute copie.
Plateformes déclarées : macOS, Android et iOS (souris et tactile).

Après l'import du template, appliquer `Assets/AstraContent/astra.template.deckbuilder/composition.json`
avec Astra Setup (action « Apply composition with Setup » de la fiche du Hub), puis lancer Play
depuis la scène Bootstrap et choisir **Start** dans le menu principal.

Archives publiées via GitHub Releases, tags `deckbuilder-v3.0.0` et `template-deckbuilder-v3.0.0`
(`deckbuilder-v1.1.0`, `template-deckbuilder-v1.1.0`, `deckbuilder-v1.0.0` et `template-deckbuilder-v1.0.0` restent disponibles pour les projets dont
le framework n'a pas encore le HUD typé).
