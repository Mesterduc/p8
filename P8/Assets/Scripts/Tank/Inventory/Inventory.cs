using System.Collections.Generic;
using Animals;
using ComponentScripts;
using DataPersistence;
using DataStore;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tank {
    public class Inventory : MonoBehaviour, IDataPersistence {
        private GameData gameData;
        public List<Animal> availableAnimals = new List<Animal>();
        public GameObject scrollContent;

        void Start() {
            for (int i = 0; i < availableAnimals.Count; i++) {
                if (!availableAnimals[i].isDisplayed) {
                    GameObject prefab = Resources.Load<GameObject>("prefabs/itemPrefab");
                    GameObject newAnimal = Instantiate(prefab, scrollContent.transform);
                    newAnimal.transform.Find("image").GetComponent<Image>().sprite = Resources.Load<Sprite>(availableAnimals[i].species.animated);
                    newAnimal.transform.Find("name").GetComponent<TMP_Text>().text = availableAnimals[i].name;
                    Draganddrop dragAndDropScript = newAnimal.AddComponent<Draganddrop>();
                    dragAndDropScript.fishId = availableAnimals[i].id;
                }
            }
        }

        public void LoadData(GameData data) {
            this.availableAnimals = data.animals;
        }

        public void SaveData(GameData data) {
            data.animals = this.availableAnimals;
        }
    }
}