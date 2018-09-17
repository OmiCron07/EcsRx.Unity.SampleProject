using EcsRx.Unity.MonoBehaviours;
using Game.Events;
using Game.Scripts.Enums;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Scripts
{
  public class LoadSceneProfileScript : InjectableMonoBehaviour
  {
    [SerializeField] private SceneProfileEnum _sceneProfile;


    public void LoadSceneProfile()
    {
      EventSystem.Publish(new LoadSceneProfileEvent(_sceneProfile));
    }

    /// <inheritdoc />
    public override void DependenciesResolved()
    {
      Assert.IsNotNull(EventSystem, "EventSystem != null");
    }

    private void OnEnable()
    {
      Assert.AreNotEqual(SceneProfileEnum.None, _sceneProfile, "_sceneProfile != SceneProfileEnum.None");
    }
  }
}