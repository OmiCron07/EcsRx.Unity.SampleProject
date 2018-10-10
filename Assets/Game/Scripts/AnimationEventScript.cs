using EcsRx.Collections;
using EcsRx.Unity.MonoBehaviours;
using Game.Events;
using Zenject;

namespace Game.Scripts
{
  public class AnimationEventScript : InjectableMonoBehaviour
  {
    [Inject] private IEntityCollectionManager _entityCollectionManager;


    public void FootStepSound()
    {
      EventSystem.Publish(new FootStepSoundEvent(GetComponent<EntityView>()?.Entity ?? GetComponentInParent<EntityView>().Entity));
    }

    public void AnimationEndedThenRemoveEntity()
    {
      _entityCollectionManager.GetCollection().RemoveEntity(GetComponent<EntityView>()?.Entity?.Id ?? GetComponentInParent<EntityView>().Entity.Id);
    }

    /// <inheritdoc />
    public override void DependenciesResolved()
    {
    }
  }
}
