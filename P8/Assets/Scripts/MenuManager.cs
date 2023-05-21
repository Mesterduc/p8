using System.Collections.Generic;
using UnityEngine;
using DataPersistence;
using DataStore;
using TMPro;
using Models;

public class MenuManager : MonoBehaviour, IDataPersistence {
    [SerializeField] private Map map = new Map();
    [SerializeField] private Journeys journeys = new Journeys();
    public GameObject content;
    [SerializeField] public GameObject tripInfo;
    public GameObject playInfo;
    public GameObject bottomPanel;

    private void Awake() {
        DataPersistenceManager.Instance.manualLoadData();
    }

    void Start() {
        if (Hogsmeade.nextTrip < 0) {
            NoTrip();
        }
        else {
            activeTrip();
        }
    }

    private void activeTrip() {
        OpenWindows();
        PopulatePanels();
    }

    private void NoTrip() {
        content.transform.Find("activeTrip").gameObject.SetActive(false);
        content.transform.Find("noTrip").gameObject.SetActive(true);
        content.transform.Find("comingTrip").gameObject.SetActive(false);
    }

    private void PopulatePanels() {
        tripInfo.GetComponent<TMP_Text>().text = map.destinations[Hogsmeade.nextTrip].address;
    }

    private void OpenWindows() {
        content.transform.Find("activeTrip").gameObject.SetActive(false);
        content.transform.Find("noTrip").gameObject.SetActive(false);
        content.transform.Find("comingTrip").gameObject.SetActive(true);
        bottomPanel.SetActive(true);
    }

    public void BeginJourney() {
        int id = this.journeys.JourneyCount() + 1;
        Hogsmeade.activeTripId = id;
        journeys.AddJourney(new Journey(id, map.destinations[Hogsmeade.nextTrip]));
        DataPersistenceManager.Instance.SaveGame();
    }

    public void LoadData(GameData data) {
        this.map = data.map;
        this.journeys = data.journeys;
    }

    public void SaveData(GameData data) {
        data.map = this.map;
        data.journeys = this.journeys;
    }
}