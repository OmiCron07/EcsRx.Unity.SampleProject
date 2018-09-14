using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Game.Scripts.Behaviors
{
  public class SelectOnEnabledBehavior : MonoBehaviour
  {
    private void OnEnable()
    {
      var selectable = GetComponent<Selectable>();
      Assert.IsNotNull(selectable, "selectable != null");
      selectable.Select();
    }
  }
}