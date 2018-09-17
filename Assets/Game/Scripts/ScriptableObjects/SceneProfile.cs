using System.Collections.Generic;
using Game.Scripts.Enums;
using UnityEditor;
using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
  [CreateAssetMenu(fileName = "SceneProfile", menuName = "SampleProject/Scene Profile")]
  public class SceneProfile : ScriptableObject
  {
    public SceneProfileEnum Profile;
    public bool IsAdditive;
    public List<SceneAsset> Scenes;
  }
}
