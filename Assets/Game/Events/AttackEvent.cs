using EcsRx.Entities;

namespace Game.Events
{
  public class AttackEvent : UnityEngine.Object
  {
    public IEntity Entity { get; }


    public AttackEvent(IEntity entity)
    {
      Entity = entity;
    }
  }
}
