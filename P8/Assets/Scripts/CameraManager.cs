using System;
using System.Collections;
using System.Collections.Generic;
using DataPersistence;
using Models;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class CameraManager : MonoBehaviour, IDataPersistence {
    private Journey journey;
    private bool camAvailable;
    private WebCamTexture webcam;
    public RawImage background;
    [SerializeField] private Button snapshot;
    [SerializeField] private Button retakeImageButton;
    [SerializeField] private Button SaveImageButton;
    [SerializeField] private GameObject AcceptPanel;

    // TODO: front or back-side camera
    void Awake() {
        // StartCoroutine: bruges til at stoppe programmet
        snapshot.onClick.AddListener(takeSnapShot);
        retakeImageButton.onClick.AddListener(RetakeImage);
        SaveImageButton.onClick.AddListener(() => StartCoroutine(SaveImage()));
    }

    IEnumerator Start() {
        // giv adgang til brug af camera
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam)) {
            // TODO: find ud af hvilken camera der skal bruges
            webcam = new WebCamTexture(Screen.width, Screen.height);
            webcam.Play();
            background.texture = webcam;
        }
    }

    private void takeSnapShot() {
        snapshot.gameObject.SetActive(false);
        AcceptPanel.gameObject.SetActive(true);
        webcam.Pause();
    }

    public void RetakeImage() {
        webcam.Play();
        snapshot.gameObject.SetActive(true);
        AcceptPanel.gameObject.SetActive(false);
    }

    // IEnumerator for at kunne bruge StartCoroutine
    public IEnumerator SaveImage() {
        AcceptPanel.gameObject.SetActive(false);
        yield return
            new WaitForEndOfFrame(); // venter til slutningen af et frame, hvor ui elementerne er fjernet før der tages et snapshot/screenshot
        // hvis folder ikke findes, laves der en ny folder
        if (!Directory.Exists(Application.persistentDataPath + "/" + journey.id)) {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + journey.id);
        }

        string name = journey.destination.name.Replace(" ", "");
        // Application.persistentDataPath: hvor skal billedet gemmes.  efter "/": hvad skal billedet hedde.
        string path = Application.persistentDataPath + "/" + journey.id + "/" + name + journey.gallery.Count + ".png";
        ScreenCapture.CaptureScreenshot(path);
        journey.gallery.Add(path);
        AcceptPanel.gameObject.SetActive(true);
        DataPersistenceManager.Instance.SaveGame2();
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