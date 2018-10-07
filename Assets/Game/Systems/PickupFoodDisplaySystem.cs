using EcsRx.Collections;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Systems.Custom;
using EcsRx.Unity.Extensions;
using Game.Blueprints;
using Game.Components;
using Game.Events;
using TMPro;
using UnityEngine;

namespace Game.Systems
{
  public class PickupFoodDisplaySystem : EventReactionSystem<PickupEvent>
  {
    private readonly IEntityCollectionManager _entityCollectionManager;


    /// <inheritdoc />
    public PickupFoodDisplaySystem(IEventSystem eventSystem, IEntityCollectionManager entityCollectionManager) : base(eventSystem)
    {
      _entityCollectionManager = entityCollectionManager;
    }

    /// <inheritdoc />
    public override void EventTriggered(PickupEvent eventData)
    {
      if (eventData.PickupableEntity.HasComponent<FoodComponent>())
      {
        Debug.Log("[PickupFoodDisplaySystem] EventTriggered");

        var foodDisplayEntity = _entityCollectionManager.GetCollection().CreateEntity(new PickupFoodDisplayBlueprint());
        var textComponent = foodDisplayEntity.GetGameObject().GetComponentInChildren<TextMeshProUGUI>();

        textComponent.SetText($"+{eventData.PickupableEntity.GetComponent<FoodComponent>().Amount}");
        textComponent.transform.parent.position = eventData.PickupableEntity.GetGameObject().transform.position;
        textComponent.GetComponent<Animator>().SetTrigger("PickedFood");
      }
    }
  }
}