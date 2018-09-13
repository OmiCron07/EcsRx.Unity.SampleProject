using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
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
  public class MainMenuUiSystem : IManualSystem, ISetupSystem
  {
    private readonly Dictionary<UiElementEnum, IEntity> _entities = new Dictionary<UiElementEnum, IEntity>();
    private readonly ICollection<IDisposable> _disposables = new List<IDisposable>();
    private readonly IReactiveProperty<MainMenuStepEnum> _currentStep = new ReactiveProperty<MainMenuStepEnum>(MainMenuStepEnum.Title);


    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(UiComponent));


    /// <inheritdoc />
    public void Setup(IEntity entity)
    {Debug.Log($"setup {entity.GetGameObject().name}");
      var uiComponent = entity.GetComponent<UiComponent>();
      _entities.Add(uiComponent.Element, entity);
    }

    /// <inheritdoc />
    public void StartSystem(IObservableGroup observableGroup)
    {
      //foreach (IEntity entity in observableGroup)
      //{
      //  var uiComponent = entity.GetComponent<UiComponent>();
      //  _entities.Add(uiComponent.Element, entity);
      //}
      Debug.Log($"StartSystem {_entities.Count}");
      foreach (var entity in _entities)
      {
        switch (entity.Key)
        {
          case UiElementEnum.MainMenu_Title:
            _currentStep.Subscribe(step => entity.Value.GetGameObject().SetActive(step == MainMenuStepEnum.Title)).AddTo(_disposables);
            var element = entity.Value.GetUnityComponent<TextMeshProUGUI>();
            this.WaitForScene().Subscribe(_ => element.StartCoroutine(TitleCoroutine(element))).AddTo(_disposables);

            break;

          case UiElementEnum.MainMenu_PrimaryMenu:

            _currentStep.Subscribe(step =>
                                     {
                                       entity.Value.GetGameObject().SetActive(step == MainMenuStepEnum.PrimaryMenu);
                                       _entities[UiElementEnum.MainMenu_PrimaryMenu_PlayButton].GetUnityComponent<Button>().Select();
                                     }).AddTo(_disposables);

            break;

          case UiElementEnum.MainMenu_PrimaryMenu_PlayButton:

            break;

          case UiElementEnum.MainMenu_PrimaryMenu_AboutButton:
            entity.Value.GetUnityComponent<Button>().OnClickAsObservable().Subscribe(_ => _currentStep.Value = MainMenuStepEnum.AboutMenu).AddTo(_disposables);

            break;

          case UiElementEnum.MainMenu_AboutMenu:
            _currentStep.Subscribe(step => entity.Value.GetGameObject().SetActive(step == MainMenuStepEnum.AboutMenu)).AddTo(_disposables);

            break;

          case UiElementEnum.MainMenu_AboutMenu_BackButton:
            entity.Value.GetUnityComponent<Button>().OnClickAsObservable().Subscribe(_ => _currentStep.Value = MainMenuStepEnum.PrimaryMenu).AddTo(_disposables);

            break;

          case UiElementEnum.Unknown:
          default:

            throw new ArgumentOutOfRangeException();
        }
      }
    }

    /// <inheritdoc />
    public void StopSystem(IObservableGroup observableGroup)
    {
      _disposables.DisposeAll();
    }

    private IEnumerator TitleCoroutine(TextMeshProUGUI element)
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