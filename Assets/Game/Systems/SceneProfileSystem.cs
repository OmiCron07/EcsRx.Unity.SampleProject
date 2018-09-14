using System.Collections.Generic;
using System.Linq;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.Systems.Custom;
using Game.Components;
using Game.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Systems
{
  public class SceneProfileSystem : EventReactionSystem<LoadSceneProfileEvent>
  {
    private readonly List<SceneProfileComponent> _loadedSceneProfileComponents = new List<SceneProfileComponent>();
    private List<SceneProfileComponent> _sceneProfileComponents;


    /// <inheritdoc />
    public override IGroup Group { get; } = new Group(typeof(SceneProfileComponent));


    /// <inheritdoc />
    public SceneProfileSystem(IEventSystem eventSystem) : base(eventSystem)
    {
    }

    /// <inheritdoc />
    public override void StartSystem(IObservableGroup observableGroup)
    {
      base.StartSystem(observableGroup);

      _sceneProfileComponents = observableGroup.Select(x => x.GetComponent<SceneProfileComponent>()).ToList();
      Debug.Log($"There is {_sceneProfileComponents.Count} scene profiles loaded.");
    }

    /// <inheritdoc />
    public override void EventTriggered(LoadSceneProfileEvent eventData)
    {
      Debug.Log($"Loading {eventData.SceneProfile} scene profile.");
      var sceneProfileToLoad = _sceneProfileComponents.Single(x => x.Profile == eventData.SceneProfile);

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
    }
  }
}