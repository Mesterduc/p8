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
        private void Awake() {
            fishTemp = new GameObject("Fish");
        }

        void Start() {
            foreach (var animal in animals) {
                    GameObject newFish = Instantiate(fishTemp, placement);
                    newFish.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(animal.animated);
                    newFish.GetComponent<SpriteRenderer>().sortingLayerName = "foreground";
                    // ændre størrelse
                    newFish.transform.localScale = new Vector3(10, 10, 1);
                    newFish.transform.position = animal.movement.currentPosition;   // start position
                    newFish.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animal.animation);// animation
                    
                    // script: hvordan får jeg forskellige scripts på fisk???
                    MovementTest move = newFish.AddComponent<MovementTest>();
                    move.animal = animal;
            }
        }

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