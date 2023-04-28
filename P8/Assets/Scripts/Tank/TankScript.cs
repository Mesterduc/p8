using System;
using System.Collections.Generic;
using Animals;
using DataPersistence;
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
            fishTemp = new GameObject("Fish");
        }

        void Start() {
            foreach (var animal in animals) {
                    GameObject newFish = Instantiate(fishTemp, placement);
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
                    
                    MovementTest move = newFish.AddComponent<MovementTest>();
                    move.animal = animal;
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