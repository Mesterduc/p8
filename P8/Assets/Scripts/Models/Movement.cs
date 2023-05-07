using System;
using UnityEngine;

namespace Animals {
    [System.Serializable]
    public class Movement {
        public float speed;
        public float range;
        public float maxDistance;
        // SpriteRenderer fish;
        public Vector3 currentPosition;
        // public Vector2 waypoint;

        public Movement(float speed, float range, float maxDistance) {
            this.speed = speed;
            this.range = range;
            this.maxDistance = maxDistance;
            this.currentPosition = new Vector3(0,0, 1);
            // this.waypoint = waypoint;
        }
    }
    
}