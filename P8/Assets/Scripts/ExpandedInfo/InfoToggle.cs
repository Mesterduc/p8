using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoToggle : MonoBehaviour
{
    public GameObject info;

    private static GameObject activeGameObject; // static variable to keep track of the currently active GameObject

    

    private void Start()
    {
        info.SetActive(false); //Hides all infoboxes
        if (info.CompareTag("Natur")) //Show infobox with the tag "Natur"
        {
            info.SetActive(true);
            activeGameObject = gameObject;
        }
    }

    public void OnButtonClick()
    {
        if (activeGameObject != null && activeGameObject != gameObject) // if there's another GameObject with an active info GameObject
        {
            activeGameObject.GetComponent<InfoToggle>().info.SetActive(false); // deactivate its info GameObject
        }

        activeGameObject = gameObject; // set this GameObject as the currently active one

        info.SetActive(!info.activeSelf); // toggle the info GameObject of this GameObject
    }
}