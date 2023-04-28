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
        public List<FishTrivia> animalpictures = new List<FishTrivia>();

        //Magnus datamodel
        public List<Destination> destinations = new List<Destination>();


        public GameData()
        {
            PreLoad();
        }

        // loader vores program med nogen standard data
        private void PreLoad()
        {
            this.playerData = new PlayerData("halla halla");

            this._name = "Ole";

            friends.Add(new Friend("Johnson", 10, 4, "pedro"));
            friends.Add(new Friend("Jax", 99, 99, "sifos"));
            friends.Add(new Friend("Yuli", 490, 13, "yuli"));
            friends.Add(new Friend("Sifos", 490, 13, "sifos"));
            // friends.Add(new Friend("Sune", 490, 13, "pedro"));

            // Magnus' forsøg på at loade menu

            Vector2 position = new Vector2(3, 3);

            Activity fang_krabber = new Activity("Krabbejagt", "Find en tøjklemme og en snor. Put en blåmusling på tøjklemmen og sænk den ned i vandet. Så er der krabber!");
            Activity fang_fisk = new Activity("Fisketur", "Anskaf dig en fiskestang og se en video");
            Activity fang_myg = new Activity("Myggejagt", "Der er myg over det hele, bare vent og se");
            Activity fang_rejer = new Activity("Reje-Bonanza", "Du kan praktisk talt ikke undgå at fange en reje hvis du har et rejenet");
            Activity fang_edderkopper = new Activity("Edderkoppe-Eventyr", "Find et edderkoppenet. Find en flue. Put en flue i nettet. WIN!");

            List<Activity> hede_aktiviteter = new List<Activity>();
            hede_aktiviteter.Add(fang_edderkopper);
            hede_aktiviteter.Add(fang_myg);
            List<FishTrivia> hede_dyr = new List<FishTrivia>();

            List<Activity> strand_aktiviteter = new List<Activity>();
            strand_aktiviteter.Add(fang_fisk);
            strand_aktiviteter.Add(fang_rejer);
            strand_aktiviteter.Add(fang_krabber);
            List<FishTrivia> strand_dyr = new List<FishTrivia>();

            List<Activity> havn_aktiviteter = new List<Activity>();
            havn_aktiviteter.Add(fang_fisk);
            havn_aktiviteter.Add(fang_krabber);
            List<FishTrivia> havn_dyr = new List<FishTrivia>();

            List<Activity> skov_aktiviteter = new List<Activity>();
            skov_aktiviteter.Add(fang_edderkopper);
            skov_aktiviteter.Add(fang_myg);
            List<FishTrivia> skov_dyr = new List<FishTrivia>();

            FishTrivia krabbe = new FishTrivia("Krabbe", "Fish/Trout", fang_krabber, "Kød", "Almindelig", "Krabben er fandeme over det hele man");
            FishTrivia laks = new FishTrivia("Laks", "laksebillede", fang_fisk, "Andre fisk", "Sjælden", "Laks finder du aldrig min dud");
            FishTrivia fladfisk = new FishTrivia("Fladfisk", "fladfiskebillede", fang_fisk, "Rejer, muslinger", "Almindelig", "Fladfisken er svær at finde (fordi den er flad)");
            FishTrivia reje = new FishTrivia("Reje", "rejebillede", fang_rejer, "plankton", "Almindelig", "Du kan næsten ikke undgå at finde rejer");
            FishTrivia myg = new FishTrivia("Myg", "myggebillede", fang_myg, "BLOD!", "Almindelig", "AV AV du blev stukket af en myg");
            FishTrivia edderkop = new FishTrivia("Edderkop", "edderkoppebillede", fang_edderkopper, "Insekter", "Almindelig", "8 ben og lige så mange problemer i livet");

            hede_dyr.Add(myg);
            hede_dyr.Add(edderkop);

            strand_dyr.Add(krabbe);
            strand_dyr.Add(laks);
            strand_dyr.Add(fladfisk);
            strand_dyr.Add(reje);

            havn_dyr.Add(krabbe);
            havn_dyr.Add(laks);
            havn_dyr.Add(fladfisk);

            skov_dyr.Add(myg);
            skov_dyr.Add(edderkop);


            Biome strand = new Biome("Strand", strand_aktiviteter, strand_dyr);
            Biome havn = new Biome("Havn", havn_aktiviteter, havn_dyr);
            Biome skov = new Biome("Skov", skov_aktiviteter, skov_dyr);
            Biome hede = new Biome("Hede", hede_aktiviteter, hede_dyr);

            Destination dall_hede = new Destination("Dall Hede", "Dall hede er et sted man kan slappe af om sommeren.", hede, position);
            Destination rold_skov = new Destination("Rold Skov", "Rold skov er fandeme ikke et sted du skal slappe for meget af", skov, position);
            Destination aalborghavn = new Destination("Aalborg Havn", "Her kan du altid finde en ødelagt flaske eller to", havn, position);
            Destination oest_stranden = new Destination("Øst-stranden", "Ved en strand er der sand. Og ved sand er der vand.", strand, position);

            destinations.Add(dall_hede);
            destinations.Add(rold_skov);
            destinations.Add(aalborghavn);
            destinations.Add(oest_stranden);

            
            Movement move = new Movement(30, 1, 100, new Vector2(0, 0));
            animals.Add(new Animal(1,"Predo", "Fish/Sild", "Fish/SildAnimator", true, AnimalSize.large, move, krabbe ));
            animals.Add(new Animal(2,"Predo2", "Fish/Sild", "Fish/SildAnimator", true, AnimalSize.Small, move, krabbe));
            // fishes.Add(new Fish("Predo3", "Sild", "Water animal", 2, "asd", AnimalSize.large, "wwq", false));

            animalpictures.Add(krabbe);
            animalpictures.Add(laks);
            animalpictures.Add(fladfisk);

        }
    }
}























