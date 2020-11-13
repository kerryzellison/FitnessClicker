using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TogglePopUp : MonoBehaviour,IPointerClickHandler
{
    public GameObject popup;

    public bool shouldPopUp;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        popup.SetActive(shouldPopUp);
    }
}

