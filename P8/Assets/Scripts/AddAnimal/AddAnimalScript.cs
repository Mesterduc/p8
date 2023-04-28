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
    private List<FishTrivia> animalpictures = new List<FishTrivia>();
    public Transform animalList;
    public GameObject objectToSpawn;
    //public GameObject objectToSpawn2;
    // GameObject.Find("animalList").transform;
    

    private void Awake()
        {
        }

    void Start()
    {
        Debug.Log(animalpictures[0]);

       for (int i = 0; i<animalpictures.Count; i++)
       {
            
            GameObject Signe = Instantiate(objectToSpawn, animalList);
            //Signe.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Fish/Sild");
            Signe.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(animalpictures[i].picture);
       }
       Destroy(objectToSpawn);
        //animalpictures[0].picture = "";
        //animalpictures[0].activities = Krabbejagt;
        //animalpictures[0].diet = "";
        // animalpictures[0].status = "";
        // animalpictures[0].bio = "";

        // animalpictures[1].name = "Berta";
        // animalpictures[1].picture = "";
        // //animalpictures[1].activities = Krabbejagt;
        // animalpictures[1].diet = "";
        // animalpictures[1].status = "";
        // animalpictures[1].bio = "";

        // animalpictures[2].name = "Klaus";
        // animalpictures[2].picture = "";
        // //animalpictures[2].activities = Krabbejagt;
        // animalpictures[2].diet = "";
        // animalpictures[2].status = "";
        // animalpictures[2].bio = "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.animalpictures = data.animalpictures;
    }

    public void SaveData(GameData data)
    {
         // throw new System.NotImplementedException();
        data.animalpictures = this.animalpictures;
    }
}
