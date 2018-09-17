using System.Linq;
using EcsRx.Events;
using EcsRx.Systems.Custom;
using Game.Events;
using Game.SceneCollections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Systems
{
  public class SceneProfileSystem : EventReactionSystem<LoadSceneProfileEvent>
  {
    private readonly SceneProfileCollection _sceneProfiles;

    
    /// <inheritdoc />
    public SceneProfileSystem(SceneProfileCollection sceneProfiles, IEventSystem eventSystem) : base(eventSystem)
    {
      _sceneProfiles = sceneProfiles;
    }
    
    /// <inheritdoc />
    public override void EventTriggered(LoadSceneProfileEvent eventData)
    {
      Debug.Log($"Loading {eventData.SceneProfile} scene profile.");

      var sceneProfileToLoad = _sceneProfiles.Single(x => x.Profile == eventData.SceneProfile);

      for (int i = 0; i < sceneProfileToLoad.Scenes.Count; i++)
      {
        SceneManager.LoadSceneAsync(sceneProfileToLoad.Scenes[i].name, i != 0 || sceneProfileToLoad.IsAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single);
      }
    }
  }
}