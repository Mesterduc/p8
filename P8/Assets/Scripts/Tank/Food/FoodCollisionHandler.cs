using UnityEngine;

namespace Tank.Food {
    public class FoodCollisionHandler : MonoBehaviour
    {
        private float lifeTime = 20f; //Leve tid på maden

        void Awake() //sletter mad efter lifeTime
        { 
            Destroy (gameObject, lifeTime); 
        }

        //Når object rammer noget med "OnTrigger" så sletter den objektet
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer.Equals(6))
            {
                Destroy (gameObject);
            }
        }
    }
} 

