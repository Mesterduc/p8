using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollisionHandler : MonoBehaviour
{
public float lifeTime = 40f; //Leve tid på maden

void Awake() //sletter mad efter lifeTime
    { 
        Destroy (gameObject, lifeTime); 
    }

    //Når object rammer noget med "OnTrigger" så sletter den objektet
void OnTriggerEnter2D(Collider2D other)
    {
        Destroy (gameObject); 
    }
} 

