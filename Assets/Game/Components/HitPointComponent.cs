using System;
using EcsRx.Components;
using UniRx;

namespace Game.Components
{
  public class HitPointComponent : IComponent, IDisposable
  {
    public IntReactiveProperty HitPoint { get; set; } = new IntReactiveProperty();


    /// <inheritdoc />
    public void Dispose()
    {
      HitPoint?.Dispose();
    }
  }
}
