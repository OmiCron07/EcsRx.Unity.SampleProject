using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.SceneCollections
{
  public class SodaPickupSoundCollection : Collection<AudioClip>
  {
    public SodaPickupSoundCollection()
    {
      Addressables.LoadAssets<AudioClip>("SodaPickupSound", x => Add(x.Result));
    }
  }
}
