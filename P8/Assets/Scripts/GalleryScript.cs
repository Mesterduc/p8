using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using DataPersistence;
using Models;
using TMPro;
using UnityEngine;

public class GalleryScript : MonoBehaviour, IDataPersistence {
    private List<Journey> journeys = new List<Journey>();
    [SerializeField] private Transform placement;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < journeys.Count; i++) {
            GameObject prefab = Resources.Load<GameObject>("prefabs/UdflugtPrefab");
            GameObject journeyItem = Instantiate(prefab, placement);
            journeyItem.transform.Find("content/activeTrip/LocationIcon/Title/Text").GetComponent<TMP_Text>().text =
                journeys[i].destination.name;
            journeyItem.transform.Find("content/activeTrip/Date/").GetComponent<TMP_Text>().text =
                // dddd: dag i text
                journeys[i].date.ToString("dddd dd-MM-yyyy", new CultureInfo("en-US"));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data) {
        this.journeys = data.journeys;
    }

    public void SaveData(GameData data) {
        data.journeys = this.journeys;
    }
}
