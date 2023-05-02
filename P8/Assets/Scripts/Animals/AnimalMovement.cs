using System;
using DataPersistence;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Animals {
    public class AnimalMovement : MonoBehaviour, IDataPersistence {
        public Animal animal;
        public float speed = 20;
        public float range = 10;
        public float maxDistance;
        public SpriteRenderer fishSprite;
        public Vector2 waypoint;

        private void Awake() {
            fishSprite = GetComponent<SpriteRenderer>();
        }

        void Start() {
            speed = animal.GetMovement().speed;
            maxDistance = animal.GetMovement().maxDistance;
            range = animal.GetMovement().range;
            FlipSprite();
        }

        void Update() {
            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoint) < range) {
                // waypoint = new Vector2(Random.Range(-maxDistance.x, maxDistance.x),
                //     Random.Range(-maxDistance.y, maxDistance.y));
                FlipSprite();
            }
        }

        void OnCollisionEnter2D(Collision2D collision) {
            if (!collision.gameObject.CompareTag("Fish")) {
                waypoint = new Vector2(0, 0);
                // FlipSprite();
                Vector2 direction = waypoint - (Vector2)transform.position;
                if (direction.x < 0) {
                    fishSprite.flipX = true;
                }
                else if (direction.x >= 0) {
                    fishSprite.flipX = false;
                }
            }
        }

        private void FlipSprite() {
            waypoint = new Vector2(Random.Range(-maxDistance, maxDistance),
                Random.Range(-maxDistance, maxDistance));
            Vector2 direction = waypoint - (Vector2)transform.position;
            if (direction.x < 0) {
                fishSprite.flipX = true;
            }
            else if (direction.x >= 0) {
                fishSprite.flipX = false;
            }
        }

        public void LoadData(GameData data) {
        }

        public void SaveData(GameData data) {
            // Animal findAnimal = data.animals.Find(x => x.id == this.animal.id);
            // Debug.Log(findAnimal);
            // findAnimal.movement.currentPosition = waypoint;
        }
    }
}