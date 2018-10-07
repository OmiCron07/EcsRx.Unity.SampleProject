using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

namespace Game.SceneCollections
{
  public class PlayerAttackSoundCollection : Collection<AudioClip>, IAsyncCollection
  {
    /// <inheritdoc />
    public IAsyncOperation AsyncOperation { get; }


    public PlayerAttackSoundCollection()
    {
      AsyncOperation = Addressables.LoadAssets<AudioClip>("PlayerAttackSound", x => Add(x.Result));
    }
  }
}
