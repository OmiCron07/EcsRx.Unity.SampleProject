using System;
using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.Systems;
using Game.Components;
using UniRx;

namespace Game.Systems
{
  public class DamageableSystem : IReactToEntitySystem
  {
    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(HitPointComponent));


    /// <inheritdoc />
    public IObservable<IEntity> ReactToEntity(IEntity entity)
    {
      return  Observable.EveryUpdate().Select(_ => entity);
    }

    /// <inheritdoc />
    public void Process(IEntity entity)
    {
    }
  }
}
