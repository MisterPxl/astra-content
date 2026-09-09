# Ariadne - UI Poolable Collections

Collections UGUI virtualisées : le nombre de cellules instanciées reste borné par la
zone visible et son buffer, quelle que soit la taille de la collection.

## Démarrer

1. Créer un `ScrollRect` avec son viewport et son content.
2. Ajouter `CollectionViewBehaviour` sur l'objet du `ScrollRect`, renseigner
   `Scroll Rect`, `Viewport`, `Content` et un prefab de cellule.
3. Choisir la disposition : `Vertical`, `Horizontal` ou `Grid`, puis la taille d'item,
   l'espacement, le padding et le buffer.

Une cellule dérive de `CollectionViewCell<TData>` et implémente `Bind(TData, int)` :

```csharp
public sealed class ScoreCell : CollectionViewCell<int>
{
    [SerializeField] private TMP_Text _label;
    public override void Bind(int data, int index) => _label.text = $"{index}: {data}";
}
```

Alimenter la vue depuis le code :

```csharp
_view.SetItems(scores);                                  // liste simple
_view.SetSections(sections, s => s.Header, s => s.Items); // sections avec en-têtes
_view.ScrollTo(120, CollectionViewScrollAlignment.Center);
```

## Ce qui est public

`CollectionViewBehaviour`, `ICollectionView` / `CollectionView`, `CollectionViewCell` et
`CollectionViewCell<TData>`, `CollectionViewContext`, les sources de données
(`CollectionViewListDataSource<TData>`, `CollectionViewSectionDataSource<...>`,
`ICollectionViewDataSource`), les quatre interfaces de fourniture optionnelles
(`ICollectionViewItemSizeProvider`, `ICollectionViewCellPrefabProvider`,
`ICollectionViewFullSpanItemProvider`, `ICollectionViewBindIndexProvider`) et les
énumérations. `CollectionViewSectionDataSource` expose en plus `TryGetVirtualIndex`
et `ReloadData` comme méthodes, sans interface : une source sectionnée est la seule
à en avoir besoin.

Renseigne `Header Prefab` sur le composant pour donner aux en-têtes de section leur
propre cellule. Les cellules d'item reçoivent l'index de leur item dans la liste
aplatie, pas l'index de la ligne qu'elles occupent.

Les adaptateurs de disposition, le pool, l'état interne et les structs de placement sont
`internal` : ils peuvent changer sans casser ton code.

## Démos

`Demo/` contient trois démos jouables (liste verticale, liste horizontale, grille) et
leurs cellules. Elles font partie de l'assembly du pack et peuvent être supprimées.

Licence MIT, voir `LICENSES/LICENSE.txt`.
