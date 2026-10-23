# Tactics 1.0.0

RPG tactique sur grille carrée : simulation C# déterministe, éditeur de cartes, démo autonome et
campagne Astra de trois chapitres. Huit personnages originaux, six classes et douze objets.
Préparation du déploiement, échanges, prévision de combat, IA, sauvegarde et Continue sont inclus.

Importer **astra.template.tactics 1.0.0** dans le Content Hub, puis appliquer sa composition avec
Astra Setup. La dépendance **astra.tactics 1.0.0** est installée dans la même transaction.
Unity **6000.4.0f1**, URP, Input System et uGUI ; qualification sur macOS uniquement.

[Pack gameplay](https://github.com/MisterPxl/astra-content/releases/tag/tactics-v1.0.0) ·
[Template](https://github.com/MisterPxl/astra-content/releases/tag/template-tactics-v1.0.0).

La démo autonome est `Scenes/TacticsDemo.unity`. Dans Astra, Start ouvre la préparation.
Flèches/manette : curseur ; Entrée : confirmer ; Échap : annuler ; E : finir le tour ; P : pause.
Souris : sélectionner/choisir une action. WASD/stick droit : caméra ; +/− ou molette : zoom.
Continue reprend la préparation, la bataille ou le résultat sauvegardé.

Les informations et actions sont regroupées dans un panneau préfabriqué. UI runtime en anglais ;
localisation complète, dialogue, boutique, soutien, audio et qualification mobile hors version.
Le contenu et les primitives sont originaux, sous licence MIT.

Qualification : 223 tests EditMode, trois parcours PlayMode Astra et un parcours souris autonome.
Les consommateurs vierges avec dépendance la plus récente et minimale passent l’import,
la vérification des assets, 20 modules de composition, Aegis 0/0/0 et les trois parcours Astra.
