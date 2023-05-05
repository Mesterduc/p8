using System.Collections;
using System.Collections.Generic;
using DataPersistence;
using Models;
using UnityEngine;

public class GalleryScript : MonoBehaviour, IDataPersistence {
    private List<Journey> journeys = new List<Journey>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < journeys.Count; i++) {
            
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
