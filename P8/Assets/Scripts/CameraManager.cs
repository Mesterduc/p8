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
        snapshot.onClick.AddListener(() => StartCoroutine(takeSnapShot()));
    }

    void Start() {
        webcam = new WebCamTexture(Screen.width, Screen.height);
        webcam.Play();
        background.texture = webcam;
        // float ratio = (float)webcam.width / (float)webcam.height;
        // fit.aspectRatio = ratio;
        // camAvailable = true;
    }

     private IEnumerator takeSnapShot() {
         // StartCoroutine(1);
        snapshot.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot("hong.png");
        
        snapshot.gameObject.SetActive(true);
        Debug.Log("snapshot");
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