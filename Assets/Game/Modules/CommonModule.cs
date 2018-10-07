using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;
using Game.SceneCollections;

namespace Game.Modules
{
  public class CommonModule : IDependencyModule
  {
    /// <inheritdoc />
    public void Setup(IDependencyContainer container)
    {
      container.Bind<SceneProfileCollection>();
    }
  }
}