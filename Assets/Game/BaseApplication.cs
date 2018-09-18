﻿using EcsRx.Zenject;
using Game.Modules;

namespace Game
{
  public class BaseApplication : EcsRxApplicationBehaviour
  {
    /// <inheritdoc />
    protected override void RegisterModules()
    {
      base.RegisterModules();
      
      DependencyContainer.LoadModule<SceneProfileModule>();
    }

    /// <inheritdoc />
    protected override void ApplicationStarted()
    {
    }
  }
}
