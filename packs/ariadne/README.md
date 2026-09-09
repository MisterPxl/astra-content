# Ariadne

Pack public `astra.ariadne` pour Astra Content Hub. Collections UGUI virtualisées :
listes verticales et horizontales, grilles, cellules recyclées par pool, tailles
d'item variables, items pleine largeur, sources sectionnées avec leur propre prefab
d'en-tête, et trois démos jouables sous `Demo/`.

Licence : code et démos Astra sous MIT (`LICENSES/LICENSE.txt` dans le pack). Aucun
asset tiers.

Prérequis : un seul, `com.unity.ugui` 2.0.0 ou plus récent, qui fournit aussi
`Unity.TextMeshPro`. Indifférent au pipeline de rendu et à la plateforme. Tout
Unity 6 est accepté (`6000.0.0f1` inclus à `7000.0.0a1` exclu) ; `6000.4.0f1` est la
version qualifiée.

Deux assemblies : `Astra.Ariadne.Runtime`, posée à la racine du payload et couvrant
`Demo/`, et `Astra.Ariadne.Editor`. Les adaptateurs de disposition, le pool, l'état
interne et les structs de placement sont `internal`.

Ce pack est extrait du framework Astra, avec les GUID d'origine de ses 40 scripts :
un prefab créé avant l'extraction se recharge intact après installation du pack.

Archive publiée via GitHub Releases sous le tag `ariadne-v1.0.0`. Le guide du pack
est [PackReadme.md](PackReadme.md) ; la qualification (23 tests EditMode, 10 PlayMode,
export reproductible, refus sans UGUI, import vierge, fixture historique, mise à jour
1.0.0 → 1.0.1 et retrait) est décrite dans le dépôt auteur `AI_Testing_Sandbox`,
`Documentation/Astra/ContentHub/Ariadne/README.md`.
