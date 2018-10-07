using UnityEngine.ResourceManagement;

namespace Game.SceneCollections
{
  public interface IAsyncCollection
  {
    IAsyncOperation AsyncOperation { get; }
  }
}