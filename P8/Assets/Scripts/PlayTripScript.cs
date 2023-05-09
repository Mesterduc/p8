using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using magnus.johnson;
using DataPersistence;

public class PlayTripScript : MonoBehaviour, IDataPersistence
{
    private List<Journey> journeys;
    private List<Destination> destinations;


     private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
        }

    // Start is called before the first frame update
    void Start()
    {
           for(int i = 0; i < journeys.Count; i++)
        {
            Debug.Log(journeys[i].destination.name);
        }
        Screen.orientation = ScreenOrientation.Portrait;
    }


    public void LoadData(GameData data) {
        this.destinations = data.destinations;
        this.journeys = data.journeys;
}

    public void SaveData(GameData data) {
        // data.destinations = this.destinations;
        // data.journeys = this.journeys;
        }
}
