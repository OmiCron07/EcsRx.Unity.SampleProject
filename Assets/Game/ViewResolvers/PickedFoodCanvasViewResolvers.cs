using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Events;
using EcsRx.Groups;
using EcsRx.Unity.Dependencies;
using EcsRx.Unity.Systems;
using Game.Components;
using Game.SceneCollections;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.ViewResolvers
{
  public class PickedFoodCanvasViewResolvers : PooledPrefabViewResolverSystem
  {
    /// <inheritdoc />
    public override IGroup Group { get; } = new Group(typeof(FoodDisplayComponent));

    /// <inheritdoc />
    protected override GameObject PrefabTemplate { get; }

    /// <inheritdoc />
    protected override int PoolIncrementSize { get; } = 2;


    /// <inheritdoc />
    public PickedFoodCanvasViewResolvers(PrefabCollection prefabs, IUnityInstantiator instantiator, IEntityCollectionManager collectionManager, IEventSystem eventSystem) : base(instantiator, collectionManager, eventSystem)
    {
      Debug.Log($"[PickedFoodCanvasViewResolvers ctor] prefabs is {(prefabs == null ? "null" : "not null")}; prefabs count is {prefabs?.Count}");
      //PrefabTemplate = prefabs[PrefabEnum.PickedFoodCanvas];
    }

    /// <inheritdoc />
    protected override void OnPoolStarting()
    {
      Debug.Log("[PickedFoodCanvasViewResolvers] OnPoolStarting");
    }

    /// <inheritdoc />
    protected override void OnViewAllocated(GameObject view, IEntity entity)
    {
      Debug.Log("OnViewAllocated");
    }

    /// <inheritdoc />
    protected override void OnViewRecycled(GameObject view, IEntity entity)
    {
      Debug.Log("OnViewRecycled");
    }
  }
}