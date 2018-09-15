using System;
using EcsRx.Components;
using UniRx;

namespace Game.Components
{
  [Serializable]
  public class HitPointComponent : IComponent
  {
    public IntReactiveProperty HitPoint = new IntReactiveProperty();
  }
}
