using System;
using System.Collections.Generic;
using System.Linq;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.Systems;
using EcsRx.Unity.Extensions;
using Game.Components;
using UniRx;
using UnityEngine;

namespace Game.Systems
{
  public class PlayerSystem : IManualSystem
  {
    private readonly ICollection<IDisposable> _disposables = new List<IDisposable>();


    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(PlayerComponent));


    /// <inheritdoc />
    public void StartSystem(IObservableGroup observableGroup)
    {
      this.WaitForScene().Subscribe(_ =>
                                      {
                                        var entity = observableGroup.First();
                                        var inputComponent = entity.GetComponent<InputComponent>();
                                        var movableComponent = entity.GetComponent<MovableComponent>();

                                        inputComponent.Movement.Subscribe(x => movableComponent.Movement.Value = x).AddTo(_disposables);
                                      });
    }

    /// <inheritdoc />
    public void StopSystem(IObservableGroup observableGroup)
    {
      _disposables.DisposeAll();
    }
  }
}