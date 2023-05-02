using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hideInfo : MonoBehaviour
{
    public GameObject infoToHide;
    private bool isActive;

  
   public  void OnButtonClick() 
    {
        if (isActive == true)
        {
            isActive = false; 
            infoToHide.SetActive(!isActive);
      
        }
    }
}
