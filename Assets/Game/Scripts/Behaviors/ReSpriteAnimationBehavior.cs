using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Scripts.Behaviors
{
  [RequireComponent(typeof(SpriteRenderer))]
  public class ReSpriteAnimationBehavior : MonoBehaviour
  {
    [SerializeField] private FromTo[] _spriteSwaps;

    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
      _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
      Assert.IsNotNull(_spriteSwaps, "_spriteSwaps != null");
      Assert.IsNotNull(_spriteRenderer, "_spriteRenderer != null");
    }

    private void LateUpdate()
    {
      var to = _spriteSwaps.SingleOrDefault(x => x.From == _spriteRenderer.sprite)?.To;
      Assert.IsNotNull(to, "to != null");

      _spriteRenderer.sprite = to;
    }
  }


  [Serializable]
  public class FromTo
  {
    public Sprite From;
    public Sprite To;
  }
}