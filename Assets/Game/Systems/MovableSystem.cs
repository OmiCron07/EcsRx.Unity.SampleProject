using System;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;
using EcsRx.Unity.Extensions;
using Game.Components;
using Game.SceneCollections;
using Game.Scripts.MethodExtensions;
using UniRx;
using UnityEngine;

namespace Game.Systems
{
  public class MovableSystem : IReactToEntitySystem
  {
    private readonly FootStepSoundCollection _footStepSounds;


    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(MovableComponent));


    public MovableSystem(FootStepSoundCollection footStepSounds)
    {
      _footStepSounds = footStepSounds;
    }

    /// <inheritdoc />
    public IObservable<IEntity> ReactToEntity(IEntity entity)
    {
      return Observable.EveryFixedUpdate().Select(_ => entity).Where(x =>
                                                                       {
                                                                         var movableComponent = x.GetComponent<MovableComponent>();

                                                                         return movableComponent.Speed != 0 && movableComponent.Movement.Value != Vector2.zero;
                                                                       });
    }

    /// <inheritdoc />
    public void Process(IEntity entity)
    {
      var movableComponent = entity.GetComponent<MovableComponent>();
      var rigidbody = entity.GetUnityComponent<Rigidbody2D>();

      rigidbody.MovePosition(rigidbody.position + movableComponent.Movement.Value * movableComponent.Speed * Time.fixedDeltaTime);

      var spriteRenderer = entity.GetUnityComponent<SpriteRenderer>();
      spriteRenderer.flipX = movableComponent.Movement.Value.x < 0;

      var audioSource = entity.GetUnityComponent<AudioSource>();
      audioSource.PlayOneShot(_footStepSounds.TakeRandom());
    }
  }
}