using System;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;
using EcsRx.Unity.Extensions;
using Game.Components;
using Game.Scripts.Enums;
using UniRx;
using UnityEngine.UI;

namespace Game.Systems
{
  public class MainMenuUiSystem : ISetupSystem
  {
    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(UiComponent));


    /// <inheritdoc />
    public void Setup(IEntity entity)
    {
      var uiComponent = entity.GetComponent<UiComponent>();

      switch (uiComponent.Element)
      {
        case UiElementEnum.MainMenuTitle:
          var property = this.WaitForScene().Select(_ => "fsdjio").Delay(TimeSpan.FromSeconds(2)).Select(_ => "iiii").ToReadOnlyReactiveProperty();
          property.SubscribeToText(entity.GetUnityComponent<Text>());
          break;

        default:

          throw new ArgumentOutOfRangeException();
      }
    }
  }
}