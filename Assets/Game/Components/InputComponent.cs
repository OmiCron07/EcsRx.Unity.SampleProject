using System;
using EcsRx.Components;
using UniRx;

namespace Game.Components
{
  public class InputComponent : IComponent
  {
    public Vector2ReactiveProperty Movement { get; set; } = new Vector2ReactiveProperty();

    public IObservable<Unit> Fire { get; set; }
  }
}
