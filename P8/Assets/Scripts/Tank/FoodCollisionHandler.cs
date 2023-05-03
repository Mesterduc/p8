using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class FoodCollisionHandler : MonoBehaviour
{
    public FoodScript foodScript;
    

    public int lifeTime = 3; //Leve tid på maden

    //void Start()
    //{
    //    GameObject food = GameObject.Find("Food");
    //    FoodScript script = food.GetComponent<FoodScript>();
    //}

    void Awake() //sletter mad efter lifeTime
    {
        Destroy(gameObject, lifeTime);
    }

    //Når object rammer noget med "OnTrigger" så sletter den objektet
void OnTriggerEnter2D(Collider2D other)
    {
        Destroy (gameObject);
    }
} 

