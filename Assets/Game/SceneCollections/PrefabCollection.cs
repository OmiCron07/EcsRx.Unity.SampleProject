using System;
using System.Collections.Generic;
using Game.Scripts.Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

namespace Game.SceneCollections
{
  public class PrefabCollection : Dictionary<PrefabEnum, GameObject>, IAsyncCollection
  {
    /// <inheritdoc />
    public IAsyncOperation AsyncOperation { get; }


    public PrefabCollection()
    {
      Debug.Log("[PrefabCollection ctor] before load async");

      AsyncOperation = Addressables.LoadAssets<GameObject>("Prefab",
                                                           x =>
                                                             {
                                                               Debug.Log($"[PrefabCollection module async] Prefab {x.Result.name} loaded");
                                                               Add((PrefabEnum) Enum.Parse(typeof(PrefabEnum), x.Result.name), x.Result);
                                                             });
    }
  }
}