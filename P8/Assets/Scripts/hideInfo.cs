using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hideInfo : MonoBehaviour
{
    public GameObject infoToHide;
    private bool isActive = true;

  
   public  void OnButtonClick() 
    {
        !isActive = isActive; 
        info.SetActive(!isActive);
      
    }
}
