# Tactics

RPG tactique sur grille carrée : simulation C# déterministe, démo autonome et campagne Astra de
trois chapitres. Huit personnages originaux, six classes et douze objets. Préparation du
déploiement, échanges, prévision de combat, IA, sauvegarde et Continue sont inclus.

Importer **astra.template.tactics** dans le Content Hub, puis appliquer sa composition avec
Astra Setup. La dépendance **astra.tactics** est installée dans la même transaction.
Unity **6000.4.0f1**, URP, Input System et uGUI ; qualification sur macOS uniquement.

## Catalogue `gameplay-v30` : framework 3.0.0

Requiert le framework à partir du tag `framework-game-2026-11-02` (modèle Core :
`framework-core-2026-11-02`), garanti par le prérequis de capacité `astra-framework` [3.0.0, 4.0.0) :
le Hub refuse l'import sur un framework 2.x, pour lequel les versions 1.0.0, 2.0.0 et 2.1.0 restent
listées. Les retours de gameplay passent par le package Pulse (`com.misterpxl.pulse` [1.0.0, 2.0.0),
tag `v1.0.0`), à déclarer dans le manifeste du projet.

- `astra.tactics` **2.2.0** : release `tactics-v2.2.0`, 352 fichiers, 337190 octets, SHA-256 `872712bb892dd9199b55f79895abcd380519c0ffdde438fdf14a7074f2b82800` ; dépendances de contenu (plages) : aucune.
- `astra.template.tactics` **2.2.0** : release `template-tactics-v2.2.0`, 399 fichiers, 332267 octets, SHA-256 `86ee3b8f0664f03aa2c22e682c2485920f3c2b26375fdd84d5937febc35430d1` ; dépendances de contenu (plages) : `astra.tactics` [2.2.0, 3.0.0).

## Versions précédentes

- **2.1.0** (`gameplay-v29`) : **Tactics Studio** remplace l'éditeur de cartes. Fenêtre de chapitres
  avec canevas à sept modes, pinceaux extensibles, onglets Issues et Preview (zone de danger, portées,
  prévision, simulation de l'IA), bouton Play, import et export texte, outil de peinture dans la vue
  Scene, règles Aegis de chapitre et de ruleset.
- **2.0.0** (`gameplay-v28`) : présentation de bataille à la Fire Emblem (surbrillances, flèche de
  trajet, menus d'action, d'objet et d'échange, prévision à deux colonnes, montée de niveau, animations
  de combat, promotion), coordinateur d'UI partagé par la démo et la bataille Astra.
- **1.0.0** (`gameplay-v27`) : première version.

## Utilisation

La démo autonome est `Scenes/TacticsDemo.unity`. Dans Astra, Start ouvre la préparation.
Flèches/manette : curseur ; Entrée : confirmer ; Échap : annuler ; E : finir le tour ; P : pause.
Souris : sélectionner/choisir une action. WASD/stick droit : caméra ; +/− ou molette : zoom.
Continue reprend la préparation, la bataille ou le résultat sauvegardé.

Les informations et actions sont regroupées dans un panneau préfabriqué. UI runtime en anglais ;
localisation complète, dialogue, boutique, soutien, audio et qualification mobile hors version.
Le contenu et les primitives sont originaux, sous licence MIT.

Qualification de la 2.2.0 : neuf parcours PlayMode du template sur des consommateurs vierges
(dépendance la plus récente et minimale), après import, vérification des assets, 20 modules de
composition et Aegis 0/0/0.
