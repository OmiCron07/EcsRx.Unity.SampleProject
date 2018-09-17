using System;
using System.Collections.Generic;
using EcsRx.Entities;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;
using Game.Components;
using Game.Events;
using UniRx;

namespace Game.Systems
{
  public class PlayerSystem : ISetupSystem, ITeardownSystem
  {
    private readonly IEventSystem _eventSystem;
    private readonly ICollection<IDisposable> _disposables = new List<IDisposable>();


    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(PlayerComponent));


    public PlayerSystem(IEventSystem eventSystem)
    {
      _eventSystem = eventSystem;
    }

    /// <inheritdoc />
    public void Setup(IEntity entity)
    {
      var inputComponent = entity.GetComponent<InputComponent>();
      var movableComponent = entity.GetComponent<MovableComponent>();
      var damageComponent = entity.GetComponent<DamageComponent>();

      inputComponent.Movement.Subscribe(x => movableComponent.Movement.Value = x).AddTo(_disposables);
      inputComponent.Attack.ThrottleFirst(TimeSpan.FromMilliseconds(damageComponent.Throttle)).Subscribe(__ => _eventSystem.Publish(new AttackEvent(entity))).AddTo(_disposables);
    }

    /// <inheritdoc />
    public void Teardown(IEntity entity)
    {
      _disposables.DisposeAll();
      entity.Dispose();
    }
  }
}