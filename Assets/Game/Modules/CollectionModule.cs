using EcsRx.Infrastructure.Dependencies;
using Game.SceneCollections;

namespace Game.Modules
{
  public class CollectionModule : IDependencyModule
  {
    /// <inheritdoc />
    public void Setup(IDependencyContainer container)
    {
      container.Bind<SceneProfileCollection>();
      container.Bind<PrefabCollection>();
    }
  }
}