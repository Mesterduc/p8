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
    public GameObject modal;
    public GameObject text;
    private bool isHidden = true;
    private int currentWindow = -1;



    private void Awake()
        {
        }

    void Start()
    {
        Debug.Log(destinations[0]);
        for(int i = 0; i < destinations.Count; i++)
        {
            GameObject objectToSpawn = Resources.Load("Prefabs/" + destinations[i].type.name) as GameObject;
            GameObject location = Instantiate(objectToSpawn, destinations[i].position, Quaternion.identity);
            location.transform.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("DestinationIcon/" + destinations[i].type.name);
            location.transform.SetParent(GameObject.Find("pngdenmark").transform, false);
            location.name = i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowModal(string tag)
    {
        int id = int.Parse(tag);
        if(isHidden == true)
        {
            text.GetComponent<TMP_Text>().text = destinations[id].name;
            currentWindow = id;
            modal.SetActive(isHidden);
            isHidden = !isHidden;

        } else if(isHidden == false && currentWindow != id)
        {
            text.GetComponent<TMP_Text>().text = destinations[id].name;
            currentWindow = id;
        }
        else
        {
        modal.SetActive(isHidden);
        isHidden = !isHidden;
        }


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
