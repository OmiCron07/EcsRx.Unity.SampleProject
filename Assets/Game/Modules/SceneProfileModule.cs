using EcsRx.Infrastructure.Dependencies;
using Game.SceneCollections;
using UnityEngine;

namespace Game.Modules
{
  public class SceneProfileModule : IDependencyModule
  {
    /// <inheritdoc />
    public void Setup(IDependencyContainer container)
    {
      container.Bind<SceneProfileCollection>();
    }
  }
}