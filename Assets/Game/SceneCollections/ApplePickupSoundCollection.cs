using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.SceneCollections
{
  public class ApplePickupSoundCollection : Collection<AudioClip>
  {
    public ApplePickupSoundCollection()
    {
      Addressables.LoadAssets<AudioClip>("ApplePickupSound", x => Add(x.Result));
    }
  }
}
