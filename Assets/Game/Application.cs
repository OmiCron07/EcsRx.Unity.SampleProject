using System.Collections.Generic;
using EcsRx.Zenject;
using EcsRx.Zenject.Extensions;
using Game.Blueprints;
using Game.Blueprints.SceneProfiles;
using Game.Events;
using Game.Scripts.Enums;
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
      base.RegisterModules();

      //TODO
      //DependencyContainer.LoadModule<GameModule>();
      //DependencyContainer.LoadModule<SceneCollectionsModule>();
      //DependencyContainer.LoadModule<ComputedModule>();
    }

    protected override void ApplicationStarting()
    {
      this.BindAllSystemsWithinApplicationScope();
      this.RegisterAllBoundSystems();
    }

    /// <inheritdoc />
    protected override void ApplicationStarted()
    {
      var defaultCollection = CollectionManager.GetCollection();

      defaultCollection.CreateEntity(new InputBlueprint());
      Debug.Log("Entity created");

      foreach (var sceneProfileBlueprint in _sceneProfileBlueprints)
      {
        defaultCollection.CreateEntity(sceneProfileBlueprint);
      }

      Observable.EveryUpdate().First().Subscribe(_ => EventSystem.Publish(new LoadSceneProfileEvent(_sceneProfileToStart)));
    }
  }
}