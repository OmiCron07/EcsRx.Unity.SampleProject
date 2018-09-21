using System;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;
using EcsRx.Unity.Extensions;
using Game.Components;
using UniRx;
using UnityEngine;

namespace Game.Systems
{
  public class MovableSystem : IReactToEntitySystem
  {
    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(MovableComponent));


    /// <inheritdoc />
    public IObservable<IEntity> ReactToEntity(IEntity entity)
    {
      return Observable.EveryFixedUpdate().Select(_ => entity).Where(x =>
                                                                       {
                                                                         var movableComponent = x.GetComponent<MovableComponent>();

                                                                         return movableComponent.Speed != 0;
                                                                       });
    }

    /// <inheritdoc />
    public void Process(IEntity entity)
    {
      var movableComponent = entity.GetComponent<MovableComponent>();

      var animator = entity.GetGameObject().GetComponentInChildren<Animator>();
      animator.SetBool("IsMoving", movableComponent.Movement.Value.magnitude > 0f);

      if (movableComponent.Movement.Value == Vector2.zero)
      {
        return;
      }

      var rigidbody = entity.GetUnityComponent<Rigidbody2D>();

      rigidbody.MovePosition(rigidbody.position + movableComponent.Movement.Value * movableComponent.Speed * Time.fixedDeltaTime);

      var spriteRenderer = entity.GetGameObject().GetComponentInChildren<SpriteRenderer>();
      spriteRenderer.flipX = movableComponent.Movement.Value.x < 0;
    }
  }
}