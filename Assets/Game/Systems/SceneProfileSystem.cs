using System;
using System.Collections.Generic;
using System.Linq;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.MicroRx.Extensions;
using EcsRx.Systems;
using EcsRx.Unity.Extensions;
using Game.Components;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Game.Systems
{
  public class SceneProfileSystem : IManualSystem
  {
    private readonly ICollection<IDisposable> _disposables = new List<IDisposable>();
    private readonly List<SceneProfileComponent> _loadedSceneProfileComponents = new List<SceneProfileComponent>();
    private readonly IEventSystem _eventSystem;


    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(SceneProfileComponent));


    public SceneProfileSystem(IEventSystem eventSystem)
    {
      _eventSystem = eventSystem;
    }

    /// <inheritdoc />
    public void StartSystem(IObservableGroup observableGroup)
    {
      this.WaitForScene()
          .Subscribe(_ =>
                       {
                         var sceneProfileComponents = observableGroup.Select(x => x.GetComponent<SceneProfileComponent>()).ToList();

                         //_loadedSceneComponents.Add(sceneProfileComponents.Single(x => x.IsMaster));

                         _eventSystem.Receive<LoadSceneProfileEvent>()
                                     .Subscribe(x =>
                                                  {
                                                    var sceneProfileToLoad = sceneProfileComponents.Single(xx => xx.Profile == x.SceneProfile);

                                                    if (!sceneProfileToLoad.IsAdditive)
                                                    {
                                                      foreach (var loadedSceneProfileComponent in _loadedSceneProfileComponents)
                                                      {
                                                        foreach (var sceneAssetToUnload in loadedSceneProfileComponent.Scenes)
                                                        {
                                                          SceneManager.UnloadSceneAsync(sceneAssetToUnload.name);
                                                        }
                                                      }
                                                    }

                                                    foreach (var sceneAsset in sceneProfileToLoad.Scenes)
                                                    {
                                                      SceneManager.LoadScene(sceneAsset.name, LoadSceneMode.Additive);
                                                    }

                                                    _loadedSceneProfileComponents.Add(sceneProfileToLoad);
                                                  })
                                     .AddTo(_disposables);
                       })
          .AddTo(_disposables);
    }

    /// <inheritdoc />
    public void StopSystem(IObservableGroup observableGroup)
    {
      _disposables.DisposeAll();
    }
  }
}