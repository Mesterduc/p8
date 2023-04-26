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
    private List<Friend> Friends;
    public List<Destination> strande = new List<Destination>();
    public TMP_Text textcomponent;

    private void Awake()
        {
        }

    void Start()
    {
        Activity fang_krabber = new Activity("Krabbejagt", "Lav et net og gå i gang");
        FishTrivia krabbe = new FishTrivia("Krabbe", "krabbebillede", fang_krabber, "Kød", "Almindelig", "Krabben er fandeme over det hele man");
        Biome strand = new Biome("Stranden", fang_krabber, krabbe);
        Destination Eriksen = new Destination("Eriksen", "Ballehage er et super sted at være om sommeren", strand);
        Debug.Log(strande[0].name);


        if(strande[0].name != null)
            {
                textcomponent.text = strande[0].name;
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
        strande = data.strande;
    }

    public void SaveData(GameData data)
    {
         // throw new System.NotImplementedException();
        data.strande = this.strande;
    }
}
