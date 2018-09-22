using EcsRx.Infrastructure.Dependencies;
using Game.SceneCollections;

namespace Game.Modules
{
  public class SoundModule : IDependencyModule
  {
    /// <inheritdoc />
    public void Setup(IDependencyContainer container)
    {
      container.Bind<PlayerAttackSoundCollection>();
      container.Bind<FootStepSoundCollection>();
      container.Bind<ApplePickupSoundCollection>();
      container.Bind<SodaPickupSoundCollection>();
    }
  }
}
