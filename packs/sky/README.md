# Sky

Pack public `astra.sky` pour Astra Content Hub. Ciel jour/nuit pour URP, pour les scènes où
l'heure change pendant le jeu : profil horaire (`SkyProfile`), ambiante Trilight, brouillard et
soleil pilotés par l'heure, une seule lumière directionnelle pour le soleil puis la lune, shader
de ciel `Astra/Sky` en une passe sans texture (dégradé, disques du soleil et de la lune, étoiles,
une couche de nuages, raccord avec le brouillard), réflexions temps réel optionnelles, horloge de
jeu et fenêtres horaires pour le gameplay (`SkyTimeWindow`, `SkyTimeTrigger`, `SkyLightSwitch`),
démo DayCycle.

Licence : code, shaders et contenu de démonstration Astra sous MIT
(`LICENSES/LICENSE.txt` dans le pack). Aucun asset tiers.

Prérequis : Unity 6000.4.0f1, Universal Render Pipeline 17.4+ et Input System 1.19+ (commandes
de la démo, backends Input System, Legacy et Both). `SkyReflections` exige **Realtime Reflection
Probes** dans le niveau de qualité actif ; son inspecteur le signale et propose de l'activer, sans
le faire seul. Qualifié sur macOS ; le Hub ne modifie ni les packages ni les réglages de rendu.

Version **0.1.0** : première version.
Archive : `sky-v0.1.0`, 119 fichiers, 99339 octets,
SHA-256 `169fc336c793fb216a819a712339679ddb5394346f1285eb425cd57ee406643b`.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Sky/README.md` et `Documentation/Astra/SkyValidation.md`.
