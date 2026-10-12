# Match3

Deux entrées de catalogue pour un puzzle match-3 tactile.

- **`astra.match3` 2.0.1** (catégorie `Gameplay`) : règles, plateau et scoring en C# pur et
  testé. Simulation temps réel à ticks fixes, réservation de cases, swipes pendant les
  cascades, power-ups Royal Match (Rocket, TNT, Propeller, Light Ball) et combos. La 2.0.1
  ajoute l'identifiant de module `match3.module` ; règles de jeu inchangées depuis 2.0.0. Elle
  requiert le framework Game Flow Foundation (`Game.FlowPresentation`) : le Hub refuse l'import
  sur une copie plus ancienne.
- **`astra.template.match3` 2.0.2** (catégorie `Templates`) : template de genre prêt à jouer,
  avec scène de départ, niveaux, prefabs et un `composition.json` (identifiant de module
  `match3.module`, sans avertissement de Setup). Il dépend exactement de `astra.match3` 2.0.1,
  que le Hub importe dans la même transaction. Le guide d'extension est livré dans le pack
  (`README.md` en anglais, `README.fr.md` en français) : niveaux, power-ups, motifs, combos,
  objectifs et limites actuelles.

Licence : MIT. Aucun asset tiers.

Prérequis qualifiés : **Unity 6000.4.0f1**, **Input System 1.19.0** (backend actif), et pour
le template **URP 17.4.0** et **ugui 2.0.0**. `astra.match3` référence l'assembly du
framework Astra `Astra.Framework.Game.HUD.Runtime` et, depuis la 2.0.1,
`Astra.Framework.Game.FlowPresentation.Runtime` (prérequis déclaré par les deux packs) : le
projet consommateur doit embarquer le framework Game Flow Foundation. `astra.match3` 2.0.0 et
`astra.template.match3` 2.0.1 restent disponibles pour les projets qui ont encore l'ancien
framework. Plateformes déclarées : macOS, Android, iOS.

Après l'import du template, appliquer `Assets/AstraContent/astra.template.match3/composition.json`
avec Astra Setup (action « Apply composition with Setup » de la fiche du Hub).

Archives publiées via GitHub Releases, tags `match3-v2.0.1` et `template-match3-v2.0.2`
(`match3-v2.0.0`, `template-match3-v2.0.0` et `template-match3-v2.0.1` restent disponibles).
