using EcsRx.Events;
using EcsRx.Systems.Custom;
using EcsRx.Unity.Extensions;
using Game.Events;
using Game.SceneCollections;
using Game.Scripts.MethodExtensions;
using UnityEngine;

namespace Game.Systems
{
  public class FootStepSoundSystem : EventReactionSystem<FootStepSoundEvent>
  {
    private readonly FootStepSoundCollection _footStepSounds;


    /// <inheritdoc />
    public FootStepSoundSystem(FootStepSoundCollection footStepSounds, IEventSystem eventSystem) : base(eventSystem)
    {
      _footStepSounds = footStepSounds;
    }

    /// <inheritdoc />
    public override void EventTriggered(FootStepSoundEvent eventData)
    {
      var audioSource = eventData.Entity.GetUnityComponent<AudioSource>();
      audioSource.PlayOneShot(_footStepSounds.TakeRandom());
    }
  }
}
