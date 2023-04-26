using System;
using UnityEditor.UIElements;
using UnityEngine;

namespace Animals {
    public class Movement {
        public float speed = 1;
        public float range = 1;
        public float maxDistance = 100;
        // SpriteRenderer fish;
        public Vector2 currentPosition;
        // public Vector2 waypoint;

        public Movement(float speed, float range, float maxDistance, Vector2 currentPosition) {
            this.speed = speed;
            this.range = range;
            this.maxDistance = maxDistance;
            this.currentPosition = currentPosition;
            // this.waypoint = waypoint;
        }
    }
    
}