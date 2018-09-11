using System;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;
using Game.Components;
using UniRx;
using UnityEngine;

namespace Game.Systems
{
  public class InputSystem : ISetupSystem
  {
    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(InputComponent));

    /// <inheritdoc />
    public void Setup(IEntity entity)
    {
      var inputComponent = entity.GetComponent<InputComponent>();

      inputComponent.Movement.Value = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
      inputComponent.Fire = CreateKeyDownAndHoldStream(KeyCode.Space);

      inputComponent.Fire.Subscribe(_ => Debug.Log("Fire!!!!"));
    }

    private IObservable<Unit> CreateKeyDownAndHoldStream(KeyCode key)
    {
      var keyDown = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(key));
      var keyUp = Observable.EveryUpdate().Where(_ => Input.GetKeyUp(key));
      var keyPress = keyDown.TakeUntil(keyUp).Select(_ => Unit.Default);

      return keyPress;
    }
  }
}