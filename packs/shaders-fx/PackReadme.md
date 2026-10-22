# Astra Shaders FX

Pack Content Hub **astra.shaders.fx** : shaders d'effets pour URP (Universal Renderer, sans 2D Renderer) et les
composants qui pilotent flash, dissolve et impacts de bouclier. Écrits en HLSL sur la bibliothèque
`astra.shaders.core`. Ne déplacez pas le dossier du pack : ses shaders incluent la bibliothèque par un chemin
relatif.

## Shaders

| Shader | Usage |
|---|---|
| `Astra/Fx/Sprite` | Sprite non éclairé pour `SpriteRenderer` : teinte, flash, contour depuis le voisinage alpha, dissolve. Ennemis et vaisseaux de shmup, pièces de match-3. |
| `Astra/Fx/Shield` | Bouclier additif : fresnel, lueur à l'intersection avec la scène, motif hexagonal ou Voronoi qui défile, jusqu'à 8 ondes d'impact. |
| `Astra/Fx/Trail` | Pour `TrailRenderer` / `LineRenderer` en `Texture Mode` Stretch : couleur de la tête à la queue, érosion par bruit qui ronge surtout la queue, tête, queue et bords adoucis, de mélange alpha à additif. |
| `Astra/Fx/Distortion` | Réfraction de la texture opaque de la caméra : brume de chaleur (normal map qui défile) ou onde de choc (anneau). La force suit l'alpha de la couleur de vertex, donc la durée de vie d'une particule. |
| `Astra/Fx/ParticleDissolve` | Particule non éclairée (alpha, additif, prémultiplié) qui se dissout pendant sa vie, avec fondu de profondeur optionnel. |

Sprite : le contour est dessiné dans le mesh du sprite. Laissez une marge transparente autour du dessin et
choisissez le `Mesh Type` Full Rect à l'import, sinon le contour est coupé.

ParticleDissolve : dans le Particle System Renderer, activez les **Custom Vertex Streams** `Position`, `Color`,
`UV`, `Custom1.xy` ; dans le module **Custom Data**, `Custom1` en Vector : X = quantité de dissolve sur la durée de
vie (courbe de 0 à 1), Y = décalage aléatoire du bruit par particule. `Dissolve Bias` s'ajoute à X.

### Textures de caméra

`Shield` (intersection) et le fondu de profondeur de `ParticleDissolve` lisent la texture de profondeur de la
caméra, `Distortion` la texture opaque. Le pack ne modifie jamais l'asset URP : l'inspecteur du matériau
avertit quand l'asset URP actif les a coupées et propose un bouton qui le sélectionne. Une caméra peut aussi les
demander elle-même (`Depth Texture` / `Opaque Texture` sur `On`), comme celle de la démo. Un shader déclare ce
dont il a besoin par le tag de SubShader `"AstraRequires" = "DepthTexture OpaqueTexture:_UN_MOT_CLE"` (le
suffixe limite le besoin aux matériaux qui activent le mot-clé).

## Composants

| Composant | Rôle |
|---|---|
| `AstraHitFlash` | Fait flasher une liste de renderers vers une couleur, durée et courbe réglables, `Play()`. Option temps non mis à l'échelle pour flasher pendant un hit stop. |
| `AstraDissolve` | Dissout une liste de renderers sur une durée (`Play()`) ou les fait revenir (`Reverse()`), événement `Completed` (C# et `UnityEvent`). Une fois dissous, les renderers sont désactivés (option). |
| `AstraShieldHits` | `RegisterHit(Vector3 worldPosition)` : tampon circulaire de 8 impacts en espace objet, envoyés au shader `Shield`. La durée d'une onde est celle du matériau (`Hit Duration`). |

Ils fonctionnent sur tout shader qui déclare les propriétés de `astra.shaders.core` : `Astra/Fx/Sprite`, et
`Astra/Stylized/Toon` de `astra.shaders.stylized` (dont le dissolve demande la case `Dissolve` du matériau).
Leur inspecteur avertit quand un renderer a un shader sans l'effet, ou un matériau Toon sans la case `Dissolve`.

Chaque composant pose un `MaterialPropertyBlock` seulement pendant l'effet (le renderer sort alors du SRP
Batcher) et l'efface à la fin, sans allocation par frame. Plusieurs effets peuvent tourner sur le même renderer :
`AstraPropertyBlocks` compte les propriétaires, le dernier efface le bloc, les autres remettent seulement leurs
propres valeurs à zéro. Un autre bloc posé sur le même renderer par votre code est effacé avec. Un nouvel effet
est un nouveau composant qui utilise `AstraPropertyBlocks` de la même façon ; rien n'est à déclarer ailleurs.

## Démo

`Demo/Generated/Fx.unity` : un mannequin d'entraînement et trois vaisseaux en sprites, un bouclier visé par des
projectiles avec traînées, une onde de choc et une brume de chaleur devant un mur rayé, des braises qui se
dissolvent. **F** fait flasher les sprites, **D** les dissout ou les fait revenir, **Espace** tire sur le bouclier,
**S** déclenche l'onde de choc ; en lecture automatique (par défaut) tout se répète seul. **Tools > Astra > Shaders
> Build Fx Demo** la régénère (sous `Assets/AstraFxDemo` quand le pack est installé par le Hub).

## Galerie

`Demo/Generated/FxGallery.unity` : une scène fixe, sans interaction, qui montre les réglages côte à côte devant un
mur rayé (pour voir la distorsion). Une étagère par shader, six exemples étiquetés par étagère : sprite (contour,
flash, dissolve), bouclier (hexagones, Voronoï, fresnel, intersection), traînée (alpha, additive, érosion, bords
doux), distorsion (brume, anneau d'onde de choc) et particules (modes de fusion, fondu de profondeur, dissolve par
Custom1). **Tools > Astra > Shaders > Build Fx Gallery** la régénère (sous `Assets/AstraFxDemo` quand le pack est
installé par le Hub).

## Budgets

Variants de fragment après stripping URP, build macOS de la démo et de la galerie : Sprite 2, Shield 2, Trail 1,
Distortion 2, ParticleDissolve 2 (budget 16 par shader). Composants : 0 octet alloué sur 30 frames de flash, dissolve et
impacts (test PlayMode).

## Licence

MIT, voir `LICENSES/LICENSE.txt`.
