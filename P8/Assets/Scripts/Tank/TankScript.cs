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
        private List<Fish> fishes = new List<Fish>();
        [SerializeField] private Transform placement;

        private GameObject newFish;
        private List<GameObject> fishObjects = new List<GameObject>();
        
        public float speed = 20;
        public float range = 100;
        public float maxDistance = 1000;
        public Vector2 waypoint;
        private SpriteRenderer sp;

        private void Awake() {
            newFish = new GameObject("Fish");
        }

        void Start()
        {
            waypoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
            for (int i = 0; i < fishes.Count; i++)
            {
                // GameObject parent = Instantiate(new GameObject(), placement);
                // parent.name = "parent";
                
                // GameObject newFish = Instantiate(new GameObject(), parent.transform, true);
                Instantiate(newFish);
                // newFish.name = "Fish";
                newFish.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Fish/" + "Sild");
                sp = newFish.GetComponent<SpriteRenderer>();
                newFish.GetComponent<SpriteRenderer>().sortingLayerName = "foreground";
                newFish.transform.localScale = new Vector3(10, 10, 1); 
                newFish.transform.position = new Vector3(0, 0, 0);
                newFish.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Fish/SildAnimator");
                fishObjects.Add(newFish);
                // fishObjects.Add(parent);
            }
        }

        private void Update() {
            for (int i = 0; i < fishObjects.Count; i++) {
                fishObjects[i].transform.position = Vector2.MoveTowards(fishObjects[i].transform.position,waypoint, speed * Time.deltaTime);
                if (Vector2.Distance(fishObjects[i].transform.position,waypoint) < range)
                {
                    setNewDestination(fishObjects[i]); 
                }
            }
        }
        
        public void setNewDestination(GameObject fish)
        {
            waypoint = new Vector2(Random.Range(-maxDistance, maxDistance),Random.Range (-maxDistance, maxDistance));
            
            Vector2 direction = waypoint - (Vector2)transform.position;
            if (direction.x < 0)
            {
                 sp.flipX = true;
            }
            else if (direction.x >= 0)
            {
                sp.flipX = false; 
            }
        }

        public void LoadData(GameData data)
        {
            this.fishes = data.fishes;
        }

        public void SaveData(GameData data)
        {
            data.fishes = this.fishes;
        }
    }
}