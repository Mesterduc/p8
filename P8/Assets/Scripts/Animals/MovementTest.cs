using System;
using DataPersistence;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Animals {
    public class MovementTest : MonoBehaviour {
        // public Animal animal;
        public float speed = 20;
        public float range = 10;
        public float maxDistance = 100;
        public SpriteRenderer fish;
        public Vector2 waypoint;
        // public Vector2 currentPosition;

        // private void Awake() {
        //     speed = animal.movement.speed;
        //     maxDistance = animal.movement.maxDistance;
        //     range = animal.movement.range;
        //     currentPosition = animal.movement.currentPosition;
        // }
        void Start()
         {
             setNewDestination();
         }
        
         void Update()
         {
             transform.position = Vector2.MoveTowards(transform.position,waypoint, speed * Time.deltaTime);
             if (Vector2.Distance(transform.position,waypoint) < range)
             {
                 setNewDestination(); 
             }
         }
         
        
        public void setNewDestination()
         {
            waypoint = new Vector2(Random.Range(-maxDistance, maxDistance),Random.Range (-maxDistance, maxDistance));
        
          Vector2 direction = waypoint - (Vector2)transform.position;
          if (direction.x < 0)
            {
             fish.flipX = true;
            }
            else if (direction.x >= 0)
            {
             fish.flipX = false; 
            }
         }

        // public void LoadData(GameData data) {
        //     
        // }
        //
        // public void SaveData(GameData data) {
        //     data.animals.Find(animal => animal.id == this.animal.id);
        // }
    }
}