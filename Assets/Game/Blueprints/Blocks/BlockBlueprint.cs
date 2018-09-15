using EcsRx.Blueprints;
using EcsRx.Entities;
using Game.Components;
using UnityEngine;

namespace Game.Blueprints.Blocks
{
  [CreateAssetMenu(fileName = "Block", menuName = "SampleProject/Block")]
  public class BlockBlueprint : ScriptableObject, IBlueprint
  {
    public HitPointComponent HitPoint = new HitPointComponent();
    

    /// <inheritdoc />
    public void Apply(IEntity entity)
    {
      entity.AddComponents(HitPoint);
    }
  }
}
