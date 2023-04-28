using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    { 

    }

    void OnMouseDown()
    {
        GameObject menu = GameObject.Find("UI");
        MenuScript script = menu.GetComponent<MenuScript>();

        script.ShowModal(this.name);
    }


}