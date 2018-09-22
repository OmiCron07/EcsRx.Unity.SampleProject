using EcsRx.Components;
using Game.Scripts.Enums;

namespace Game.Components
{
  public class FoodComponent : IComponent
  {
    public FoodTypeEnum Type { get; set; }

    public int Amount { get; set; }
  }
}
