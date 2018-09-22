using System;
using EcsRx.Collections;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Systems.Custom;
using EcsRx.Unity.Extensions;
using Game.Components;
using Game.Events;
using Game.SceneCollections;
using Game.Scripts.Enums;
using Game.Scripts.MethodExtensions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Systems
{
  public class PickupableSystem : EventReactionSystem<PickupEvent>
  {
    private readonly ApplePickupSoundCollection _applePickupSounds;
    private readonly SodaPickupSoundCollection _sodaPickupSounds;
    private readonly IEntityCollectionManager _entityCollectionManager;


    /// <inheritdoc />
    public PickupableSystem(ApplePickupSoundCollection applePickupSounds, SodaPickupSoundCollection sodaPickupSounds, IEntityCollectionManager entityCollectionManager, IEventSystem eventSystem) : base(eventSystem)
    {
      _applePickupSounds       = applePickupSounds;
      _sodaPickupSounds        = sodaPickupSounds;
      _entityCollectionManager = entityCollectionManager;
    }

    /// <inheritdoc />
    public override void EventTriggered(PickupEvent eventData)
    {
      if (eventData.PickupableEntity.HasComponent<FoodComponent>())
      {
        var foodComponent = eventData.PickupableEntity.GetComponent<FoodComponent>();
        eventData.CollectorEntity.GetComponent<HitPointComponent>().HitPoint.Value += foodComponent.Amount;

        AudioClip pickupSound;

        switch (foodComponent.Type)
        {
          case FoodTypeEnum.Apple:
            pickupSound = _applePickupSounds.TakeRandom();
            break;

          case FoodTypeEnum.Soda:
            pickupSound = _sodaPickupSounds.TakeRandom();
            break;

          case FoodTypeEnum.Unknown:
          default:

            throw new ArgumentOutOfRangeException();
        }

        eventData.CollectorEntity.GetUnityComponent<AudioSource>().PlayOneShot(pickupSound);

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