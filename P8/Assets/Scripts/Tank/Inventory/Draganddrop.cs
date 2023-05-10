using System.Collections.Generic;
using Animals;
using DataPersistence;
using DataStore;
using Tank;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ComponentScripts {
    public class Draganddrop : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler, IDropHandler, IDataPersistence {
        public int fishId;
        private Draganddrop dragedItem;
        // AnimalId animalId;
        private List<Animal> animals = new List<Animal>();
        private GameObject fishTemp;
        private GameObject canvas;
        private Vector3 fishSize;

        private void Awake() {
            fishTemp = new GameObject("FishDrag");
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
            // animalId = gameObject.GetComponent<AnimalId>();
            DataPersistenceManager hej = DataPersistenceManager.Instance;
            hej.manualLoadData();
            foreach (var animal in animals) {
                if (animal.id == fishId) {
                    animal.isDisplayed = !animal.isDisplayed;
                    canvas = GameObject.Find("TankCanvas");
                    GameObject newAnimal = Instantiate(fishTemp, canvas.transform);
                    DisplayAnimal animalScript = newAnimal.AddComponent<DisplayAnimal>();
                    animalScript.newAnimal = newAnimal;
                    animalScript.animal = animal;
                }
            }
            Destroy(gameObject);
        }

        public void LoadData(GameData data) {
            this.animals = data.animals;
        }

        public void SaveData(GameData data) {
            data.animals = this.animals;
        }
    }
}
