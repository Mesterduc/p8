using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundclose : MonoBehaviour
{
    public GameObject info;
    private bool isActive = false;

  
   public  void OnButtonClick() 
    {
        isActive = !isActive; 
        info.SetActive(isActive);
      
    }
}