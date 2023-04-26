using System.Collections;
using System;
using System.Collections.Generic;
using Animals;
using UnityEngine;


namespace DataPersistence
{
    // Place data here 
    [System.Serializable]
    public class GameData
    {
        public PlayerData playerData;
        public string _name;
        public List<Friend> friends = new List<Friend>();
        public List<Animal> animals = new List<Animal>();

        //Magnus datamodel
        public List<Destination> strande = new List<Destination>();


        public GameData()
        {
            PreLoad();
        }

        // loader vores program med nogen standard data
        private void PreLoad()
        {
            this.playerData = new PlayerData("halla halla");

            this._name = "Ole";

            friends.Add(new Friend("Predo", 10, 4, "pedro"));
            friends.Add(new Friend("Jax", 99, 99, "sifos"));
            friends.Add(new Friend("Yuli", 490, 13, "yuli"));
            friends.Add(new Friend("Sifos", 490, 13, "sifos"));
            // friends.Add(new Friend("Sune", 490, 13, "pedro"));

            // fishes.Add(new Fish("Predo", "Sild", "Water animal", 2, "asd", FishSize.large, "wwq", false));
            // fishes.Add(new Fish("Predo2", "Sild", "Water animal", 2, "asd", FishSize.large, "wwq", false));
            // fishes.Add(new Fish("Predo3", "Sild", "Water animal", 2, "asd", FishSize.large, "wwq", false));



            // Magnus' forsøg på at loade menu
            Activity fang_krabber = new Activity("Krabbejagt", "Lav et net og gå i gang");
            FishTrivia krabbe = new FishTrivia("Krabbe", "krabbebillede", fang_krabber, "Kød", "Almindelig", "Krabben er fandeme over det hele man");
            Biome strand = new Biome("Stranden", fang_krabber, krabbe);
            Destination ballehage = new Destination("Ballehage", "Ballehage er et super sted at være om sommeren", strand);

            strande.Add(ballehage);
            strande.Add(new Destination("Johnson", "Johnson er et super sted at være om sommeren", strand));

            Movement move = new Movement(30, 1, 100, new Vector2(0, 0));
            Movement move = new Movement(30, 1, 100);
            Movement move = new Movement(30, 1, 100, new Vector2(0, 0));
            animals.Add(new Animal(1,"Predo", "Fish/Sild", "Fish/SildAnimator", true, AnimalSize.large, move ));
            animals.Add(new Animal(2,"Predo2", "Fish/Sild", "Fish/SildAnimator", true, AnimalSize.Small, move));
            // fishes.Add(new Fish("Predo3", "Sild", "Water animal", 2, "asd", AnimalSize.large, "wwq", false));
        }
    }
}























