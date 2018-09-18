using EcsRx.Zenject.Extensions;
using Game.Modules;

namespace Game
{
  public class GameplayApplication : BaseApplication
  {
    /// <inheritdoc />
    protected override void RegisterModules()
    {
      base.RegisterModules();

      DependencyContainer.LoadModule<GameplayModule>();
      DependencyContainer.LoadModule<ComputedModule>();
    }

    /// <inheritdoc />
    protected override void ApplicationStarting()
    {
      base.ApplicationStarting();

      this.BindAllSystemsWithinApplicationScope();
      this.RegisterAllBoundSystems();
    }
  }
}