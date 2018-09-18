using EcsRx.Zenject.Extensions;
using Game.Systems;

namespace Game
{
  public class MainMenuApplication : BaseApplication
  {
    /// <inheritdoc />
    protected override void ApplicationStarting()
    {
      base.ApplicationStarting();

      this.BindAndRegisterSystem<SceneProfileSystem>();
    }
  }
}