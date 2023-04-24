using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishSize
{
    Small,
    medium,
    large
}

public abstract class Animal
{
    public string name { get; set; }
    public string species { get; set; }
    // land eller vand type osv.
    public string type { get; set; }
    public float speed { get; set; }
    // animal image
    public string animated { get; set; }
    public FishSize fishSize { get; set; }
    // image of caught gish
    public string realLifeImage { get; set; }
    public bool isDisplayed { get; set; }


    protected Animal(string name, string species, string type, float speed, string animated, FishSize fishSize, string realLifeImage, bool isDisplayed)
    {
        this.name = name;
        this.species = species;
        this.type = type;
        this.speed = speed;
        this.animated = animated;
        this.fishSize = fishSize;
        this.realLifeImage = realLifeImage;
        this.isDisplayed = isDisplayed;
    }

    public abstract void Move();

}