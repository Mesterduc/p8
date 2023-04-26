using DataPersistence;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Animals 
{
    public class MovementTest : MonoBehaviour, IDataPersistence {
        public Animal animal;
        public float speed = 20;
        public float range = 10;
        public float maxDistance = 100;
        public SpriteRenderer fishSprite;
        public Vector2 waypoint;

        void Start()
         {
            speed = animal.movement.speed;
            maxDistance = animal.movement.maxDistance;
            range = animal.movement.range;
            fishSprite = GetComponent<SpriteRenderer>();
            setNewDestination();
         }
        
         void Update()
         {
             transform.position = Vector2.MoveTowards(transform.position,waypoint, speed * Time.deltaTime);
             if (Vector2.Distance(transform.position,waypoint) < range)
             {
                 setNewDestination(); 
             }
         }
         
        
        public void setNewDestination()
         {
            waypoint = new Vector2(Random.Range(-maxDistance, maxDistance),Random.Range (-maxDistance, maxDistance));
        
          Vector2 direction = waypoint - (Vector2)transform.position;
          if (direction.x < 0)
            {
                fishSprite.flipX = true;
            }
            else if (direction.x >= 0)
            {
                fishSprite.flipX = false; 
            }
         }

        public void LoadData(GameData data) {
            Debug.Log("anni load");
            
        }
        
        public void SaveData(GameData data) {
            Animal findAnimal = data.animals.Find(x => x.id == this.animal.id);
            Debug.Log(findAnimal);
            Debug.Log("anni");
             findAnimal.movement.currentPosition = new Vector2(100,100);
            data._name = "mad";

        }
    }
}