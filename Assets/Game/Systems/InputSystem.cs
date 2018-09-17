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

      inputComponent.Movement = Observable.EveryUpdate().Select(_ => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized);//.Merge(Observable.EveryFixedUpdate().Select(_ => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized));
      inputComponent.Attack   = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Space)).Select(_ => Unit.Default);

      inputComponent.MenuUp     = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.W)).Select(_ => Unit.Default);
      inputComponent.MenuDown   = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.S)).Select(_ => Unit.Default);
      inputComponent.MenuLeft   = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.A)).Select(_ => Unit.Default);
      inputComponent.MenuRight  = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.D)).Select(_ => Unit.Default);
      inputComponent.MenuAccept = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.F)).Select(_ => Unit.Default);
      inputComponent.MenuBack   = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.R)).Select(_ => Unit.Default);
    }
  }
}