using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {
    private bool camAvailable;
    private WebCamTexture webcam;

    // private Texture defaultBackground;
    public RawImage background;
    public AspectRatioFitter fit;

    [SerializeField] private Button snapshot;

    // TODO: front or back-side camera
    void Awake() {
        // StartCoroutine: bruges til at stoppe programmet
        snapshot.onClick.AddListener(() => StartCoroutine(takeSnapShot()));
    }

    IEnumerator Start() {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (!Application.HasUserAuthorization(UserAuthorization.WebCam)) {
            Debug.Log("No auth");
        }
        webcam = new WebCamTexture(Screen.width, Screen.height);
        webcam.Play();
        background.texture = webcam;
    }
// IEnumerator for at kunne bruge StartCoroutine
     private IEnumerator takeSnapShot() {
        snapshot.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame(); // venter til slutningen af et frame, hvor ui elementerne er fjernet før der tages et snapshot/screenshot
        ScreenCapture.CaptureScreenshot("hong.png");
        snapshot.gameObject.SetActive(true);
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
}