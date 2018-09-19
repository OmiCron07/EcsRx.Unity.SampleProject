using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.SceneCollections
{
  public class FootStepSoundCollection : Collection<AudioClip>
  {
    public FootStepSoundCollection()
    {
      Addressables.LoadAssets<AudioClip>("FootStepSound", x => Add(x.Result));
    }
  }
}
