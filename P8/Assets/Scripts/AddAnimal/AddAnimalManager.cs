using System;
using System.Collections.Generic;
using Animals;
using DataPersistence;
using DataStore;
using Models;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace AddAnimal {
    public class AddAnimalManager : MonoBehaviour, IDataPersistence
    {
        private List<FishTrivia> animalTrivia = new List<FishTrivia>();
        private List<Animal> animalListGameList = new List<Animal>();
        public Transform animalList;
        public GameObject objectToSpawn;
        
        public GameObject textName;
        public int size;
        
        public Button forwards;
        public Button back;
        public GameObject panelSpices;
        public GameObject panelAnimalInfo;
        public GameObject specieInfoContainer;
        private FishTrivia specie;
        public Journey journey;

        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
            forwards.onClick.AddListener(ShowSpices);
            back.onClick.AddListener(ShowAnimalInfo);
        }

        void Start()
        {
            // Laver ikon til spices
            for (int i = 0; i < animalTrivia.Count; i++)
            {
                GameObject animalSpices = Instantiate(objectToSpawn, animalList);
                animalSpices.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(animalTrivia[i].picture);
                animalSpices.transform.GetChild(1).GetComponent<TMP_Text>().text = animalTrivia[i].name;
                var animal = animalTrivia[i];
                animalSpices.GetComponent<Button>().onClick.AddListener(() => populateAnimalInfo(animal));
            }
            
            // hvis der findes species så tag den første i listen og fokus den
            if (animalTrivia.Count != 0) {
                populateAnimalInfo(animalTrivia[0]);
            }
        }
        
        private void populateAnimalInfo(FishTrivia animalSpecie) {
            specie = animalSpecie;
            specieInfoContainer.transform.Find("Title").GetComponent<TMP_Text>().text = animalSpecie.name;
            specieInfoContainer.transform.Find("Beskrivelse").GetComponent<TMP_Text>().text = animalSpecie.bio;
            specieInfoContainer.transform.Find("Images").GetComponent<Image>().sprite = Resources.Load<Sprite>(animalSpecie.realPicture);
        }

        public void AddAnimal() {
            string name = textName.transform.GetComponent<TMP_Text>().text;
            Animal animal = new Animal(this.animalListGameList.Count + 1, name, (AnimalSize)size, specie, Hogsmeade.animalJourneyInGallery, Hogsmeade.animalImagePath);
            animal.setRealImage(Hogsmeade.animalImagePath);
            
            animalListGameList.Add(animal);
            DataPersistenceManager.Instance.SaveGame();
        }
        
        // -------------------------------------------------- Panel navigation -------------------------------------------------------------------
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
            this.animalTrivia = data.species;
            this.animalListGameList = data.animals;
        }

        public void SaveData(GameData data)
        {
            data.species = this.animalTrivia;
            data.animals = this.animalListGameList;
        }
    }
}
