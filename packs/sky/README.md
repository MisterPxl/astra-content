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

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.sky` **0.2.2** (au lieu de 0.2.1) : release `sky-v0.2.2`, 119 fichiers, 100801 octets, SHA-256 `31c4f75a580b66dbb58056ce930b0c972bb605fda1c2c2c7042f21f52f260026` ; dépendances de contenu (plages) : `astra.shaders.core` [0.1.2, 0.2.0).

Version **0.2.1** : la dépendance passe sur `astra.shaders.core` 0.1.1, sans autre changement.
Archive : `sky-v0.2.1`, 119 fichiers, 100516 octets,
SHA-256 `95cf19e7a7cf9ae67da58ada37f5f3ac1cd55a76f8535617d68cffba62253d69`.

Version **0.2.0** : le bruit des nuages et le hash des étoiles viennent de `astra.shaders.core` 0.1.0, que le Hub importe dans la même transaction, avec des formules identiques (rendu au pixel près comme en 0.1.1). La 0.1.1 corrigeait Build Demo pour un pack installé par le Hub : il écrit sous `Assets/SkyGenerated` et plus rien dans le pack installé.
Archive : `sky-v0.2.0`, 119 fichiers, 100440 octets,
SHA-256 `af3fe5146f75dcb0d969ff54eb1ba24e200ba97329e2a7f357e6a201b4905d7b`.
La 0.1.0 (`sky-v0.1.0`) reste disponible.

Le guide complet du pack est [PackReadme.md](PackReadme.md) ; la préparation et la
qualification sont décrites dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Sky/README.md` et `Documentation/Astra/SkyValidation.md`.
