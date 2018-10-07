using System.Collections.Generic;
using System.Linq;
using EcsRx.Infrastructure.Extensions;
using EcsRx.Zenject;
using Game.Modules;
using Game.SceneCollections;
using UnityEngine;

namespace Game
{
  public class GameplayApplication : EcsRxApplicationBehaviour
  {
    private readonly List<IAsyncCollection> _collections = new List<IAsyncCollection>();
    private bool _started;

    
    /// <inheritdoc />
    protected override void LoadModules()
    {
      base.LoadModules();

      Container.LoadModule<CommonModule>();
      Container.LoadModule<CollectionModule>();
    }

    /// <inheritdoc />
    public override void StartApplication()
    {
      LoadModules();
      LoadPlugins();
      SetupPlugins();
      ResolveApplicationDependencies();
      BindSystems();
      StartPluginSystems();

      _collections.Add(Container.Resolve<ApplePickupSoundCollection>());
      _collections.Add(Container.Resolve<FootStepSoundCollection>());
      _collections.Add(Container.Resolve<PlayerAttackSoundCollection>());
      _collections.Add(Container.Resolve<PrefabCollection>());
      _collections.Add(Container.Resolve<SceneProfileCollection>());
      _collections.Add(Container.Resolve<SodaPickupSoundCollection>());
    }

    /// <inheritdoc />
    protected override void ApplicationStarted()
    {
    }

    private void LateUpdate()
    {
      if (!_started && _collections.All(x => x.AsyncOperation.IsDone))
      {
        _started = true;
        Debug.Log("All collection loaded");

        StartSystems();
        ApplicationStarted();
      }
    }
  }
}