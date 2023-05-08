using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {
    private bool camAvailable;
    private WebCamTexture webcam;

    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    void Start() {
        defaultBackground = background.texture;

        webcam = new WebCamTexture(Screen.width, Screen.height);
        webcam.Play();
        background.texture = webcam;
        float ratio = (float)webcam.width / (float)webcam.height;
        fit.aspectRatio = ratio;
        // camAvailable = true;
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