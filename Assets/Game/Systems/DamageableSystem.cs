using System;
using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Systems;
using Game.Components;

namespace Game.Systems
{
  public class DamageableSystem : IReactToEntitySystem
  {
    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(HitPointComponent));


    /// <inheritdoc />
    public IObservable<IEntity> ReactToEntity(IEntity entity)
    {
      return null;
    }

    /// <inheritdoc />
    public void Process(IEntity entity)
    {
    }
  }
}
