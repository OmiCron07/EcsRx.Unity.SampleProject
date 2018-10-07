using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

namespace Game.SceneCollections
{
  public class ApplePickupSoundCollection : Collection<AudioClip>, IAsyncCollection
  {
    /// <inheritdoc />
    public IAsyncOperation AsyncOperation { get; }


    public ApplePickupSoundCollection()
    {
      AsyncOperation = Addressables.LoadAssets<AudioClip>("ApplePickupSound", x => Add(x.Result));
    }
  }
}
