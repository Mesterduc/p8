using UnityEngine;

namespace Tank {
    public class FastMovement : StrategyMovement {
        public void Movement(GameObject animal, Vector2 waypoint, float speed) {
            animal.transform.position = Vector2.MoveTowards(animal.transform.position, waypoint, speed * Time.deltaTime * 3);
        }
    }
}