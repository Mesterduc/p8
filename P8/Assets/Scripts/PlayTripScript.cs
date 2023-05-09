using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using magnus.johnson;
using DataPersistence;

public class PlayTripScript : MonoBehaviour, IDataPersistence
{
    [SerializeField] private List<Journey> journeys = new List<Journey>();

    [SerializeField] private List<Destination> destinations = new List<Destination>();


     private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
     }

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }


    public void LoadData(GameData data) {
        Debug.Log("HAHA");
        this.destinations = data.destinations;
        this.journeys = data.journeys;
             for(int i = 0; i < journeys.Count; i++)
        {
            Debug.Log(journeys[i].destinationName);
        } 
}

    public void SaveData(GameData data) {
        data.destinations = this.destinations;
        data.journeys = this.journeys;
        }
}
