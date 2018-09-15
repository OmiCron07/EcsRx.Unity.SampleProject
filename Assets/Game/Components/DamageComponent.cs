using System;
using EcsRx.Components;

namespace Game.Components
{
  [Serializable]
  public class DamageComponent : IComponent
  {
    public int Damage;
  }
}
