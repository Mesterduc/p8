using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showInfo : MonoBehaviour
{
    public GameObject info;
    private bool isActive = false;

  
   public  void OnButtonClick() 
    {
        isActive = !isActive; 
        info.SetActive(isActive);
      
    }
}
