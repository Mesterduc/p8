using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{

    [SerializeField] GameObject[] foodPrefab;
    [SerializeField] float minX; //min x koordinat
    [SerializeField] float MaxX; //max x koordinat

    int foodspawn = 3;
    
    public int currentFood = 0;

    int maxfood = 30;

    //public void Update()
    //{
    //    GameObject.FindGameObjectsWithTag("Food");
    //    Debug.Log(gos.Length);
    //}

    //public void Awake()
    //{
    //    gos = new GameObject[32];
    //}

    public void FoodSpawn() //Spawner mad
    {
        if (GameObject.FindGameObjectsWithTag("Food").Length < 30)
        {
            for (int i = 0; i < foodspawn; i++)
            {
                var xPos = Random.Range(minX, MaxX); //giver et tilfældigt x koordinat mellem de to givede kordinater (gives i unity)
                var position = new Vector3(xPos, transform.position.y); //giver først xPos og derfter tager den det y pos some "Food" objectet har. Altså der hvor de bliver spawnet
                GameObject foodObj = Instantiate(foodPrefab[Random.Range(0, foodPrefab.Length)], position, Quaternion.Euler(Random.Range(0f, 0f), Random.Range(0f, 0f), Random.Range(0f, 360f))); //Geneerer et FoodObjekt fra en af de forskellige foodPrefabs på position(giver ovenfor) med mulighed for en 360 rotation på z aksen  (så det kun er 2d)
                currentFood++;                                                                                                                                                                                 //
            }
        }
    }
}