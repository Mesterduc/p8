using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataPersistence;
using magnus.johnson;

public class ChooseTripScript : MonoBehaviour, IDataPersistence
{
    private string comingTrip = "john";

    void Start()
    {      
        if(Hogsmeade.nextTrip == null)
        {
            Debug.Log("Hey");
        }
    }





    public void LoadData(GameData data) {
}

    public void SaveData(GameData data) {
        }
}
