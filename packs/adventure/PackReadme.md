# Adventure

Un seul pack contient le contrôleur, les inputs et la démo humanoïde animée.

## Démarrer

Dans un projet Unity 6000.4.0f1, préparer Input System 1.19.0 et URP 17.4.0,
sélectionner un pipeline URP et activer le nouveau backend Input System dans les
Player Settings. Le Hub ne modifie pas ces réglages.

Ouvrir `Demo/Generated/AdventureDemo.unity` sous le dossier du pack puis lancer Play.
La scène fonctionne sans Bootstrap, Aegis, Valkyrie ou Helios.

| Action | Clavier / souris | Manette |
| --- | --- | --- |
| Déplacement / caméra | WASD ou flèches / souris | Stick gauche / droit |
| Saut | Espace | A / bouton sud |
| Sprint | Maj gauche maintenu | Clic stick gauche |
| Escalade / lâcher | E maintenu / C | LB / B |
| Esquive | Alt gauche | B au sol |
| Verrouiller / changer de cible | Tab / Q | Clic stick droit / D-pad droite |
| Ramasser une arme | F | X / bouton ouest |
| Épée / tendre l’arc | Clic gauche | Gâchette droite |
| Viser avec l’arc | Clic droit maintenu | Gâchette gauche |
| Tirer | Relâcher l’attaque en visant | Relâcher la gâchette droite |
| Libérer le curseur | Échap | — |

## Contenu éditable

- `Controller/` : FSM, locomotion, physique, caméra, combat, IK et intégration Input System.
- `Demo/Runtime/` : composants de présentation et interactions de la scène.
- `Demo/Generated/` : scène, prefab du joueur, armes, configuration et Animator.
- `Demo/Art/` : modèles, animations, textures, shader et provenance Quaternius.

Les assemblies `Adventure.Controller`, `Adventure.Input` et `Adventure.Sample`
restent distinctes à l’intérieur du même pack. Aucun autre pack n’est nécessaire.
Les tests et générateurs de la démo restent dans le projet d’auteur.

Le prefab `Demo/Generated/AdventurePlayer.prefab` peut être placé dans une autre scène.
Conserver les `.meta` avec les assets lors d’un déplacement pour préserver les références.
Un projet contenant déjà les sources Adventure doit les migrer avant cet import :
le Hub bloque leurs GUID existants.

Ce contenu constitue une base de prototype : plateformes mobiles, natation, vol,
réseau et animations dédiées d’arc/escalade ne sont pas implémentés. Ces dernières
utilisent des poses procédurales. Voir les notices dans `LICENSES/` et
`Demo/Art/Quaternius/`. Le code et la démo Astra sont distribués sous licence MIT ; les assets Quaternius conservent leurs notices CC0.
