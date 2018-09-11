using System;
using System.Collections.Generic;
using EcsRx.Components;
using Game.Scripts.Enums;
using UnityEditor;

namespace Game.Components
{
  [Serializable]
  public class SceneProfileComponent : IComponent
  {
    public SceneProfileEnum Profile;
    public bool IsMaster;
    public bool IsAdditive;
    public List<SceneAsset> Scenes;
  }
}