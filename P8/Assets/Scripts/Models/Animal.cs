using System.Collections;
using System.Collections.Generic;
using Animals;
using magnus.johnson;
using Models;
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
        public Journey journey;
        private string realLifeImage; //: har vi ikke med endnu: image of caught animal
        
        public Animal(int id, string name, string animated, string animation, AnimalSize animalSize, FishTrivia species, Journey journey) {
            this.id = id;
            this.name = name;
            this.animated = animated;
            this.animation = animation;
            this.isDisplayed = true;
            this.animalSize = animalSize;
            this.movement = new Movement(150, 20, 400);
            this.species = species;
            this.journey = journey;
        }

        public string getRealImage() {
            return realLifeImage;
        }

        public void setRealImage(string pathToImage) {
            this.realLifeImage = pathToImage;
        }
        
    }
}