using System;
using System.Collections.Generic;
using Animals;
using DataPersistence;
using magnus.johnson;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AddAnimal {
    public class AddAnimalScript : MonoBehaviour, IDataPersistence
    {
        private List<FishTrivia> animalpictures = new List<FishTrivia>();
        private List<Animal> animalListGameList = new List<Animal>();
        public Transform animalList;
        public GameObject objectToSpawn;
        
        public Button forwards;
        public Button back;
        public GameObject panelSpices;
        public GameObject panelAnimalInfo;
        // public Button addAnimal;

        private void Awake() {
            forwards.onClick.AddListener(ShowSpices);
            back.onClick.AddListener(ShowAnimalInfo);
        }

        void Start()
        {
            for (int i = 0; i<animalpictures.Count; i++)
            {
                GameObject animalSpices = Instantiate(objectToSpawn, animalList);
                animalSpices.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(animalpictures[i].picture);
                animalSpices.transform.GetChild(1).GetComponent<TMP_Text>().text = animalpictures[i].name;
            }
        }

        public void AddAnimal() {
            Movement move = new Movement(150, 20, 400);
            Activity fang_fisk = new Activity("Fisketur", "Anskaf dig en fiskestang og se en video");
            FishTrivia ørred = new FishTrivia("Ørred", "Fish/Sild",fang_fisk, "Andre fisk", "Sjælden", "Ørred finder du aldrig min dud");
            Animal animal = new Animal(5, "Predo", "Fish/Sild", "Fish/SildAnimator", true, AnimalSize.large, move, ørred);
            animalListGameList.Add(animal);
        }
        
        public void ShowSpices() {
            panelSpices.SetActive(true);
            panelAnimalInfo.SetActive(false);
        }
        
        public void ShowAnimalInfo() {
            panelSpices.SetActive(false);
            panelAnimalInfo.SetActive(true);
        }
        

        public void RecogniseAnimal(string input) {
            // return possible species
        }
    
        public void LoadData(GameData data)
        {
            this.animalpictures = data.animalpictures;
            this.animalListGameList = data.animals;
        }

        public void SaveData(GameData data)
        {
            data.animalpictures = this.animalpictures;
            data.animals = this.animalListGameList;
        }
    }
}
