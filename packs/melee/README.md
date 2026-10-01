# Melee

Deux entrées de catalogue pour un platform fighter local de deux à quatre joueurs.

- **`astra.melee` 1.2.0** (catégorie `Gameplay`) : simulation déterministe en C# pur
  (`Melee.Core`), vues Unity et pont vers le framework Astra. Contrôle aérien retuné,
  direction au décollage et au double saut, feedback de saut, HUD qui se cale à l'écran.
- **`astra.template.melee` 1.2.1** (catégorie `Templates`) : template de genre avec lobby,
  stage, combattant, cartes joueur et un `composition.json`. Il dépend exactement de
  `astra.melee` 1.2.0, que le Hub importe dans la même transaction. Le guide d'extension est
  livré dans le pack (`README.md` en anglais, `README.fr.md` en français) : combattants, coups,
  stage, règles, contrôles et limites actuelles.

Licences : code et contenu du template sous **MIT** ; le modèle, les textures et les animations
Quaternius du template sous **CC0-1.0** (`LICENSES/` et `Art/Quaternius/PROVENANCE.json` dans
l'archive).

Prérequis qualifiés : **Unity 6000.4.0f1**, **Input System 1.19.0** (backend actif), et pour
le template **URP 17.4.0** et **ugui 2.0.0**. `astra.melee` référence l'assembly du framework
Astra `Astra.Framework.Game.HUD.Runtime` : le projet consommateur doit embarquer le framework.
Plateforme déclarée : macOS. Deux joueurs peuvent partager un clavier (schémas gauche et droit).

Après l'import du template, appliquer `Assets/AstraContent/astra.template.melee/composition.json`
avec Astra Setup (action « Apply composition with Setup » de la fiche du Hub).

Archives publiées via GitHub Releases, tags `melee-v1.2.0` et `template-melee-v1.2.1`
(`template-melee-v1.2.0` reste disponible, sans le guide).
