using ComponentScripts;
using DataPersistence;
using DataStore;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tank.InventoryTank {
    public class TankInventory : MonoBehaviour, IDataPersistence {
        private GameData gameData;
        public Inventory inventory;
        public GameObject scrollContent;

        void Start() {
            foreach (var item in inventory.GetInventory()) {
                if (!item.isDisplayed) {
                    GameObject prefab = Resources.Load<GameObject>("prefabs/itemPrefab");
                    GameObject newAnimal = Instantiate(prefab, scrollContent.transform);
                    newAnimal.transform.Find("image").GetComponent<Image>().sprite = Resources.Load<Sprite>(item.species.animated);
                    newAnimal.transform.Find("name").GetComponent<TMP_Text>().text = item.name;
                    Draganddrop dragAndDropScript = newAnimal.AddComponent<Draganddrop>();
                    dragAndDropScript.animalId = item.id;
                }
            }
        }

        public void LoadData(GameData data) {
            this.inventory = data.inventory;
        }

        public void SaveData(GameData data) {
            data.inventory = this.inventory;
        }
    }
}