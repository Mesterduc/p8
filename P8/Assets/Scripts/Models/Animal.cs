using System.Collections;
using System.Collections.Generic;
using Animals;
using Models;
using Newtonsoft.Json;
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
        
        public bool isDisplayed; // synlighed i inventory
        public Movement movement;
        public AnimalSize animalSize;
        public Species species;
        public Journey journey;
        public string realLifeImage; 
        
        public Animal(int id, string name, AnimalSize animalSize, Species species, Journey journey, string realLifeImage) {
            this.id = id;
            this.name = name;
            this.isDisplayed = false;
            this.animalSize = animalSize;
            this.movement = new Movement(150, 20, 400);
            this.species = species;
            this.journey = journey;
            this.realLifeImage = realLifeImage;
        }

        public string getRealImage() {
            return realLifeImage;
        }

        public void setRealImage(string pathToImage) {
            this.realLifeImage = pathToImage;
        }
        
    }
}