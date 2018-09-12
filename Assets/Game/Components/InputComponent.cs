using System;
using EcsRx.Components;
using UniRx;
using UnityEngine;

namespace Game.Components
{
  public class InputComponent : IComponent
  {
    public IObservable<Vector2> Movement { get; set; }

    public IObservable<Unit> Fire { get; set; }


    public IObservable<Unit> MenuUp { get; set; }

    public IObservable<Unit> MenuDown { get; set; }

    public IObservable<Unit> MenuLeft { get; set; }

    public IObservable<Unit> MenuRight { get; set; }

    public IObservable<Unit> MenuAccept { get; set; }

    public IObservable<Unit> MenuBack { get; set; }
  }
}