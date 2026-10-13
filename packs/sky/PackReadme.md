# Astra Sky

Pack Content Hub **astra.sky** : ciel jour/nuit pour URP, pour les scènes **où l'heure change pendant le jeu**. Compagnon d'Astra Grass, Snow et Water, sans dépendance vers eux.

Pour une heure fixe, le skybox procédural d'Unity et une lumière directionnelle suffisent. Faire tourner la lumière seule casse quatre choses : l'ambiance et les reflets restent à midi, le skybox n'a pas de nuit, la couleur du soleil, de l'ambiance et du brouillard ne suivent pas l'heure, et le gameplay ne sait pas quelle heure il est. Ce pack règle les quatre.

## Démarrage rapide

1. **Tools > Astra > Sky > Create Sky** ajoute un objet `Sky` dans la scène active (annulable). Supprimez ou désactivez l'éventuelle autre lumière directionnelle : `SkySun` ne pilote que la sienne, et la console avertit s'il en reste une.
2. **Tools > Astra > Sky > Create Sky With Reflections** fait la même chose et ajoute `SkyReflections` (voir plus bas). Si la scène a déjà un Sky, rien n'est créé : l'objet existant est sélectionné.
3. **Tools > Astra > Sky > Build Demo** génère `Demo/Generated/DayCycle.unity` : un village (maisons, lampadaires, fenêtres allumées de 19 h à 6 h), une mare réfléchissante et une caméra libre. Elle ne dépend d'aucun autre pack.
4. Play dans la démo : **Haut / Bas** accélèrent et ralentissent le temps, **Espace** met en pause, **N** saute au quart de journée suivant (00 h, 06 h, 12 h, 18 h). **WASD** déplace la caméra, **Q / E** descend et monte, bouton droit de la souris pour regarder, **Shift** pour aller plus vite. L'horloge s'affiche en haut à gauche. La démo démarre à 17 h avec une journée de 6 minutes.

Les scènes de jeu doivent vivre hors du dossier du pack.

## Composants

- `SkyClock` : l'horloge de jeu. Heure courante (`SkyTime` : jour + heure `[0, 24)`), `DayLengthMinutes` (minutes réelles par journée de jeu, 24 par défaut), `Paused`. Elle avance avec le temps **mis à l'échelle** : `Time.timeScale = 0` l'arrête aussi. `SetTime` saute à une heure ; `Advance` fait avancer à la main. Elle lève `Ticked(SkyTimeStep)` à chaque avancée et chaque saut. Pour sauvegarder l'heure, le jeu stocke `CurrentTime` et appelle `SetTime`.
- `SkyRenderer` : applique le `SkyProfile` à l'heure de l'horloge : ambiance Trilight, brouillard, soleil, globales du shader de ciel. Possède le matériau de ciel (`Astra/Sky`) affecté à `RenderSettings.skybox` tant qu'il est actif. En mode édition il montre l'heure d'aperçu `PreviewHour` sans toucher à l'horloge. À la désactivation il restaure le skybox, l'ambiance et le brouillard précédents.
- `SkySun` : une seule lumière directionnelle pour le soleil puis la lune. L'intensité et l'ombre tombent à zéro à l'horizon avant que la direction ne bascule, donc sans à-coup.
- `SkyReflections` : optionnel (voir « Réflexions »).
- `SkyTimeWindow`, `SkyTimeTrigger`, `SkyLightSwitch` : crochets de gameplay (voir plus bas).

Chaque composant référence son horloge explicitement ; il n'y a pas d'horloge globale cachée. `Reset` et les menus remplissent la référence quand la scène a exactement une horloge.

## Profils

Un `SkyProfile` décrit à quoi ressemble chaque heure : couleur et intensité du soleil et de la lune, orbite (inclinaison, orientation du nord), ambiance Trilight (ciel, équateur, sol), brouillard, zénith / horizon / sol du shader, disque solaire, étoiles, nuages (couverture, couleur, vitesse, direction) et réglages des réflexions (seuil en degrés de mouvement du soleil, résolution du probe). Le pack livre `Profiles/Temperate.asset` (par défaut) et `Profiles/Dusk.asset`.

Écrire un profil : dupliquer `Temperate` (Ctrl + D), le sortir du dossier du pack, l'assigner au `SkyRenderer`. Les dégradés vont de 0 h (gauche) à 24 h (droite), les courbes ont l'heure en abscisse (0 à 24). Dans l'inspecteur :

