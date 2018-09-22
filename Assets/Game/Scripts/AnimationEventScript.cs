using EcsRx.Unity.MonoBehaviours;
using Game.Events;

namespace Game.Scripts
{
  public class AnimationEventScript : InjectableMonoBehaviour
  {
    public void FootStepSound()
    {
      EventSystem.Publish(new FootStepSoundEvent(GetComponent<EntityView>()?.Entity ?? GetComponentInParent<EntityView>().Entity));
    }

    /// <inheritdoc />
    public override void DependenciesResolved()
    {
    }
  }
}
