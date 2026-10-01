# Astra Grass

Pack Content Hub **astra.grass** : herbe stylisée en touffes pour URP (desktop et mobile).

## Fonctionnalités

- Peinture au pinceau (ajout, effacement, teinte, hauteur) sur mesh ou Terrain via `Grass Paint`.
- Profil `GrassProfile` : forme des brins, atlas de texture, color shading, correction de perspective pour vues de dessus.
- Vent global (`GrassWind`) et interacteurs (`GrassInteractor`) avec pliage temps réel et trail map persistante.
- Rendu GPU : culling compute, buffers append par LOD, `RenderMeshIndirect`, repli sans compute.

## Démarrage rapide

1. **Tools > Astra > Grass > Build Feature Meadow** — scène de démo sous `Demo/Generated/Meadow.unity`.
2. **Tools > Astra > Grass > Create Grass Field** — nouvelle instance dans la scène active.
3. Sélectionner le `Grass Field`, activer l’outil **Grass Paint** dans la barre d’outils Scene.

Les scènes de jeu et données peintes doivent vivre **hors** du dossier du pack (copie via **Create Meadow Demo**).

## Assets clés

| Asset | Rôle |
| --- | --- |
| `GrassProfile` | Apparence, LOD, interaction |
| `GrassQualityProfile` | Réglages par niveau de qualité Unity |
| `GrassFieldData` | Touffes peintes (chunks) |
| `GrassField` | Composant scène + rendu |

## Prérequis

- Unity **6000.4.0f1**
- **Universal Render Pipeline** 17.4+
- **Input System** 1.19+ pour les commandes clavier de la démo (WASD/flèches, Tab pour la vue de dessus).

Les commandes de la démo prennent en charge Input System, Legacy et Both.
