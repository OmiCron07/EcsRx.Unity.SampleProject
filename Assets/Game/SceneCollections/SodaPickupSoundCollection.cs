using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

namespace Game.SceneCollections
{
  public class SodaPickupSoundCollection : Collection<AudioClip>, IAsyncCollection
  {
    /// <inheritdoc />
    public IAsyncOperation AsyncOperation { get; }


    public SodaPickupSoundCollection()
    {
      AsyncOperation = Addressables.LoadAssets<AudioClip>("SodaPickupSound", x => Add(x.Result));
    }
  }
}
