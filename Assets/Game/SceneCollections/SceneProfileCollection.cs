using System.Collections.ObjectModel;
using Game.Scripts.ScriptableObjects;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

namespace Game.SceneCollections
{
  public class SceneProfileCollection : Collection<SceneProfile>, IAsyncCollection
  {
    /// <inheritdoc />
    public IAsyncOperation AsyncOperation { get; }


    public SceneProfileCollection()
    {
      AsyncOperation = Addressables.LoadAssets<SceneProfile>("SceneProfile", x => Add(x.Result));
    }
  }
}