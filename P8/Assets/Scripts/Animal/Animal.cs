using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Animal : MonoBehaviour
{
    public string name;
    public string species;
    public string type;
    public float speed; 

    public Animal(string name, string species, string type, float speed)
    {
        this.name = name; 
        this.species = species;
        this.type = type;
    }

    public string GetName()
    {
        return name;
    }
    public void SetName(string newName)
    {
        name = newName;   
    }
  
    public string GetSpicies()
    {
        return species;
    }
    public void SetSpecies(string newSpecies)
    {
        species = newSpecies;
    }
    
    public new string GetType()
    {
        return type;
    }
    public void SetType(string newType)
    {
        type = newType;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed; 
    }

     public abstract void Move(); 

}
