using EcsRx.Blueprints;
using EcsRx.Entities;
using Game.Components;

namespace Game.Blueprints
{
  public class FoodDisplayBlueprint : IBlueprint
  {
    /// <inheritdoc />
    public void Apply(IEntity entity)
    {
      entity.AddComponents(new FoodDisplayComponent());
    }
  }
}
