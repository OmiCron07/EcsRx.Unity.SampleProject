using EcsRx.Infrastructure.Extensions;
using EcsRx.Systems;
using EcsRx.Zenject;
using Game.Modules;
using Game.Systems;

namespace Game
{
  public class MainMenuApplication : EcsRxApplicationBehaviour
  {
    /// <inheritdoc />
    protected override void LoadModules()
    {
      base.LoadModules();

      Container.LoadModule<CommonModule>();
    }

    /// <inheritdoc />
    protected override void BindSystems()
    {
      Container.Bind(typeof(ISystem), typeof(SceneProfileSystem));
    }

    /// <inheritdoc />
    protected override void ApplicationStarted()
    {
    }
  }
}