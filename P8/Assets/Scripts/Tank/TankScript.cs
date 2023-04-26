using System;
using System.Collections.Generic;
using Animals;
using DataPersistence;
using JetBrains.Annotations;
using Navigation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
                    // sp = newFish.GetComponent<SpriteRenderer>();
                    newFish.GetComponent<SpriteRenderer>().sortingLayerName = "foreground";
                    // ændre størrelse
                    newFish.transform.localScale = new Vector3(10, 10, 1);
                    newFish.transform.position = new Vector3(0,0);   // start position
                    newFish.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animal.animation);// animation
                    
                    // script
                    MovementTest move = newFish.AddComponent<MovementTest>();
                    move.speed = animal.movement.speed;
                    move.maxDistance = animal.movement.maxDistance;
                    move.range = animal.movement.range;
                    // move.currentPosition = animal.movement.currentPosition;
                    move.fish = newFish.GetComponent<SpriteRenderer>();
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