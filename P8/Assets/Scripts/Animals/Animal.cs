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

namespace Animals {
    [System.Serializable]
    public class Animal {
        public int id;
        public string name;
        public string animated;// animal image
        public string animation; // animal animation
        public bool isDisplayed; // synlighed i inventory
        public Movement movement;
        public AnimalSize animalSize;
        public FishTrivia species;
        
        // public string realLifeImage { get; set; } : har vi ikke med endnu: image of caught animal
        public Animal(int id, string name, string animated, string animation, bool isDisplayed, AnimalSize animalSize, Movement movement, FishTrivia species) {
            this.id = id;
            this.name = name;
            this.animated = animated;
            this.animation = animation;
            this.isDisplayed = isDisplayed;
            this.animalSize = animalSize;
            this.movement = movement;
            this.species = species;
            // this.type = type;
            // this.realLifeImage = realLifeImage;

        }
    }
}