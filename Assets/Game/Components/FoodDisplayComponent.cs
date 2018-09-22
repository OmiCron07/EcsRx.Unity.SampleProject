using EcsRx.Components;
using Game.Scripts.Enums;

namespace Game.Components
{
  public class FoodDisplayComponent : IComponent
  {
    public FoodDisplayTypeEnum DisplayType { get; set; }
  }
}
