using UnityEngine;

namespace Tank.Food {
    public class FoodScript : MonoBehaviour
    {
        [SerializeField] GameObject[] foodPrefab;
        [SerializeField] float minX; //min x koordinat
        [SerializeField] float MaxX; //max x koordinat
        [SerializeField] GameObject placement;
        [SerializeField] Transform placement2;
    
        float lifespan = 20f;

        int foodspawn = 3;

        public void FoodSpawn() //Spawner mad
        {
            for (int i= 0; i<foodspawn; i++)
            { 
                var xPos = Random.Range(minX, MaxX); //giver et tilfældigt x koordinat mellem de to givede kordinater (gives i unity)
                var position = new Vector3(xPos, transform.position.y); //giver først xPos og derfter tager den det y pos some "Food" objectet har. Altså der hvor de bliver spawnet
                var pos2 = new Vector3(xPos, 350);
                GameObject foodObj = Instantiate(foodPrefab[Random.Range(0, foodPrefab.Length)], pos2, Quaternion.identity, placement2); //Geneerer et FoodObjekt fra en af de forskellige foodPrefabs på position(giver ovenfor) med mulighed for en 360 rotation på z aksen  (så det kun er 2d)   
                Destroy(foodObj, lifespan);
            }
        }
    }
}