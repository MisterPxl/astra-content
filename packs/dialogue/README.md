# Dialogue

Pack public `astra.dialogue` pour Astra Content Hub. Il regroupe un éditeur de
conversations à bulles (Dialogue Studio), un moteur d'exécution autonome avec
conditions et actions extensibles, des échanges XLSX à comparaison à trois versions,
une présentation UI Toolkit inspirée d'Animal Crossing et la démo du verger.

## Catalogue `gameplay-v26` : contrat Content Hub V2

Contrat `schemaVersion: 2` : les dépendances de contenu sont des plages de versions (`minimumVersion` inclus, `maximumVersionExclusive` exclu). Contenu inchangé : seul `pack.json` (métadonnées) change, d'où un patch. Requiert le framework à partir du tag `framework-game-2026-10-19` (modèle Core : `framework-core-2026-10-19`) ; un Hub plus ancien ne lit pas ce catalogue.

- `astra.dialogue` **0.1.5** (au lieu de 0.1.4) : release `dialogue-v0.1.5`, 93 fichiers, 96463 octets, SHA-256 `9b0a765815c78abcaed99b086dc106cead00b5f9eb4baf574ff38f7c7b110ced` ; dépendances de contenu (plages) : aucune.

Version **0.1.4**. Elle ajoute l'événement `DialogueSession.ChoiceSelected` (choix pris, avant
d'entrer dans sa cible), utilisé par les objectifs de dialogue du pont
[Quests ↔ Dialogue](../quests-dialogue/README.md). La 0.1.3 avait ajouté
`DialogueRunner.SessionStarted`, pour attacher les observers de progression. La 0.1.2, première
publication publique, apportait les correctifs de revue (validation alignée sur les ports,
import « nouvelle conversation » par feuille, aperçu d'import avec dry-run, lecture de classeur
plus stricte). Les versions 0.1.2 et 0.1.3 restent disponibles.

Licence : code, formes de démonstration et syllabes synthétiques Astra sous MIT
(`LICENSES/LICENSE.txt` dans le pack). Aucun asset tiers.

Prérequis : Unity 6000.4.0f1 et les modules UI Toolkit, UI, JSON, IMGUI, audio et
conversion d'image. Indifférent au pipeline de rendu ; qualifié sur macOS.

Archive publiée via GitHub Releases sous le tag `dialogue-v0.1.4`. Le guide complet
du pack est [PackReadme.md](PackReadme.md) ; la qualification de la 0.1.2 (34 tests EditMode,
4 PlayMode, export, import vierge et mise à jour 0.1.1 → 0.1.2) est décrite dans le
dépôt auteur `AI_Testing_Sandbox`, `Documentation/Astra/ContentHub/Dialogue/README.md`.
