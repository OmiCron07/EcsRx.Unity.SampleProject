using System;
using System.Collections;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;
using EcsRx.Unity.Extensions;
using Game.Components;
using Game.Scripts.Enums;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Systems
{
  public class MainMenuUiSystem : ISetupSystem
  {
    private readonly IReactiveProperty<MainMenuStepEnum> _currentStep = new ReactiveProperty<MainMenuStepEnum>(MainMenuStepEnum.Title);


    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(UiComponent));


    /// <inheritdoc />
    public void Setup(IEntity entity)
    {
      var uiComponent = entity.GetComponent<UiComponent>();

      switch (uiComponent.Element)
      {
        case UiElementEnum.MainMenu_Title:

          _currentStep.Subscribe(step => entity.GetGameObject().SetActive(step == MainMenuStepEnum.Title)).AddTo(entity.GetGameObject());
          var element = entity.GetUnityComponent<TextMeshProUGUI>();
          element.StartCoroutine(Title(element));

          break;

        case UiElementEnum.MainMenu_PrimaryMenu:
          _currentStep.Subscribe(step => entity.GetGameObject().SetActive(step == MainMenuStepEnum.PrimaryMenu)).AddTo(entity.GetGameObject());

          break;

        case UiElementEnum.MainMenu_PrimaryMenu_AboutButton:
          entity.GetUnityComponent<Button>().OnClickAsObservable().Subscribe(_ => _currentStep.Value = MainMenuStepEnum.AboutMenu).AddTo(entity.GetGameObject());
          break;

        case UiElementEnum.MainMenu_AboutMenu:
          _currentStep.Subscribe(step => entity.GetGameObject().SetActive(step == MainMenuStepEnum.AboutMenu)).AddTo(entity.GetGameObject());

          break;

        case UiElementEnum.MainMenu_AboutMenu_BackButton:
          entity.GetUnityComponent<Button>().OnClickAsObservable().Subscribe(_ => _currentStep.Value = MainMenuStepEnum.PrimaryMenu).AddTo(entity.GetGameObject());

          break;

        case UiElementEnum.Unknown:
        default:

          throw new ArgumentOutOfRangeException();
      }
    }

    private IEnumerator Title(TextMeshProUGUI element)
    {
      _currentStep.Value = MainMenuStepEnum.Title;

      element.text = "Game Maker Company";

      yield return new WaitForSeconds(2);

      element.text = "Presents";

      yield return new WaitForSeconds(1.25f);

      element.text = "Killer Title";

      yield return new WaitForSeconds(2.25f);

      _currentStep.Value = MainMenuStepEnum.PrimaryMenu;
    }
  }
}