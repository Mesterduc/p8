using System.Collections;
using System.Collections.Generic;
using Animals;
using UnityEngine;

public enum AnimalSize
{
    Small,
    medium,
    large
}
public class Animal
{
    public int id { get; set; }
    public string name { get; set; }
    public string animated { get; set; } // animal image
    public string animation { get; set; } // animal image
    public bool isDisplayed { get; set; } // synlighed i inventory
    public Movement movement;
    public AnimalSize animalSize { get; set; }
    // public string species { get; set; } : ny class? colletion?
    // public string type { get; set; } : land eller vand type osv.
    // har vi ikke med endnu: image of caught animal
    // public string realLifeImage { get; set; }
    public Animal(int id, string name, string animated, string animation, bool isDisplayed, AnimalSize animalSize, Movement movement) {
        this.id = id;
        this.name = name;
        this.animated = animated;
        this.animation = animation;
        this.isDisplayed = isDisplayed;
        this.animalSize = animalSize;
        this.movement = movement;
        // this.species = new species();
        // this.type = type;
        // this.realLifeImage = realLifeImage;

    }
}