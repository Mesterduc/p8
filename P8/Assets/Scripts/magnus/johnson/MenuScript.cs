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

    private void Awake()
        {
        }

    void Start()
    {
        if(destinations[0].name != null)
            {
                textcomponent.text = destinations[0].name;
            }
            else
            {
                textcomponent.text = "Johnny";
            }
    }

    // Update is called once per frame
    void Update()
    {
        
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
