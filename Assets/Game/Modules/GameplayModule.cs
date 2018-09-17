using EcsRx.Infrastructure.Dependencies;
using Game.SceneCollections;

namespace Game.Modules
{
  public class GameplayModule : IDependencyModule
  {
    /// <inheritdoc />
    public void Setup(IDependencyContainer container)
    {
      container.Bind<PlayerAttackSoundCollection>();
      container.Bind<FootStepSoundCollection>();
    }
  }
}
