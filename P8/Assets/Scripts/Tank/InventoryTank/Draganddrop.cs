using System.Collections.Generic;
using Animals;
using DataPersistence;
using DataStore;
using Models;
using Tank;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ComponentScripts {
    public class Draganddrop : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler, IDropHandler, IDataPersistence {
        public int animalId;
        private Draganddrop dragedItem;
        private Inventory inventory;
        private GameObject canvas;
        private Vector3 fishSize;

        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
        }
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnDrop(PointerEventData eventData)
        {
            // GameObject dropped = eventData.pointerDrag;
            // dragedItem = dropped.GetComponent<Draganddrop>();
            // dragedItem.parentAfterDrag = transform;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            foreach (Animal item in inventory.GetInventory()) {
                if (item.id == animalId) {
                    item.isDisplayed = !item.isDisplayed;
                    canvas = GameObject.Find("TankCanvas").transform.Find("Grid").gameObject;
                    GameObject newAnimal = Instantiate(new GameObject("FishDrag"), canvas.transform);
                    DisplayAnimal animalScript = newAnimal.AddComponent<DisplayAnimal>();
                    animalScript.animal = item;
                }
            }
            Destroy(gameObject);
        }

        public void LoadData(GameData data) {
            this.inventory = data.inventory;
        }

        public void SaveData(GameData data) {
            data.inventory = this.inventory;
        }
    }
}
