# Match3

Deux entrées de catalogue pour un puzzle match-3 tactile.

- **`astra.match3` 2.0.0** (catégorie `Gameplay`) : règles, plateau et scoring en C# pur et
  testé. Simulation temps réel à ticks fixes, réservation de cases, swipes pendant les
  cascades, power-ups Royal Match (Rocket, TNT, Propeller, Light Ball) et combos.
- **`astra.template.match3` 2.0.1** (catégorie `Templates`) : template de genre prêt à jouer,
  avec scène de départ, niveaux, prefabs et un `composition.json`. Il dépend exactement de
  `astra.match3` 2.0.0, que le Hub importe dans la même transaction. Le guide d'extension est
  livré dans le pack (`README.md` en anglais, `README.fr.md` en français) : niveaux, power-ups,
  motifs, combos, objectifs et limites actuelles.

Licence : MIT. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **Input System 1.19.0** (backend actif), et pour
le template **URP 17.4.0** et **ugui 2.0.0**. `astra.match3` référence l'assembly du
framework Astra `Astra.Framework.Game.HUD.Runtime` : le projet consommateur doit embarquer le
framework. Plateformes déclarées : macOS, Android, iOS.

Après l'import du template, appliquer `Assets/AstraContent/astra.template.match3/composition.json`
avec Astra Setup (action « Apply composition with Setup » de la fiche du Hub).

Archives publiées via GitHub Releases, tags `match3-v2.0.0` et `template-match3-v2.0.1`
(`template-match3-v2.0.0` reste disponible, sans le guide).