- une **bande de 24 h** montre le zénith, l'horizon, le sol, le soleil (couleur × intensité) et le brouillard ;
- le **curseur d'aperçu** pilote l'heure d'aperçu de tous les `SkyRenderer` des scènes ouvertes qui utilisent ce profil (hors Play, où le ciel suit l'horloge) ;
- un **avertissement** liste les valeurs différentes à 0 h et à 24 h, qui feraient un saut du ciel au passage de minuit.

## Crochets de gameplay

- `SkyTimeWindow` : plage horaire quotidienne, qui peut franchir minuit (19 h → 6 h). Elle est **basée sur l'état** : évaluée à l'activation, à chaque tick et à chaque saut, donc une scène chargée à 22 h démarre avec ses fenêtres déjà dans le bon état. Événements C# `Entered` / `Exited` et `UnityEvent` équivalents.
- `SkyTimeTrigger` : une heure précise ; `Reached` part quand un tick la franchit, minuit compris. Un saut ne le déclenche pas, sauf `FireOnJump`.
- `SkyLightSwitch` : posé sur une `SkyTimeWindow`, il allume ses `Light` et l'émission de ses `Renderer` (par `MaterialPropertyBlock` sur `_EmissionColor`) pendant la plage, avec un fondu optionnel. Les matériaux doivent avoir l'émission activée, une couleur d'émission non noire et un drapeau d'éclairage global qui n'est pas `EmissiveIsBlack` ; l'inspecteur avertit sinon (la démo génère ses matériaux ainsi).
- Une nouvelle réaction (PNJ qui dorment, cloches, spawn nocturne) est un nouveau composant qui écoute `SkyClock.Ticked` ou une fenêtre. Rien de partagé n'est modifié.

## Réflexions

`SkyReflections` pilote un `ReflectionProbe` temps réel (rafraîchi par script, faces découpées dans le temps, 128 px par défaut, aucun objet de la scène capturé, seulement le ciel) et en fait la source de réflexion de la scène : l'eau, le métal lisse et tout shader qui lit `GlossyEnvironmentReflection` suivent l'heure. Il ne rend que quand le soleil a bougé de plus que le seuil du profil, après un saut ou à l'activation, et jamais deux rendus en même temps.

- **Prérequis : Realtime Reflection Probes doit être activé dans le niveau de qualité courant** (Project Settings > Quality). Sinon le probe ne rend jamais et la scène garde la réflexion du skybox par défaut. L'inspecteur de `SkyReflections` l'indique et propose un bouton explicite ; le pack ne modifie jamais ce réglage tout seul. La démo l'active le temps de la session.
- **Machines modestes** : ne mettez pas `SkyReflections` (ou désactivez-le) ; le reste du pack n'en dépend pas. Vous pouvez aussi baisser la résolution du probe ou monter le seuil dans le profil.

## Ajouter un Sky aux démos Grass, Snow ou Water

Ouvrez la scène (`Meadow`, `Snowfield` ou `Lake`, de préférence une copie hors du pack), supprimez son objet `Directional Light`, puis **Create Sky** (ou **Create Sky With Reflections** pour que l'eau reflète le ciel de l'heure). Les générateurs de ces démos écrivent une ambiance et un brouillard fixes dans la scène : une fois `SkyRenderer` actif, ces valeurs sont **remplacées** à chaque tick par celles du profil. Les modifier à la main dans la scène n'a donc plus d'effet ; réglez le profil.

## Prérequis

- Unity **6000.4.0f1**, **Universal Render Pipeline** 17.4+.
- Plateforme qualifiée : macOS (desktop). Mobile reste une cible, qualifiée plus tard.

Prérequis démo : **Input System 1.19+**. Commandes compatibles avec Input System, Legacy et Both.

## Limites de la version 0.1

Pas de météo (pluie, neige qui tombe, orages), de nuages volumétriques ou 3D, de phases de lune ni d'astronomie réelle (latitude, saisons), pas d'ambiance `Skybox` par harmoniques sphériques, pas d'intégration au framework (sauvegarde, panneau Helios), pas de son, pas de vent synchronisé avec `GrassWind`, pas de HDRP ni de Built-in. Un seul calque de nuages procéduraux.
