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

      for (int i = 0; i < sceneProfileToLoad.Scenes.Count; i++)
      {
        SceneManager.LoadSceneAsync(sceneProfileToLoad.Scenes[i].name, i != 0 || sceneProfileToLoad.IsAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single);
      }
    }
  }
}