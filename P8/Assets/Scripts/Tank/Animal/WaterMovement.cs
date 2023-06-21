using System;
using Animals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tank {
    public class WaterMovement : StrategyMovement {
        public void Movement(GameObject animal, Vector2 waypoint, float speed) {
            animal.transform.position = Vector2.MoveTowards(animal.transform.position, waypoint, speed * Time.deltaTime);
        }
    }
}