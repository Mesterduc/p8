using System.Collections.Generic;
using System.Linq;
using DataPersistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[System.Serializable]
public class MenuScript : MonoBehaviour, IDataPersistence
{
    public List<Destination> destinations = new List<Destination>();
    public TMP_Text textcomponent;

    [SerializeField] private GameObject objectToSpawn; 
    [SerializeField] private Transform destinationList;
    private string destinationID;

    public Vector3 spawnPosition;

    private void Awake()
        {
        }

    void Start()
    {
    //    for (int i = 0; i < destinations.Count; i++)
    //         {

    //             GameObject objectToSpawn = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity); 
    //             Image
    //             objectToSpawn.transform.GetComponent<SpriteRenderer>().sprite =
    //                 Resources.Load<Sprite>("DestinationIcon/" + destinations[i].type.name);
    //             Nested components: destination information
    //             Transform newDestinationInfo = newDestination.transform.GetChild(1).transform;
    //             newDestinationInfo.GetChild(0).GetComponent<TMP_Text>().text = destinations[i].name;
    //             newDestinationInfo.GetChild(1).GetComponent<TMP_Text>().text = destinations[i].information;
    //             newDestinationInfo.GetChild(2).GetComponent<TMP_Text>().text = destinations[i].type.name; 
    //         }
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn(); // Call the Spawn() method when the Space key is pressed
        }
    }

     void Spawn()
    {
        // Instantiate the objectToSpawn at the spawnPosition with no rotation
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

 public void ReadStringInput(string id)
        {
            destinationID = id;
        }

    public void LoadData(GameData data)
    {
        destinations = data.destinations;
    }

    public void SaveData(GameData data)
    {
         // throw new System.NotImplementedException();
        data.destinations = this.destinations;
    }
}
