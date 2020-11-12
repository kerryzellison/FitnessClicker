using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePopUp : MonoBehaviour{
    public GameObject popup;
    
    public void OpenPopup(){
        if (popup.activeSelf == false){
            popup.SetActive(true);
        }
    }

    public void ClosePopup(){
        if (popup.activeSelf){
            popup.SetActive(false);
        }
    }
}
