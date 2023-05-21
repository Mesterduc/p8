using System;
using System.Collections.Generic;
using Animals;
using DataPersistence;
using DataStore;
using Models;
using UnityEngine;

namespace Tank
{
    public class TankManager : MonoBehaviour, IDataPersistence
    {
        private Inventory inventory;
        [SerializeField] private Transform placement;
        private GameObject fishTemp;
        private Vector3 fishSize;
        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
            Debug.Log("awake");
            fishTemp = new GameObject("Fish");
        }

        void Start() {
            foreach (var item in inventory.GetInventory()) {
                // only instantiate animals where property isDisplayed is set to true
                if (item.isDisplayed) {
                    GameObject newAnimal = Instantiate(fishTemp, placement);
                    DisplayAnimal animalScript = newAnimal.AddComponent<DisplayAnimal>();
                    animalScript.animal = item;
                }
            }
        }
        private void OnDestroy() {
            DataPersistenceManager.Instance.SaveGame();
        }

        public void LoadData(GameData data)
        {
            this.inventory = data.inventory;
        }

        public void SaveData(GameData data)
        {
            data.inventory = this.inventory;
        }
    }
}