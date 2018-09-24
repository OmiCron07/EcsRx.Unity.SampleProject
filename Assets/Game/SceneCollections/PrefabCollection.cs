using System;
using System.Collections.Generic;
using Game.Scripts.Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.SceneCollections
{
  public class PrefabCollection : Dictionary<PrefabEnum, GameObject>
  {
    public PrefabCollection()
    {
      Debug.Log("[PrefabCollection ctor] before load async");
      Addressables.LoadAssets<GameObject>("Prefab", x =>
                                                      {
                                                        Debug.Log($"[PrefabCollection module async] Prefab {x.Result.name} loaded");
                                                        Add((PrefabEnum) Enum.Parse(typeof(PrefabEnum), x.Result.name), x.Result);
                                                      });
    }
  }
}
