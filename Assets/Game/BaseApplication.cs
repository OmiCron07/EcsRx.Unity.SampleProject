using EcsRx.Zenject;
using EcsRx.Zenject.Extensions;
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
    protected override void ApplicationStarting()
    {
      //this.BindAndRegisterSystem<SceneProfileSystem>();

      this.BindAllSystemsWithinApplicationScope();
      this.RegisterAllBoundSystems();
    }

    /// <inheritdoc />
    protected override void ApplicationStarted()
    {
    }
  }
}
