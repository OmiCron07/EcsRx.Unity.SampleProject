using System;
using System.Collections.Generic;
using EcsRx.Entities;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.MicroRx.Extensions;
using EcsRx.Systems;
using EcsRx.Unity.Extensions;
using Game.Components;
using Game.Events;
using Game.SceneCollections;
using Game.Scripts.Enums;
using Game.Scripts.MethodExtensions;
using UnityEngine;

namespace Game.Systems
{
  public class SoundEffectSetupSystem : ISetupSystem, ITeardownSystem
  {
    private readonly FootStepSoundCollection _footStepSounds;
    private readonly PlayerAttackSoundCollection _playerAttackSounds;
    private readonly ApplePickupSoundCollection _applePickupSounds;
    private readonly SodaPickupSoundCollection _sodaPickupSounds;
    private readonly IEventSystem _eventSystem;
    private readonly ICollection<IDisposable> _disposables = new List<IDisposable>();


    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(AudioSourceComponent));


    public SoundEffectSetupSystem(FootStepSoundCollection footStepSounds,
                                  PlayerAttackSoundCollection playerAttackSounds,
                                  ApplePickupSoundCollection applePickupSounds,
                                  SodaPickupSoundCollection sodaPickupSounds,
                                  IEventSystem eventSystem)
    {
      _footStepSounds     = footStepSounds;
      _playerAttackSounds = playerAttackSounds;
      _applePickupSounds  = applePickupSounds;
      _sodaPickupSounds   = sodaPickupSounds;
      _eventSystem        = eventSystem;
    }

    /// <inheritdoc />
    public void Setup(IEntity entity)
    {
      var audioSource = entity.GetUnityComponent<AudioSource>();

      _eventSystem.Receive<FootStepSoundEvent>().Subscribe(x => audioSource.PlayOneShot(_footStepSounds.TakeRandom())).AddTo(_disposables);
      _eventSystem.Receive<AttackEvent>().Subscribe(x => audioSource.PlayOneShot(_playerAttackSounds.TakeRandom())).AddTo(_disposables);

      _eventSystem.Receive<PickupEvent>().Subscribe(x =>
                                                      {
                                                        AudioClip pickupSound;

                                                        switch (x.PickupableEntity.GetComponent<FoodComponent>().Type)
                                                        {
                                                          case FoodTypeEnum.Apple:
                                                            pickupSound = _applePickupSounds.TakeRandom();

                                                            break;

                                                          case FoodTypeEnum.Soda:
                                                            pickupSound = _sodaPickupSounds.TakeRandom();

                                                            break;

                                                          case FoodTypeEnum.Unknown:
                                                          default:

                                                            throw new ArgumentOutOfRangeException();
                                                        }

                                                        audioSource.PlayOneShot(pickupSound);
                                                      }).AddTo(_disposables);
    }

    /// <inheritdoc />
    public void Teardown(IEntity entity)
    {
      _disposables.DisposeAll();
    }
  }
}