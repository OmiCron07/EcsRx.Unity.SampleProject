using EcsRx.Components;

namespace Game.Components
{
  public class DamageComponent : IComponent
  {
    public int Damage { get; set; }

    public int Throttle { get; set; }
  }
}
