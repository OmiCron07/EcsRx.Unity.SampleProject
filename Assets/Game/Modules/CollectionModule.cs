using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;
using Game.SceneCollections;

namespace Game.Modules
{
  public class CollectionModule : IDependencyModule
  {
    /// <inheritdoc />
    public void Setup(IDependencyContainer container)
    {
      container.Bind<ApplePickupSoundCollection>();
      container.Bind<FootStepSoundCollection>();
      container.Bind<PlayerAttackSoundCollection>();
      container.Bind<PrefabCollection>();
      container.Bind<SodaPickupSoundCollection>();
    }
  }
}