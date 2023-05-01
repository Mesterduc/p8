using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] GameObject[] foodPrefab;
    [SerializeField] float secondSpawn = 0.5f; //Tid der går før mad spawner (SKAL SÆTTES PÅ KNAP)
    [SerializeField] float minX; //min x koordinat
    [SerializeField] float MaxX; //max x koordinat

    public bool isEnabled = true;

    void Start()
    {
        StartCoroutine(FoodSpawn()); //Kører en Coroutine som pauses af sidste linje yield, før den kører igen
    }

    IEnumerator FoodSpawn() //Spawner mad
    {
        while (true)
        {
            if (isEnabled = true)
            {
        
                var xPos = Random.Range(minX, MaxX); //giver et tilfældigt x koordinat mellem de to givede kordinater (gives i unity)
                var position = new Vector3(xPos, transform.position.y); //giver først xPos og derfter tager den det y pos some "Food" objectet har. Altså der hvor de bliver spawnet
                GameObject foodObj = Instantiate(foodPrefab[Random.Range(0, foodPrefab.Length)], position, Quaternion.identity); //Geneerer et FoodObjekt fra en af de forskellige foodPrefabs på position(giver ovenfor) uden nogen nogen rotation
                yield return new WaitForSeconds(secondSpawn); //holder pause i "secondSpawn" lang tid
        
            }
        }   
    
    }

    public void ToggleEnable()
    {
        isEnabled = !isEnabled;
    }


}