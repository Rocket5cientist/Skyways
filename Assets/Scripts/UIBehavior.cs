using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string cityName;

    private Vector2 smallSize;
    private Vector2 bigSize;
    private RectTransform rt;

    private void Start() {
        rt = gameObject.GetComponent<Button>().GetComponent<RectTransform>();
        smallSize = rt.sizeDelta;
        bigSize = smallSize * 2;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        rt.sizeDelta = bigSize;
    }

    public void OnPointerExit(PointerEventData eventData) {
        rt.sizeDelta = smallSize;
    }

    public void PrintName() {
        Debug.Log(cityName);
    }
}
