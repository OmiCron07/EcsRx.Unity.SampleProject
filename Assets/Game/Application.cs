using System.Collections.Generic;
using System.Linq;
using EcsRx.Zenject;
using EcsRx.Zenject.Extensions;
using Game.Blueprints;
using Game.Blueprints.SceneProfiles;
using Game.Events;
using Game.Scripts.Enums;
using Game.Scripts.MethodExtensions;
using UniRx;
using UnityEngine;

namespace Game
{
  public class Application : EcsRxApplicationBehaviour
  {
    [SerializeField] private List<SceneProfileBlueprint> _sceneProfileBlueprints;
    [SerializeField] private SceneProfileEnum _sceneProfileToStart;

    //[Inject] private GameConfiguration _gameConfiguration; //TODO


    protected override void RegisterModules()
    {
      Debug.Log("RegisterModules.");

      base.RegisterModules();

      //TODO
      //DependencyContainer.LoadModule<GameModule>();
      //DependencyContainer.LoadModule<SceneCollectionsModule>();
      //DependencyContainer.LoadModule<ComputedModule>();
    }

    protected override void ApplicationStarting()
    {
      Debug.Log("ApplicationStarting.");
    }

    /// <inheritdoc />
    protected override void ApplicationStarted()
    {
      Debug.Log("ApplicationStarted.");

      var defaultCollection = CollectionManager.GetCollection();

      defaultCollection.CreateEntity(new InputBlueprint());

      if (_sceneProfileBlueprints?.Any() == true)
      {
        foreach (var sceneProfileBlueprint in _sceneProfileBlueprints)
        {
          defaultCollection.CreateEntity(sceneProfileBlueprint);
        }
      }

      Debug.Log($"There is {_sceneProfileBlueprints.Count} scene profile blueprints loaded and created entity.");

      if (_sceneProfileToStart != SceneProfileEnum.None)
      {
        this.WaitForScene().Subscribe(_ => EventSystem.Publish(new LoadSceneProfileEvent(_sceneProfileToStart))).AddTo(this);
      }

      this.BindAllSystemsWithinApplicationScope();
      this.RegisterAllBoundSystems();
    }
  }
}