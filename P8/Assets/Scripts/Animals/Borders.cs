using UnityEngine;

namespace Animals {
    public class Borders : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Collider2D collider = GetComponent<Collider2D>();
            Bounds bounds = collider.bounds;
            Transform objTransform = collision.gameObject.transform; 
            Vector3 objPosition = objTransform.position;

            float x = Mathf.Clamp(objPosition.x, bounds.min.x, bounds.max.x);
            float y = Mathf.Clamp(objPosition.y, bounds.min.y, bounds.max.y);

            objTransform.position = new Vector3(x, y, objPosition.z);
   
            GameObject Salmon = collision.gameObject;
            // Swim swim = Salmon.GetComponent<Swim>();
            // swim.setNewDestination(); 
            Debug.Log("Collided with " + collision.gameObject.name);
        }
    }
}
