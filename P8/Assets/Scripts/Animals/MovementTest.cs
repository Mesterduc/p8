using System;
using DataPersistence;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Animals {
    public class MovementTest : MonoBehaviour, IDataPersistence {
        public Animal animal;
        public float speed = 20;
        public float range = 10;
        public float maxDistance = 100;
        public SpriteRenderer fishSprite;
        public Vector2 waypoint;
        private Rigidbody2D hej;

        private void Awake() {
            // throw new NotImplementedException();
            fishSprite = GetComponent<SpriteRenderer>();
        }

        void Start() {
            speed = animal.movement.speed;
            maxDistance = animal.movement.maxDistance;
            range = animal.movement.range;
            FlipSprite();
            hej = GetComponent<Rigidbody2D>();
        }

        void Update() {
            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoint) < range) {
                waypoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
                FlipSprite();
            }
        }

        void OnCollisionEnter2D(Collision2D collision) {
            Debug.Log("fish");
            if (!collision.gameObject.CompareTag("Fish")) {
                Debug.Log("wall");
                waypoint = new Vector2(0, 0);
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
            Animal findAnimal = data.animals.Find(x => x.id == this.animal.id);
            Debug.Log(findAnimal);
            findAnimal.movement.currentPosition = waypoint;
        }
    }
}