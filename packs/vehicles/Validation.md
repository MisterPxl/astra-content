# Qualification Vehicles 1.0.0

Qualification du 7 septembre 2026 sur macOS, Unity 6000.4.0f1, Input System
1.19.0 et URP 17.4.0. Source : MotionTest avec ses modifications locales présentes.

| Vérification | Résultat |
| --- | --- |
| Export répété depuis le même auteur finalisé | Deux ZIP strictement identiques |
| Validation JSON et concordance manifeste / pack.json | Réussie |
| Inventaire, tailles et SHA-256 de chaque fichier | Réussis |
| Import sur le dossier auteur occupé | Refusé |
| Input System / URP / backend d'inputs absents | Import refusé, aucun asset copié |
| Import via la transaction réelle du Hub | Reçu Imported après redémarrage Unity |
| Packages/manifest.json et packages-lock.json du consommateur | Inchangés par l'import |
| Scripts, références sérialisées, matériaux, configurations, GUID | Valides ; aucun script manquant ni GUID dupliqué |
| Tests EditMode Motion | 34 réussis, 0 échec |
| Tests PlayMode Astra Vehicles | 2 réussis, 0 échec |
| Téléchargement public sans authentification | Taille et SHA-256 identiques à l’archive qualifiée |
| Client réel du Hub sur le catalogue public | Lecture en ligne, résolution, téléchargement HTTPS et extraction vérifiés |

Les tests PlayMode instancient chacun des huit prefabs pendant 100 pas de physique,
vérifient les scripts et les valeurs finies de position/vitesse, puis chargent les
trois scènes et les simulent chacune pendant 100 pas. Cela constitue un test de
fonctionnement initial ; ce n'est pas une qualification exhaustive du comportement
en conduite, en vol ou sur toutes les plateformes.

Archive : **257 fichiers**, **233 714 octets compressés**, **820 466 octets décompressés**.

SHA-256 :

```text
dd31d8223616477211349f0ab1178a235ea3e4629291286ba4febd3631830304
```

La recette `tools/vehicles/qualify.py` produit les logs par étape et les résultats
XML EditMode / PlayMode dans le dossier de sortie choisi. Aucun cache Unity,
réglage de projet, test ou archive ZIP n'est ajouté à l'historique du catalogue.
