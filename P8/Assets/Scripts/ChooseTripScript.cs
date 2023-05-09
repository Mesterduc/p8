using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataPersistence;
using magnus.johnson;
using UnityEngine.UI;
using TMPro;
using Models;

public class ChooseTripScript : MonoBehaviour, IDataPersistence {
    [SerializeField] private List<Destination> destinations = new List<Destination>();
    [SerializeField] private List<Journey> journeys = new List<Journey>();
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
        tripInfo.GetComponent<TMP_Text>().text = destinations[Hogsmeade.nextTrip].address;
    }

    private void OpenWindows() {
        content.transform.Find("activeTrip").gameObject.SetActive(false);
        content.transform.Find("noTrip").gameObject.SetActive(false);
        content.transform.Find("comingTrip").gameObject.SetActive(true);
        bottomPanel.SetActive(true);
    }

    public void BeginJourney() {
        int id = Hogsmeade.activeTripId++;
        journeys.Add(new Journey(id, destinations[Hogsmeade.nextTrip]));
        DataPersistenceManager.Instance.SaveGame2();
    }

    public void LoadData(GameData data) {
        this.destinations = data.destinations;
        this.journeys = data.journeys;
    }

    public void SaveData(GameData data) {
        data.destinations = this.destinations;
        data.journeys = this.journeys;
    }
}