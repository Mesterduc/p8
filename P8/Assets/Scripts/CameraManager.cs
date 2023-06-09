using System.Collections;
using DataPersistence;
using DataStore;
using Models;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class CameraManager : MonoBehaviour, IDataPersistence {

    private Journey journey;
    // Camera
    private WebCamTexture webcam;
    public RawImage background;
    
    [SerializeField] private GameObject AcceptPanel;
    [SerializeField] private Button snapshot;
    [SerializeField] private Button retakeImageButton;
    [SerializeField] private Button SaveImageButton;
    [SerializeField] private Button closeButton;

    void Awake() {
        DataPersistenceManager.Instance.manualLoadData();
        snapshot.onClick.AddListener(takeSnapShot);
        retakeImageButton.onClick.AddListener(RetakeImage);
        // StartCoroutine: bruges til at stoppe programmet
        SaveImageButton.onClick.AddListener(() => StartCoroutine(SaveImage()));
    }

    IEnumerator Start() {
        // giv adgang til brug af camera
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam)) {
            int firstCameraFound = 0;
            for (int i = 0; i < WebCamTexture.devices.Length; i++) {
                if (WebCamTexture.devices[i].name != null) {
                    firstCameraFound = i;
                }
            }
            webcam = new WebCamTexture(WebCamTexture.devices[firstCameraFound].name, Screen.width, Screen.height);
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
        closeButton.gameObject.SetActive(false);
        yield return
            new WaitForEndOfFrame(); // venter til slutningen af et frame, hvor ui elementerne er fjernet før der tages et snapshot/screenshot
        // hvis folder ikke findes, laves en ny folder
        if (!System.IO.Directory.Exists(Application.persistentDataPath + "/" + journey.id)) {
            System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/" + journey.id);
        }
    
        string name = journey.destination.name.Replace(" ", "");
        // Application.persistentDataPath: hvor skal billedet gemmes.  efter "/": hvad skal billedet hedde.
        string path = Application.persistentDataPath + "/" + journey.id + "/" + name + journey.gallery.Count + ".png";
        ScreenCapture.CaptureScreenshot(path);
        journey.gallery.Add(path);
        DataPersistenceManager.Instance.SaveGame();
    }

    public void LoadData(GameData data) {
        // Finder den rigtige journey
        Journey dataJourney = data.journeys.FindJourney(Hogsmeade.activeTripId);
        this.journey = dataJourney;
    }

    public void SaveData(GameData data) {
        data.journeys.ReplaceJourney(Hogsmeade.activeTripId, this.journey);
    }
}
