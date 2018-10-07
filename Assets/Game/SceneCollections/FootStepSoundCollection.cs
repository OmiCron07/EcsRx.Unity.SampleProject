using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

namespace Game.SceneCollections
{
  public class FootStepSoundCollection : Collection<AudioClip>, IAsyncCollection
  {
    /// <inheritdoc />
    public IAsyncOperation AsyncOperation { get; }


    public FootStepSoundCollection()
    {
      AsyncOperation = Addressables.LoadAssets<AudioClip>("FootStepSound", x => Add(x.Result));
    }
  }
}
