using EcsRx.Collections;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Systems.Custom;
using EcsRx.Unity.Extensions;
using Game.Components;
using Game.Events;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Systems
{
  public class PickupableSystem : EventReactionSystem<PickupEvent>
  {
    private readonly IEntityCollectionManager _entityCollectionManager;


    /// <inheritdoc />
    public PickupableSystem(IEntityCollectionManager entityCollectionManager, IEventSystem eventSystem) : base(eventSystem)
    {
      _entityCollectionManager = entityCollectionManager;
    }

    /// <inheritdoc />
    public override void EventTriggered(PickupEvent eventData)
    {
      if (eventData.PickupableEntity.HasComponent<FoodComponent>())
      {
        var foodComponent = eventData.PickupableEntity.GetComponent<FoodComponent>();
        eventData.CollectorEntity.GetComponent<HitPointComponent>().HitPoint.Value += foodComponent.Amount;

        //TODO: Pool
        this.AfterUpdateDo(x =>
                             {
                               GameObject gameObject = eventData.PickupableEntity.GetGameObject();
                               _entityCollectionManager.RemoveEntity(eventData.PickupableEntity);
                               Object.Destroy(gameObject);
                             });
      }
    }
  }
}