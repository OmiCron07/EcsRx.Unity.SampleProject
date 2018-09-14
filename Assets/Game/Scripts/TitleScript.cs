using System.Collections;
using Game.Scripts.MethodExtensions;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Scripts
{
  public class TitleScript : MonoBehaviour
  {
    [SerializeField] private GameObject _next;


    private void Start()
    {
      _next.SetActive(false);
      var element = GetComponent<TextMeshProUGUI>();
      this.WaitForScene().Subscribe(_ => element.StartCoroutine(TitleCoroutine(element))).AddTo(this);
    }

    private void OnEnable()
    {
      Assert.IsNotNull(_next, "_next != null");
    }

    private IEnumerator TitleCoroutine(TextMeshProUGUI element)
    {
      element.text = "Game Maker Company";

      yield return new WaitForSeconds(2);

      element.text = "Presents";

      yield return new WaitForSeconds(1.25f);

      element.text = "Killer Title";

      yield return new WaitForSeconds(2.25f);

      gameObject.GetComponentInParent<Transform>().gameObject.SetActive(false);
      _next.SetActive(true);
    }
  }
}