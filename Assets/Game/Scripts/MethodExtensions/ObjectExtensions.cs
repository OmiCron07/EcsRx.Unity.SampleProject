using System;
using UniRx;

namespace Game.Scripts.MethodExtensions
{
  public static class ObjectExtensions
  {
    public static IObservable<long> WaitForScene(this object _)
    {
      return Observable.EveryUpdate().First();
    }
  }
}