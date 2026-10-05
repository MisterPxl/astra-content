# Deckbuilder

Deux entrées de catalogue pour un roguelite deckbuilder solo, entièrement en UI.

- **`astra.deckbuilder` 1.0.0** (catégorie `Gameplay`) : simulation de run et de combat au tour
  en C# pur (`Deckbuilder.Core` : cartes, énergie, intentions ennemies, statuts, carte d'étages,
  récompenses, boutique, repos, méta-progression, RNG déterministe), vues Unity UI et démo
  (`Deckbuilder.Unity`), et pont vers le framework Astra (`Deckbuilder.Astra` : écrans, popups,
  HUD, sauvegarde du run, entrée **Continue** du menu principal, identifiant de module
  `deckbuilder.module`).
- **`astra.template.deckbuilder` 1.0.0** (catégorie `Templates`) : template de genre prêt à
  jouer, avec configuration de run, cartes, ennemis, rencontres, boss, prefabs d'écrans, textes
  `fr` / `en` et un `composition.json` (identifiants de module `astra.core.localization` et
  `deckbuilder.module`). Il dépend exactement de `astra.deckbuilder` 1.0.0, que le Hub importe
  dans la même transaction. Le guide d'extension est livré dans le pack (`README.md` en anglais,
  `README.fr.md` en français).

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

Archives publiées via GitHub Releases, tags `deckbuilder-v1.0.0` et `template-deckbuilder-v1.0.0`.
