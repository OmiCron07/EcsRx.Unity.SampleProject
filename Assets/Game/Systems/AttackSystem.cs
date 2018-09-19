using EcsRx.Events;
using EcsRx.Systems.Custom;
using EcsRx.Unity.Extensions;
using Game.Events;
using Game.SceneCollections;
using Game.Scripts.Constants;
using Game.Scripts.MethodExtensions;
using UnityEngine;

namespace Game.Systems
{
  public class AttackSystem : EventReactionSystem<AttackEvent>
  {
    private readonly PlayerAttackSoundCollection _playerAttackSounds;


    /// <inheritdoc />
    public AttackSystem(PlayerAttackSoundCollection playerAttackSounds, IEventSystem eventSystem) : base(eventSystem)
    {
      _playerAttackSounds = playerAttackSounds;
    }

    /// <inheritdoc />
    public override void EventTriggered(AttackEvent eventData)
    {
      var spriteRenderer = eventData.Entity.GetGameObject().GetComponentInChildren<Animator>();
      spriteRenderer.SetTrigger(CharacterAnimationConstants.Attack);

      var audioSource = eventData.Entity.GetUnityComponent<AudioSource>();
      audioSource.PlayOneShot(_playerAttackSounds.TakeRandom());
    }
  }
}