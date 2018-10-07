using EcsRx.Blueprints;
using EcsRx.Entities;
using EcsRx.Views.Components;
using Game.Components;

namespace Game.Blueprints
{
  public class PickupFoodDisplayBlueprint : IBlueprint
  {
    /// <inheritdoc />
    public void Apply(IEntity entity)
    {
      entity.AddComponents(new PickupFoodDisplayComponent(), new ViewComponent());
    }
  }
}
