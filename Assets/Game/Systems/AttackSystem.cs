using EcsRx.Events;
using EcsRx.Systems.Custom;
using EcsRx.Unity.Extensions;
using Game.Events;
using Game.Scripts.Constants;
using UnityEngine;

namespace Game.Systems
{
  public class AttackSystem : EventReactionSystem<AttackEvent>
  {
    /// <inheritdoc />
    public AttackSystem(IEventSystem eventSystem) : base(eventSystem)
    {
    }

    /// <inheritdoc />
    public override void EventTriggered(AttackEvent eventData)
    {
      var gameObject = eventData.AttackingEntity.GetGameObject();

      var spriteRenderer = gameObject.GetComponentInChildren<Animator>();
      spriteRenderer.SetTrigger(CharacterAnimationConstants.Attack);
    }
  }
}