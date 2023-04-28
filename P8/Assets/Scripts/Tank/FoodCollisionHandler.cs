using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollisionHandler : MonoBehaviour
{
public float lifeTime = 40f;

void Awake() 
    { 
        Destroy (gameObject, lifeTime); 
    }
void OnTriggerEnter2D(Collider2D other)
    {
        Destroy (gameObject); 
    }
} 

