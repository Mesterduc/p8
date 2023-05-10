using System;
using System.Collections.Generic;
using Animals;
using DataPersistence;
using DataStore;
using UnityEngine;

namespace Tank
{
    public class TankScript : MonoBehaviour, IDataPersistence
    {
        private List<Animal> animals = new List<Animal>();
        [SerializeField] private Transform placement;
        private GameObject fishTemp;
        private Vector3 fishSize;
        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
            fishTemp = new GameObject("Fish");
        }

        void Start() {
            foreach (var animal in animals) {
                // only instantiate animals where property isDisplayed is set to true
                if (animal.isDisplayed) {
                    GameObject newAnimal = Instantiate(fishTemp, placement);
                    DisplayAnimal animalScript = newAnimal.AddComponent<DisplayAnimal>();
                    animalScript.newAnimal = newAnimal;
                    animalScript.animal = animal;
                }
            }
        }
        // TODO: Husk position

        public void LoadData(GameData data)
        {
            this.animals = data.animals;
        }

        public void SaveData(GameData data)
        {
            data.animals = this.animals;
        }
    }
}