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
        private Species species;
        private Inventory inventory;
        public Transform animalList;
        public GameObject objectToSpawn;
        
        // ui
        public Button forwards;
        public Button back;
        public GameObject panelSpices;
        public GameObject panelAnimalInfo;
        public GameObject specieInfoContainer;
        // create animal
        private Trivia specie;
        public Journey journey;
        public GameObject textName;
        public int size;

        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
            forwards.onClick.AddListener(ShowSpices);
            back.onClick.AddListener(ShowAnimalInfo);
        }

        void Start()
        {
            // Laver ikon til spices
            foreach (var trivia in species.GetSpecies()) {
                GameObject animalSpices = Instantiate(objectToSpawn, animalList);
                animalSpices.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(trivia.picture);
                animalSpices.transform.GetChild(1).GetComponent<TMP_Text>().text = trivia.name;
                var animal = trivia;
                animalSpices.GetComponent<Button>().onClick.AddListener(() => populateAnimalInfo(animal));
            }
            
            // hvis der findes species så tag den første i listen og fokus den
            if (species.SpeciesCount() != 0) {
                populateAnimalInfo(species.GetSpecies()[0]);
            }
        }
        
        private void populateAnimalInfo(Trivia animalSpecie) {
            specie = animalSpecie;
            specieInfoContainer.transform.Find("Title").GetComponent<TMP_Text>().text = animalSpecie.name;
            specieInfoContainer.transform.Find("Beskrivelse").GetComponent<TMP_Text>().text = animalSpecie.bio;
            specieInfoContainer.transform.Find("Images").GetComponent<Image>().sprite = Resources.Load<Sprite>(animalSpecie.realPicture);
        }

        public void AddAnimal() {
            string name = textName.transform.GetComponent<TMP_Text>().text;
            Animal animal = new Animal(this.inventory.InventoryCount() + 1, name, (AnimalSize)size, specie, Hogsmeade.animalJourneyInGallery, Hogsmeade.animalImagePath);
            animal.setRealImage(Hogsmeade.animalImagePath);
            
            inventory.AddInventory(animal);
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
            this.species = data.species;
            this.inventory = data.inventory;
        }

        public void SaveData(GameData data)
        {
            data.species = this.species;
            data.inventory = this.inventory;
        }
    }
}
