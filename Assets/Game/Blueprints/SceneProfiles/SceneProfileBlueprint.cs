using EcsRx.Blueprints;
using EcsRx.Entities;
using Game.Components;
using UnityEngine;

namespace Game.Blueprints.SceneProfiles
{
  [CreateAssetMenu(fileName = "SceneProfile", menuName = "SampleProject/Scene Profile")]
  public class SceneProfileBlueprint : ScriptableObject, IBlueprint
  {
    public SceneProfileComponent SceneProfile = new SceneProfileComponent();


    /// <inheritdoc />
    public void Apply(IEntity entity)
    {
      entity.AddComponents(SceneProfile);
    }
  }
}
