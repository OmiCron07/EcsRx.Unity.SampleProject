using EcsRx.Entities;

namespace Game.Events
{
  public class FootStepSoundEvent
  {
    public IEntity Entity { get; }


    public FootStepSoundEvent(IEntity entity)
    {
      Entity = entity;
    }
  }
}
