using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class DisplaySpellInfo : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{

    public GameObject popup;
    public void OnPointerEnter(PointerEventData eventData)
    {
        popup.SetActive(true);
        Debug.Log("displaying popup");
    }
    public void OnPointerExit(PointerEventData eventData){
        popup.SetActive(false);
    }
}
