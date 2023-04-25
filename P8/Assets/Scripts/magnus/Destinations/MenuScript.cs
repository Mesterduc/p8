using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataPersistence;
using TMPro;


namespace Scenes{

public class MenuScript : MonoBehaviour, IDataPersistence
{
    private List<Friend> Friends;
    public List<Destination> strande = new List<Destination>();
    public TMP_Text textcomponent;

    private void Awake()
        {
            if(Friends[0] != null)
            {textcomponent.text = Friends[0].name;}
            else{textcomponent.text = "Johnny";}
            
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.strande = data.strande;
        this.Friends = data.friends;
    }

    public void SaveData(GameData data)
    {
         // throw new System.NotImplementedException();
        data.strande = this.strande;
        data.friends = this.Friends;
    }
}}
