using System;
using System.Runtime.Serialization;
using EcsRx.Components;
using UniRx;

namespace Game.Components
{
  public class MovableComponent : IComponent, IDisposable
  {
    public float Speed { get; set; }

    public Vector2ReactiveProperty Movement { get; set; } = new Vector2ReactiveProperty();


    /// <inheritdoc />
    public void Dispose()
    {
      Movement?.Dispose();
    }
  }
}