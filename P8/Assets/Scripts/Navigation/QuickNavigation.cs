using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Navigation;
using UnityEngine.SceneManagement;

public class QuickNavigation : MonoBehaviour
{
     public void GoToMap()
    {
        SceneManager.LoadSceneAsync("menu");
    }

     public void GoToPlay()
    {
        SceneManager.LoadSceneAsync("playtrip");
    }

     public void GoToGallery()
    {
        SceneManager.LoadSceneAsync("gallery");
    }
     public void GoToTank()
    {
        SceneManager.LoadSceneAsync("TankScene");
    }
     public void GoToChoose()
    {
        SceneManager.LoadSceneAsync("ChooseTrip"); 
    }

      public void GoToAnimal()
    {
        SceneManager.LoadSceneAsync("AddAnimalsScene");
    }

    public void EndTrip()
    {
        Hogsmeade.nextTrip = -1;
        GoToGallery();
    }
}
