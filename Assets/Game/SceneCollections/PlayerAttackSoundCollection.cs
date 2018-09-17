using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.SceneCollections
{
  public class PlayerAttackSoundCollection : Collection<AudioClip>
  {
    public PlayerAttackSoundCollection()
    {
      Addressables.LoadAssets<AudioClip>("PlayerAttackSound", x => Add(x.Result));
    }
  }
}
