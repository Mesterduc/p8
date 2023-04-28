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
        Debug.Log(destinations[0]);
        for(int i = 0; i < destinations.Count; i++)
        {
            GameObject location = Instantiate(objectToSpawn, destinations[i].position, Quaternion.identity);
            location.transform.parent = GameObject.Find("pngdenmark").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
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
