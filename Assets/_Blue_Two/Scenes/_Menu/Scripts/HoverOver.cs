using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Text;
    void Start()
    {
        Text.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Text.SetActive(false);

    }


}
