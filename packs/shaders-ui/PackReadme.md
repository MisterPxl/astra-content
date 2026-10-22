# Astra Shaders UI

Pack Content Hub **astra.shaders.ui** : shaders uGUI et les composants qui leur fournissent leurs données par
vertex. Les éléments restent des `Graphic` ordinaires : ils fonctionnent avec `Mask` (stencil), `RectMask2D`
(rectangle de découpe, bords doux compris), `CanvasGroup` et les canvas Overlay, Camera et World. Ne déplacez pas
le dossier du pack : le shader de dissolve inclut la bibliothèque `astra.shaders.core` par un chemin relatif.

## Shaders et composants

| Composant | Shader | Usage |
|---|---|---|
| `AstraShape` | `Astra/UI/Shape` | Rectangle SDF : rayon par coin, bordure de couleur propre, dégradé linéaire (angle) ou radial, ombre portée floue et décalée, texture optionnelle. Boutons, panneaux, barres de vie. |
| `AstraRing` | `Astra/UI/Ring` | Jauge circulaire : remplissage, segments séparés par un écart en degrés, angle de départ, épaisseur, bouts arrondis ou plats, piste de fond. Endurance, recharge, chargement. |
| `AstraFoilTilt` | `Astra/UI/Foil` | Carte holographique sur une `Image` : bandes irisées et reflet décalés par l'inclinaison, qui suit le pointeur et revient au repos (balancement optionnel). Masque de foil (canal R) sur le matériau. |
| `AstraUIDissolve` | `Astra/UI/Dissolve` | Dissout une `Image` ou un `Text` avec bord brûlant et zone carbonisée, `Play()` / `Reverse()`, événement `Completed` (C# et `UnityEvent`) ; l'élément ne reçoit plus les clics une fois dissous. |

Toutes les données (rayons, couleurs, remplissage, inclinaison, quantité de dissolve) passent par les UV du mesh
et non par le matériau : tous les éléments d'un même shader partagent son matériau et sont regroupés dans le même
draw call. Le pack fournit ce matériau partagé dans `Materials/` ; ajouter un composant depuis l'éditeur sur un
élément au matériau par défaut l'assigne, et l'inspecteur avertit (bouton **Use material**) si le shader n'est pas
le bon. Les couleurs secondaires sont empaquetées en 8 bits par canal, sans HDR.

Les composants demandent eux-mêmes au canvas les canaux `TexCoord1` à `TexCoord3` qui leur manquent (un message
dans la console quand ils sont ajoutés).

Les formes sont dessinées à l'intérieur du `RectTransform` avec une marge d'un pixel et demi pour l'anticrénelage ;
l'ombre est un second quad dessiné sous la forme. Le foil lit son masque avec les UV de l'image : gardez les sprites
foil hors des atlas, ou donnez un matériau à chaque carte. Un nouveau composant déclare son shader et son matériau
par l'attribut `[AstraUIMaterial("shader", "matériau")]`, rien n'est à enregistrer ailleurs.

## Démo

`Demo/Generated/Ui.unity` : un HUD (barre de vie en dégradé, jauges d'endurance segmentée, de recharge et de
bouclier, trois boutons), un éventail de cartes holographiques qui s'inclinent sous le pointeur dont une brûle et
revient, et deux panneaux qui découpent un élément de chaque shader, l'un par `Mask`, l'autre par `RectMask2D`.
**Hit**, **Heal** et **Burn** (ou **Espace**) pilotent la démo ; en lecture automatique (par défaut) tout se
répète seul. **Tools > Astra > Shaders > Build UI Demo** la régénère (sous `Assets/AstraUIDemo` quand le pack est
installé par le Hub).

## Galerie

`Demo/Generated/UiGallery.unity` : une scène fixe, sans interaction, qui montre les réglages côte à côte. Une
rangée par thème, un élément étiqueté par réglage : formes (rayons, pilule, coins asymétriques, bordure, ombre
portée), dégradés (linéaires, radial, avec bordure, par texture), anneaux (arcs, bouts ronds ou plats, segments,
disque plein, angle de départ), foil (force, largeur des bandes, reflet doré, sans masque), dissolve et découpe
(seuils, texte, `CanvasGroup`, `RectMask2D` adouci).
**Tools > Astra > Shaders > Build UI Gallery** la régénère (sous `Assets/AstraUIDemo` quand le pack est installé
par le Hub).

## Budgets

Variants de fragment, build macOS de la démo et de la galerie : 4 par shader (`UNITY_UI_CLIP_RECT` × `UNITY_UI_ALPHACLIP`,
budget 16). 200 formes de couleurs, rayons, bordures et dégradés différents : un seul sous-lot de canvas, comme une
seule forme (test PlayMode).

## Licence

MIT, voir `LICENSES/LICENSE.txt`.
