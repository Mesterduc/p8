using UnityEngine;

namespace Tank {
    public interface StrategyMovement {
        void Movement(GameObject animal, Vector2 waypoint, float speed);
        
    }
}