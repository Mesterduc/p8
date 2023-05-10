using System.Collections;
using System.Collections.Generic;
using DataStore;
using UnityEngine;
using Navigation;
using UnityEngine.SceneManagement;

public class QuickNavigation : MonoBehaviour
{
     public void GoToMap()
    {
        ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.Menu);
    }

     public void GoToPlay()
    {
        ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.PlayTrip);
    }

     public void GoToGallery()
    {
        ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.Gallery);
    }
     public void GoToCamera()
    {
        ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.CameraScene);
    }
     public void GoToTank()
    {
        ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.TankScene);
    }
     public void GoToChoose()
    {
        ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.ChooseTrip);
    }

      public void GoToAnimal()
    {
        ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.AddAnimalsScene);
    }

    public void EndTrip()
    {
        Hogsmeade.nextTrip = -1;
        GoToGallery();
    }
}
