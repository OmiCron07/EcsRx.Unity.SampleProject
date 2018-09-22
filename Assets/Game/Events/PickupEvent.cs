using EcsRx.Entities;

namespace Game.Events
{
  public class PickupEvent
  {
    public IEntity CollectorEntity { get; }

    public IEntity PickupableEntity { get; }


    public PickupEvent(IEntity collectorEntity, IEntity pickupableEntity)
    {
      CollectorEntity  = collectorEntity;
      PickupableEntity = pickupableEntity;
    }
  }
}