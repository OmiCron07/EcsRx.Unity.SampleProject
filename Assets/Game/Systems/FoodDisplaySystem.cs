using System;
using System.Collections.Generic;
using System.Linq;
using BindingsRx.Bindings;
using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;
using EcsRx.Unity.Extensions;
using Game.Components;
using TMPro;
using UniRx;

namespace Game.Systems
{
  public class FoodDisplaySystem : ISetupSystem, ITeardownSystem
  {
    private readonly IEntityCollectionManager _entityCollectionManager;
    private readonly ICollection<IDisposable> _disposables = new List<IDisposable>();


    /// <inheritdoc />
    public IGroup Group { get; } = new Group(typeof(FoodDisplayComponent));


    public FoodDisplaySystem(IEntityCollectionManager entityCollectionManager)
    {
      _entityCollectionManager = entityCollectionManager;
    }

    /// <inheritdoc />
    public void Setup(IEntity entity)
    {
      this.WaitForScene().Subscribe(_ =>
                                      {
                                        var textComponent = entity.GetUnityComponent<TextMeshProUGUI>();
                                        var playerEntity = _entityCollectionManager.GetEntitiesFor(new Group(typeof(PlayerComponent))).First();

                                        var hitPointComponent = playerEntity.GetComponent<HitPointComponent>();
                                        textComponent.BindTextTo(hitPointComponent.HitPoint).AddTo(_disposables);
                                      });
    }

    /// <inheritdoc />
    public void Teardown(IEntity entity)
    {
      _disposables.DisposeAll();
    }
  }
}