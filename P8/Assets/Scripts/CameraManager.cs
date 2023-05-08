using System;
using System.Collections;
using System.Collections.Generic;
using DataPersistence;
using Models;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour, IDataPersistence {
    private Journey journey;
    private bool camAvailable;
    private WebCamTexture webcam;
    public RawImage background;
    [SerializeField] private Button snapshot;
    [SerializeField] private Button retakeImageButton;
    [SerializeField] private Button SaveImageButton;
    [SerializeField] private GameObject AcceptPanel;

    // private Texture defaultBackground;
    // public AspectRatioFitter fit;


    // TODO: front or back-side camera
    void Awake() {
        // StartCoroutine: bruges til at stoppe programmet
        snapshot.onClick.AddListener(takeSnapShot);
        retakeImageButton.onClick.AddListener(RetakeImage);
        SaveImageButton.onClick.AddListener(() => StartCoroutine(SaveImage()));
    }

    IEnumerator Start() {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam)) {
            webcam = new WebCamTexture(Screen.width, Screen.height);
            webcam.Play();
            background.texture = webcam;
        }
    }
// IEnumerator for at kunne bruge StartCoroutine
     private void takeSnapShot() {
        
    }

     public void RetakeImage() {
         snapshot.gameObject.SetActive(true);
         AcceptPanel.gameObject.SetActive(false);
     }

     public IEnumerator SaveImage() {
         snapshot.gameObject.SetActive(false);
         yield return new WaitForEndOfFrame(); // venter til slutningen af et frame, hvor ui elementerne er fjernet før der tages et snapshot/screenshot
         // Application.persistentDataPath: hvor skal billedet gemmes.  efter /: hvad skal billedet hedde.
         ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/" + journey.id + "/" + journey.gallery.Count + ".png");
         AcceptPanel.gameObject.SetActive(true);
     }
    void Update() {
        
        // if (!camAvailable) return;

        //
        // float scaleY = webcam.videoVerticallyMirrored ? -1f : 1f;
        // background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
        //
        // int orient = -webcam.videoRotationAngle;
        // background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    public void LoadData(GameData data) {
        foreach (var journey in data.journeys) {
            if (journey.id == Hogsmeade.activeTripId) {
                this.journey = journey;
            }
        }
    }

    public void SaveData(GameData data) {
        foreach (var journey in data.journeys) {
            if (journey.id == Hogsmeade.activeTripId) {
                journey.gallery = this.journey.gallery;
            }
        }
    }
}