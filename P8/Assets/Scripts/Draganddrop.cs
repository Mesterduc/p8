using System;
using System.Collections;
using System.Collections.Generic;
using Animals;
using DataPersistence;
using Tank;
using UnityEngine;
using UnityEngine.EventSystems;

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
                GameObject newFish = Instantiate(fishTemp, canvas.transform);
                newFish.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(animal.animated);
                newFish.GetComponent<SpriteRenderer>().sortingLayerName = "foreground";
                newFish.AddComponent<Rigidbody2D>();
                newFish.tag = "Fish";
                newFish.layer = 6;
                BoxCollider2D box = newFish.AddComponent<BoxCollider2D>();
                box.size = new Vector3(2, 2, 1);
                    
                switch (animal.animalSize) {
                    case AnimalSize.large:
                        fishSize = new Vector3(15 * 2, 15 * 2, 1);
                        break;
                    case AnimalSize.medium:
                        fishSize = new Vector3(15 * 1.5f, 15 * 1.5f, 1);
                        break;
                    case AnimalSize.Small:
                        fishSize = new Vector3(15, 15, 1);
                        break;
                }
                    
                newFish.transform.localScale = fishSize;
                    
                newFish.transform.position = animal.movement.currentPosition;   // start position
                newFish.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animal.animation);// animation
                    
                AnimalMovement move = newFish.AddComponent<AnimalMovement>();
                move.animal = animal;
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
