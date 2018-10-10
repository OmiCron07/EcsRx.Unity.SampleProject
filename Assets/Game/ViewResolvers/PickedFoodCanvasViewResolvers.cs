using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Events;
using EcsRx.Groups;
using EcsRx.Unity.Dependencies;
using EcsRx.Unity.Systems;
using EcsRx.Views.Components;
using Game.Components;
using Game.SceneCollections;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.ViewResolvers
{
  public class PickedFoodCanvasViewResolvers : PooledPrefabViewResolverSystem
  {
    private readonly GameObject _parent;


    /// <inheritdoc />
    public override IGroup Group { get; } = new Group(typeof(PickupFoodDisplayComponent), typeof(ViewComponent));

    /// <inheritdoc />
    protected override GameObject PrefabTemplate { get; }

    /// <inheritdoc />
    protected override int PoolIncrementSize { get; } = 2;


    /// <inheritdoc />
    public PickedFoodCanvasViewResolvers(PrefabCollection prefabs, IUnityInstantiator instantiator, IEntityCollectionManager collectionManager, IEventSystem eventSystem) : base(instantiator, collectionManager, eventSystem)
    {
      PrefabTemplate = prefabs[PrefabEnum.PickedFoodCanvas];
      _parent = new GameObject($"{PrefabTemplate.name}Pool");
    }

    /// <inheritdoc />
    protected override void OnPoolStarting()
    {
    }

    /// <inheritdoc />
    protected override void OnViewAllocated(GameObject view, IEntity entity)
    {
      view.transform.parent = null;
    }

    /// <inheritdoc />
    protected override void OnViewRecycled(GameObject view, IEntity entity)
    {
      view.transform.parent = _parent.transform;
    }
  }
}