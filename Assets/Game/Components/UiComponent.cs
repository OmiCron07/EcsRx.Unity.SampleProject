using EcsRx.Components;
using Game.Scripts.Enums;

namespace Game.Components
{
  public class UiComponent : IComponent
  {
    public UiElementEnum Element { get; set; }
  }
}
