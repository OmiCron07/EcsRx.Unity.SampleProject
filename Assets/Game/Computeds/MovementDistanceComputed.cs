using System;
using System.Linq;
using EcsRx.Computed;
using EcsRx.Extensions;
using EcsRx.Groups.Observable;
using EcsRx.Unity.Extensions;
using Game.Components;
using UniRx;
using UnityEngine;

namespace Game.Computeds
{
  public class MovementDistanceComputed : ComputedFromGroup<bool>, IMovementDistanceComputed
  {
    private Vector2 _lastMovement;


    ///// <inheritdoc />
    //public override bool Transform(Vector2ReactiveProperty dataSource)
    //{
    //  _lastMovement = dataSource.Value - _lastMovement;

    //  return _lastMovement.magnitude >= 1f;
    //}
    /// <inheritdoc />
    public MovementDistanceComputed(IObservableGroup internalObservableGroup) : base(internalObservableGroup)
    {
    }

    /// <inheritdoc />
    public override IObservable<bool> RefreshWhen()
    {
      return Observable.EveryFixedUpdate().Select(_ => true);
    }

    /// <inheritdoc />
    public override bool Transform(IObservableGroup observableGroup)
    {
      var currentMovement = observableGroup.FirstOrDefault()?.GetUnityComponent<Rigidbody2D>().position;

      if (currentMovement == null)
      {
        return false;
      }

      float magnitude = (currentMovement.Value - _lastMovement).magnitude;
      Debug.Log($"Current: {currentMovement}; Last: {_lastMovement}: Ma: {magnitude}");
      if (magnitude >= 1f)
      {
        _lastMovement = currentMovement.Value;

        return true;
      }

      return false;
    }
  }


  public interface IMovementDistanceComputed : IComputed<bool>
  {
  }
}
