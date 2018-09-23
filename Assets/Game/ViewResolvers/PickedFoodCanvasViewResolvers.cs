using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Events;
using EcsRx.Groups;
using EcsRx.Unity.Dependencies;
using EcsRx.Unity.Systems;
using Game.Components;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.ViewResolvers
{
  public class PickedFoodCanvasViewResolvers : PrefabViewResolverSystem
  {
    /// <inheritdoc />
    public override IGroup Group { get; } = new Group(typeof(FoodDisplayComponent));

    /// <inheritdoc />
    protected override GameObject PrefabTemplate { get; }


    /// <inheritdoc />
    public PickedFoodCanvasViewResolvers(IEntityCollectionManager collectionManager, IEventSystem eventSystem, IUnityInstantiator instantiator) : base(collectionManager, eventSystem, instantiator)
    {
      Addressables.LoadAsset<GameObject>("PickedFoodCanvas").Completed += x =>
                                                                            {
                                                                              //PrefabTemplate = x.Result;
                                                                              Debug.Log("Async completed");
                                                                            };
    }

    /// <inheritdoc />
    protected override void OnViewCreated(IEntity entity, GameObject view)
    {
      Debug.Log($"OnViewCreated: {entity.Id}; {view.name}");
    }
  }
}