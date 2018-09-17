using System.Collections.ObjectModel;
using Game.Scripts.ScriptableObjects;
using UnityEngine.AddressableAssets;

namespace Game.SceneCollections
{
  public class SceneProfileCollection : Collection<SceneProfile>
  {
    public SceneProfileCollection()
    {
      Addressables.LoadAssets<SceneProfile>("SceneProfile", x => Add(x.Result));
    }
  }
}