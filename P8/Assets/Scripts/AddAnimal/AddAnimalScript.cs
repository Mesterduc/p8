// using System.Collections.Generic;
// using System.Linq;
// using DataPersistence;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections;
// using System;
// using magnus.johnson;


// public class AddAnimalScript : MonoBehaviour, IDataPersistence
// {
//     private List<FishTrivia> animalpictures = new List<FishTrivia>();
//     public Transform animalList;
//     public GameObject objectToSpawn;
//     // public Button addAnimal;



// //  public void Awake()
// //         {
// //             addAnimal.onClick.AddListener(() =>
// //             {
// //                 UpdateUi();
// //             });
// //         }

//     void Start()
//     {
//         Debug.Log(animalpictures[0]);

//        for (int i = 0; i<animalpictures.Count; i++)
//        {
//             GameObject Signe = Instantiate(objectToSpawn, animalList);
//             //Signe.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Fish/Sild");
//             Signe.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(animalpictures[i].picture);
//        }
//        Destroy(objectToSpawn);
//     }

//     // void UpdateUi()
//     //     {
//     //         GameObject newAnimal;
//     //         int i = animalpictures.Count - 1;
//     //         newAnimal = Instantiate(objectToSpawn, animalList);

//     //         newAnimal.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(animalpictures[i].name);
       
//     //         newAnimal.SetActive(true);
//     //         //Debug.Log(newAnimal.name);
//     //     }
//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public void LoadData(GameData data)
//     {
//         this.animalpictures = data.animalpictures;
//     }

//     public void SaveData(GameData data)
//     {
//          // throw new System.NotImplementedException();
//         data.animalpictures = this.animalpictures;
//     }
// }
