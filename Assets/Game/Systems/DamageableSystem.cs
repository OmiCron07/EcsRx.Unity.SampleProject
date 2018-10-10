using System;
using System.Collections.Generic;
using EcsRx.Entities;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;
using EcsRx.Unity.Extensions;
using EcsRx.Unity.MonoBehaviours;
using Game.Components;
using Game.Events;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Systems
{
  public class DamageableSystem : ISetupSystem, ITeardownSystem
  {
    private readonly IEventSystem _eventSystem;
    private readonly ICollection<IDisposable> _disposables = new List<IDisposable>();


    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(HitPointComponent));


    public DamageableSystem(IEventSystem eventSystem)
    {
      _eventSystem = eventSystem;
    }

    /// <inheritdoc />
    public void Setup(IEntity entity)
    {
      var hitPointComponent = entity.GetComponent<HitPointComponent>();

      var onCollisionStream = entity.GetGameObject().OnCollisionStay2DAsObservable();
      var onAttackStream = _eventSystem.Receive<AttackEvent>();

      onCollisionStream.Zip(onAttackStream,
                            (onCollision, attackEvent) => new
                                                            {
                                                              attackEvent,
                                                              onCollision
                                                            })
                       .Where(x => x.attackEvent.AttackingEntity == x.onCollision.otherCollider.gameObject.GetComponent<EntityView>().Entity)
                       .Subscribe(x =>
                                    {
                                      hitPointComponent.HitPoint.Value -= x.attackEvent.Damage;

                                      Debug.Log("Flash!!");
                                    }).AddTo(_disposables);
    }

    /// <inheritdoc />
    public void Teardown(IEntity entity)
    {
      _disposables.DisposeAll();
    }
  }
}