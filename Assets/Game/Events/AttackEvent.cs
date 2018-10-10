using EcsRx.Entities;

namespace Game.Events
{
  public class AttackEvent : UnityEngine.Object
  {
    public IEntity AttackingEntity { get; }

    public int Damage { get; }


    public AttackEvent(IEntity attackingEntity, int damage)
    {
      AttackingEntity = attackingEntity;
      Damage          = damage;
    }
  }
}