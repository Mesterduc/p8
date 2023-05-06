using Animals;
using DataPersistence;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tank {
    public class AnimalMovement : MonoBehaviour, IDataPersistence {
        public Animal animal;
        public float speed = 20;
        public float range = 10;
        public float maxDistance;
        public SpriteRenderer fishSprite;
        public Vector2 waypoint;
        private Collider2D animalClicked;

        private void Awake() {
            animalClicked = GetComponent<Collider2D>();
            fishSprite = GetComponent<SpriteRenderer>();
        }

        void Start() {
            speed = animal.movement.speed;
            maxDistance = animal.movement.maxDistance;
            range = animal.movement.range;
            FlipSprite();
        }

        void Update() {
            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoint) < range) {
                // waypoint = new Vector2(Random.Range(-maxDistance.x, maxDistance.x),
                //     Random.Range(-maxDistance.y, maxDistance.y));
                FlipSprite();
            }

            if (Input.GetMouseButtonDown(0)) {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (animalClicked.OverlapPoint(mousePosition)) {
                    Debug.Log("Click");
                    if (speed != 0) {
                        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                        speed = 0;
                    }
                    else {
                        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        speed = 150;
                    }

                }
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