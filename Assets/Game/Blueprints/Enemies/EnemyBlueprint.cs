using EcsRx.Blueprints;
using EcsRx.Entities;
using Game.Components;
using UnityEngine;

namespace Game.Blueprints.Enemies
{
  [CreateAssetMenu(fileName = "Enemy", menuName = "SampleProject/Enemy")]
  public class EnemyBlueprint : ScriptableObject, IBlueprint
  {
    public HitPointComponent HitPoint = new HitPointComponent();
    public DamageComponent Damage = new DamageComponent();


    /// <inheritdoc />
    public void Apply(IEntity entity)
    {
      entity.AddComponents(HitPoint);
      entity.AddComponents(Damage);
    }
  }
}