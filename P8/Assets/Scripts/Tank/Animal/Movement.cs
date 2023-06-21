using System;
using Animals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tank {
    public class Movement : MonoBehaviour {
        public Animal animal;
        // public float speed = 20;
        public float range = 10;
        public float maxDistance;
        private Vector2 waypoint;
        public SpriteRenderer fishSprite;
        public StrategyMovement animalMovement;

        private void Awake() {
            fishSprite = GetComponent<SpriteRenderer>();
        }

        void Start() {
            // speed = animal.movement.speed;
            maxDistance = animal.movement.maxDistance;
            range = animal.movement.range;
            
            FlipSprite();
        }

        private void Update() {
            animalMovement.Movement(this.gameObject, waypoint, animal.movement.speed);
            if (Vector2.Distance(transform.position, waypoint) < range) {
                FlipSprite();
            }
        }
        
        // hvis animal rammer en anden collider calles denner her: giver bare et nyt waypoint
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

        public void FlipSprite() {
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
    }
}