using System;
using System.Collections.Generic;
using System.Linq;
using BindingsRx.Bindings;
using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;
using EcsRx.Unity.Extensions;
using Game.Blueprints;
using Game.Components;
using Game.Events;
using Game.Scripts.Enums;
using TMPro;
using UniRx;
using UnityEngine;

namespace Game.Systems
{
  public class FoodDisplaySystem : ISetupSystem, ITeardownSystem
  {
    private readonly IEntityCollectionManager _entityCollectionManager;
    private readonly IEventSystem _eventSystem;
    private readonly ICollection<IDisposable> _disposables = new List<IDisposable>();


    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(FoodDisplayComponent));


    public FoodDisplaySystem(IEntityCollectionManager entityCollectionManager, IEventSystem eventSystem)
    {
      _entityCollectionManager = entityCollectionManager;
      _eventSystem             = eventSystem;
    }

    /// <inheritdoc />
    public void Setup(IEntity entity)
    {
      this.WaitForScene().Subscribe(_ =>
                                      {
                                        var foodDisplayComponent = entity.GetComponent<FoodDisplayComponent>();
                                        var textComponent = entity.GetUnityComponent<TextMeshProUGUI>();

                                        switch (foodDisplayComponent.DisplayType)
                                        {
                                          case FoodDisplayTypeEnum.CurrentPlayerFood:
                                            var playerEntity = _entityCollectionManager.GetEntitiesFor(new Group(typeof(PlayerComponent))).First();
                                            var hitPointComponent = playerEntity.GetComponent<HitPointComponent>();
                                            textComponent.BindTextTo(hitPointComponent.HitPoint);

                                            break;

                                          //case FoodDisplayTypeEnum.PickupFoodAmount:
                                          //  _eventSystem.Receive<PickupEvent>()
                                          //              .Where(x => x.PickupableEntity.HasComponent<FoodComponent>())
                                          //              .Subscribe(x =>
                                          //                           {
                                          //                             textComponent.SetText($"+{x.PickupableEntity.GetComponent<FoodComponent>().Amount}");
                                          //                             textComponent.transform.parent.position = x.PickupableEntity.GetGameObject().transform.position;
                                          //                             entity.GetUnityComponent<Animator>().SetTrigger("PickedFood");
                                          //                           })
                                          //              .AddTo(_disposables);

                                          //  break;

                                          case FoodDisplayTypeEnum.Unknown:
                                          default:

                                            throw new ArgumentOutOfRangeException();
                                        }

                                        _eventSystem.Receive<PickupEvent>()
                                                    .Where(x => x.PickupableEntity.HasComponent<FoodComponent>())
                                                    .Subscribe(x =>
                                                                 {
                                                                   var foodDisplayEntity = _entityCollectionManager.GetCollection().CreateEntity(new FoodDisplayBlueprint());
                                                                   var textComponent2 = foodDisplayEntity.GetGameObject().GetComponentInChildren<TextMeshProUGUI>();
                                                                   textComponent2.SetText($"+{x.PickupableEntity.GetComponent<FoodComponent>().Amount}");
                                                                   textComponent2.transform.parent.position = x.PickupableEntity.GetGameObject().transform.position;
                                                                   textComponent2.GetComponent<Animator>().SetTrigger("PickedFood");
                                                                 })
                                                    .AddTo(_disposables);
                                      });
    }

    /// <inheritdoc />
    public void Teardown(IEntity entity)
    {
      _disposables.DisposeAll();
    }
  }
}