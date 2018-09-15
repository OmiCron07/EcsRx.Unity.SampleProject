using System.Collections.Generic;
using System.Linq;
using EcsRx.Zenject;
using EcsRx.Zenject.Extensions;
using Game.Blueprints;
using Game.Blueprints.SceneProfiles;
using UnityEngine;

namespace Game
{
  public class BaseApplication : EcsRxApplicationBehaviour
  {
    [SerializeField] private List<SceneProfileBlueprint> _sceneProfileBlueprints;


    /// <inheritdoc />
    protected override void ApplicationStarted()
    {
      var defaultCollection = CollectionManager.GetCollection();

      defaultCollection.CreateEntity(new InputBlueprint());

      if (_sceneProfileBlueprints?.Any() == true)
      {
        Debug.Log($"There is {_sceneProfileBlueprints.Count} scene profile blueprints loaded and created entity.");

        foreach (var sceneProfileBlueprint in _sceneProfileBlueprints)
        {
          defaultCollection.CreateEntity(sceneProfileBlueprint);
        }
      }

      this.BindAllSystemsWithinApplicationScope();
      this.RegisterAllBoundSystems();
    }
  }
}
