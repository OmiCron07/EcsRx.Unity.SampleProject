using EcsRx.Zenject.Extensions;
using Game.Modules;
using Game.Systems;

namespace Game
{
  public class GameplayApplication : BaseApplication
  {
    /// <inheritdoc />
    protected override void RegisterModules()
    {
      base.RegisterModules();

      DependencyContainer.LoadModule<GameplayModule>();
    }

    /// <inheritdoc />
    protected override void ApplicationStarting()
    {
      //this.BindAndRegisterSystem<AttackSystem>();
      //this.BindAndRegisterSystem<DamageableSystem>();
      //this.BindAndRegisterSystem<InputSystem>();
      //this.BindAndRegisterSystem<MovableSystem>();
      //this.BindAndRegisterSystem<PlayerSystem>();

      base.ApplicationStarting();
    }
  }
}