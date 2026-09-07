# Astra Vehicles

Pack unique `astra.vehicles`, issu de MotionTest, sous licence MIT.

## Contenu

- Voiture sportive : `Demo/Car/MotionSportsCar.prefab` et `ArcadeSportsCar.prefab`.
- Bateau à moteur : `Demo/Boat/PlaningBoat.prefab` et `ArcadePlaningBoat.prefab`.
- Avion léger à hélice : `Demo/Plane/LightPlane.prefab` et `ArcadeLightPlane.prefab`.
- Jet : `Demo/Plane/NormalJetPlane.prefab` et `ArcadeJetPlane.prefab`.
- Scènes : `Demo/Car/CarDemo.unity`, `Demo/Boat/BoatDemo.unity`, `Demo/Plane/PlaneDemo.unity`.
- Configurations physiques, modèles procéduraux, matériaux URP, caméra de poursuite et télémétrie.

Les assemblies `Motion.Vehicles.Core`, `.Car`, `.Boat`, `.Plane` sont internes au même
pack. Aucun package Motion UPM ni autre pack Astra n'est nécessaire.

## Démarrer

Installer séparément Input System 1.19.0 et URP 17.4.0, activer le pipeline URP
et **Active Input Handling > Input System Package (New)** ou **Both**.
Importer le pack via Astra Content Hub, ouvrir une scène sous
`Assets/AstraContent/astra.vehicles/Demo/` et lancer Play.
Version qualifiée : Unity 6000.4.0f1, macOS. Unités SI ; 1 unité = 1 mètre.
Pas de changement automatique des réglages du projet.

| Véhicule | Clavier |
| --- | --- |
| Voiture | W/S accélérer/freiner, A/D diriger, Espace frein à main, Q marche arrière, R réinitialiser |
| Bateau | W/S gaz/inverser, A/D diriger, Q/E trim |
| Avion et jet | W/S tangage, A/D roulis, Q/E lacet, Ctrl/Shift gaz, F volets, Espace freins, C aérofrein, Alt boost, Retour arrière réinitialiser |

Les touches correspondent aux positions physiques du clavier Input System.
Les mappings manette et l'intégration des composants sont détaillés dans
`Car/README.md`, `Boat/README.md` et `Plane/README.md`.
Pour essayer une variante, remplacer le véhicule actif et retargeter la caméra et
la télémétrie ; les deux variantes ne doivent pas recevoir les mêmes inputs à la fois.
Un bateau nécessite une surface `FlatWaterSurface` dans la scène.

Les menus **Motion Vehicles** restent disponibles pour régénérer les démos dans
le dossier du pack. Ces commandes remplacent leurs assets générés : conserver
ses personnalisations dans un dossier distinct avant de les utiliser.

Les GUID des assets existants sont conservés, avec des GUID stables pour les types
Unity extraits dans leurs propres fichiers. Ne pas importer dans MotionTest qui
contient déjà les mêmes GUID et assemblies. `PROVENANCE.json` recense les empreintes
des sources utilisées, y compris les modifications locales présentes à l'assemblage.
