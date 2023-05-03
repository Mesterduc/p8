using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataPersistence;
using magnus.johnson;

public class infoSceneScript : MonoBehaviour, IDataPersistence
{
    public List<Destination> destinations;

    void start()
    {      
        Debug.Log(destinations);
        for (int i = 0; i < destinations.Count; i++) {
            Debug.Log(destinations);
            GameObject objectToSpawn = Resources.Load<GameObject>("Prefabs/" + destinations[i].type.name);
            if (objectToSpawn)
            {
                GameObject location = Instantiate(objectToSpawn, destinations[i].position, Quaternion.identity);
                location.transform.SetParent(GameObject.Find("Destinations").transform, false);
                location.name = i.ToString();
            }
            }
    }





    public void LoadData(GameData data) {
            this.destinations = data.destinations;
}

    public void SaveData(GameData data) {
            data.destinations = this.destinations;
        }
}
