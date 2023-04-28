using System.Collections.Generic;
using System.Linq;
using DataPersistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class AddAnimalScript : MonoBehaviour, IDataPersistence
{
    private List<Friend> Friends;
    public List<Destination> strande = new List<Destination>();
    public TMP_Text textcomponent;

    private void Awake()
        {
        
        }

    void Start()
    {

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
        this.strande = data.strande;
    }

    public void SaveData(GameData data)
    {
         // throw new System.NotImplementedException();
        data.strande = this.strande;
    }
}
