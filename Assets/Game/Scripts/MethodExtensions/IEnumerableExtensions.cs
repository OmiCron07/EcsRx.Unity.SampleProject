using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Scripts.MethodExtensions
{
  public static class IEnumerableExtensions
  {
    public static T TakeRandom<T>(this IEnumerable<T> source)
    {
      var elements = source as T[] ?? source.ToArray();

      Assert.IsNotNull(elements, "elements != null");
      Assert.AreNotEqual(0, elements.Length, "elements != 0");

      var random = Random.Range(0, elements.Length);

      return elements[random];
    }
  }
}