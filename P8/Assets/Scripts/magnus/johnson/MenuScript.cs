using System.Collections.Generic;
using System.Linq;
using DataPersistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


namespace Magnus.johnson{

public class MenuScript : MonoBehaviour, IDataPersistence
{
    private List<Friend> Friends;
    public List<Destination> strande = new List<Destination>();
    public TMP_Text textcomponent;

    private void Awake()
        {

           /* if(strande[0].name != null)
            {
                textcomponent.text = strande[0].name;
            }
            else{textcomponent.text = "Johnny";}
            */
        }

    void Start()
    {
        Console.WriteLine(strande);

        Debug.Log(strande);
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
}}
