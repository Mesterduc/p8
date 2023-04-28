using System;
using UnityEditor.UIElements;
using UnityEngine;

namespace Animals {
    [System.Serializable]
    public class Movement {
        public float speed = 1;
        public float range = 1;
        public Vector2 maxDistance;
        public Vector2 currentPosition;
        // public Vector2 waypoint;

        public Movement(float speed, float range, Vector2 maxDistance) {
            this.speed = speed;
            this.range = range;
            this.maxDistance = maxDistance;
            this.currentPosition = new Vector2(0,0);
            // this.waypoint = waypoint;
        }
    }
    
}