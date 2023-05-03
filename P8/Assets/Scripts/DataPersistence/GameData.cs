using System.Collections;
using System;
using System.Collections.Generic;
using Animals;
using magnus.johnson;
using UnityEngine;


namespace DataPersistence
{
    // Place data here 
    // [System.Serializable]
    public class GameData
    {
        public PlayerData playerData;
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
            this.playerData = new PlayerData("Jeff");

            friends.Add(new Friend("Johnson", 10, 4, "pedro"));
            friends.Add(new Friend("Jax", 99, 99, "sifos"));
            friends.Add(new Friend("Yuli", 490, 13, "yuli"));
            friends.Add(new Friend("Sifos", 490, 13, "sifos"));
            // friends.Add(new Friend("Sune", 490, 13, "pedro"));

            // Magnus' forsøg på at loade menu

            Vector3 position = new Vector3(0, 0, 1);

            Activity fang_krabber = new Activity("Krabbejagt", "Find en tøjklemme og en snor. Put en blåmusling på tøjklemmen og sænk den ned i vandet. Så er der krabber!");
            Activity fang_fisk = new Activity("Fisketur", "Anskaf dig en fiskestang og se en video");
            Activity fang_insekter = new Activity("Insektjagt", "Insekter kan du fange sådan her:");
            Activity fang_edderkopper = new Activity("Edderkoppe-Eventyr", "Find et edderkoppenet. Find en flue. Put en flue i nettet. WIN!");

            List<Activity> hede_aktiviteter = new List<Activity>();
            hede_aktiviteter.Add(fang_edderkopper);
            hede_aktiviteter.Add(fang_insekter);
            List<FishTrivia> hede_dyr = new List<FishTrivia>();

            List<Activity> strand_aktiviteter = new List<Activity>();
            strand_aktiviteter.Add(fang_fisk);
            strand_aktiviteter.Add(fang_krabber);
            List<FishTrivia> strand_dyr = new List<FishTrivia>();

            List<Activity> havn_aktiviteter = new List<Activity>();
            havn_aktiviteter.Add(fang_fisk);
            havn_aktiviteter.Add(fang_krabber);
            List<FishTrivia> havn_dyr = new List<FishTrivia>();

            List<Activity> skov_aktiviteter = new List<Activity>();
            skov_aktiviteter.Add(fang_edderkopper);
            skov_aktiviteter.Add(fang_insekter);
            List<FishTrivia> skov_dyr = new List<FishTrivia>();

            FishTrivia guldsmed = new FishTrivia("Guldsmed", fang_insekter, "Andre insekter", "Sjælden", "Guldsmeden flyver tit ved ferskvandssøer");
            FishTrivia hornbille = new FishTrivia("Hornbille", fang_insekter, "Bæ", "Almindelig", "Hornbiller har horn");
            FishTrivia husedderkop = new FishTrivia("Husedderkop", fang_edderkopper, "Fluer", "Sjælden", "Husedderkoppen kan blive KÆÆÆÆMPE stor");
            FishTrivia stinkbille = new FishTrivia("Stinkbille", fang_insekter, "Kolort", "Sjælden", "Stinkbillen er kendt for at stinke");
            FishTrivia spyflue = new FishTrivia("Spyflue", fang_insekter, "Andre insekter", "Almindelig", "Jeg hader den her flue");
            FishTrivia tæge = new FishTrivia("Tæge", fang_insekter, "Andre insekter", "Almindelig", "En tæge. Ikke en flåt.");
            FishTrivia snegl = new FishTrivia("Snegl", fang_insekter, "Blade", "almindelig", "Find din snegl i din nærmeste bøgehæk");
            // FishTrivia krabbe = new FishTrivia("Krabbe", "Fish/Trout", fang_krabber, "Kød", "Almindelig", "Krabben er fandeme over det hele man");
            // FishTrivia laks = new FishTrivia("Laks", "laksebillede", fang_fisk, "Andre fisk", "Sjælden", "Laks finder du aldrig min dud");
            // FishTrivia fladfisk = new FishTrivia("Fladfisk", "fladfiskebillede", fang_fisk, "Rejer, muslinger", "Almindelig", "Fladfisken er svær at finde (fordi den er flad)");
            // FishTrivia reje = new FishTrivia("Reje", "rejebillede", fang_rejer, "plankton", "Almindelig", "Du kan næsten ikke undgå at finde rejer");
            // FishTrivia myg = new FishTrivia("Myg", "myggebillede", fang_myg, "BLOD!", "Almindelig", "AV AV du blev stukket af en myg");
            // FishTrivia edderkop = new FishTrivia("Edderkop", "edderkoppebillede", fang_edderkopper, "Insekter", "Almindelig", "8 ben og lige så mange problemer i livet");

            FishTrivia krabbe = new FishTrivia("Krabbe", fang_krabber, "Kød", "Almindelig", "Krabben er fandeme over det hele man");
            FishTrivia ørred = new FishTrivia("Ørred", fang_fisk, "Andre fisk", "Sjælden", "Ørred finder du aldrig min dud");
            FishTrivia hornfisk = new FishTrivia("Hornfisk", fang_fisk, "Andre fisk", "Almindelig", "Den er længere end turen hjem fra Roskilde");
            FishTrivia skrubbe = new FishTrivia("Skrubbe", fang_fisk, "Rejer, muslinger", "Almindelig", "Skrubben er svær at finde (fordi den er flad)");
            FishTrivia pighvar = new FishTrivia("Pighvar", fang_fisk, "Rejer, muslinger", "Sjælden", "Hans mener han er jordens bedste til at fange dem");
            FishTrivia sild = new FishTrivia("Sild", fang_fisk, "Alt", "Almindelig", "Du kan næsten ikke undgå at finde sild");
            FishTrivia torsk = new FishTrivia("Torsk", fang_fisk, "Alt", "Sjælden", "Engang var der mange torsk. Nu kan de være svære at finde");

            hede_dyr.Add(hornbille);
            hede_dyr.Add(husedderkop);
            hede_dyr.Add(stinkbille);
            hede_dyr.Add(spyflue);

            skov_dyr.Add(guldsmed);
            skov_dyr.Add(spyflue);
            skov_dyr.Add(snegl);
            skov_dyr.Add(tæge);

            strand_dyr.Add(krabbe);
            strand_dyr.Add(ørred);
            strand_dyr.Add(hornfisk);
            strand_dyr.Add(skrubbe);
            strand_dyr.Add(pighvar);

            havn_dyr.Add(torsk);
            havn_dyr.Add(sild);
            havn_dyr.Add(hornfisk);
            
            


            Biome strand = new Biome("Strand", strand_aktiviteter, strand_dyr);
            Biome havn = new Biome("Havn", havn_aktiviteter, havn_dyr);
            Biome skov = new Biome("Skov", skov_aktiviteter, skov_dyr);
            Biome hede = new Biome("Hede", hede_aktiviteter, hede_dyr);

            Destination dall_hede = new Destination("Dall Hede", "Dall hede er et sted man kan slappe af om sommeren.", hede, new Vector3(-2.288f, 4.229f, 1f));
            Destination egholm = new Destination("Egholm", "En stor mark med en masse insekter", hede, new Vector3(-2.28f, 5.497f, 1f));
            Destination rold_skov = new Destination("Rold Skov", "Rold skov er fandeme ikke et sted du skal slappe for meget af", skov, new Vector3(-1.859f, 3.659f, 1f));
            Destination aalborghavn = new Destination("Aalborg Havn", "Her kan du altid finde en ødelagt flaske eller to", havn, new Vector3(-1.533f, 5.313f, 1f));
            Destination oest_stranden = new Destination("Øst-stranden", "Ved en strand er der sand. Og ved sand er der vand.", strand, new Vector3(-0.325f, 4.3679f, 1f));
            Destination limfjorden = new Destination("Østersstranden", "Jeg fandt den her strand da jeg kiggede på ugler", strand, new Vector3(-4.799f, 3.678f, 1f));
            Destination nibehavn = new Destination("Nibe Havn", "Jeg fandt den her strand da jeg kiggede på ugler", havn, new Vector3(-2.438f, 4.995f, 1f));
            Destination løgstør = new Destination("Løgstør Havn", "Jeg fandt den her strand da jeg kiggede på ugler", havn, new Vector3(-3.778f, 4.612f, 1f));
            Destination trend = new Destination("Trend Havn", "Jeg fandt den her strand da jeg kiggede på ugler", havn, new Vector3(-3.919f, 4.126f, 1f));
            Destination hals = new Destination("Hals Havn", "Jeg fandt den her strand da jeg kiggede på ugler", havn, new Vector3(-0.598f, 4.873f, 1f));
            Destination lundby = new Destination("Lundby Krat", "Lundby krat er et fedt sted", skov, new Vector3(-1.146f, 4.412f, 1f));

            destinations.Add(dall_hede);
            destinations.Add(rold_skov);
            destinations.Add(oest_stranden);
            destinations.Add(limfjorden);
            destinations.Add(nibehavn);
            destinations.Add(løgstør);
            destinations.Add(trend);
            destinations.Add(hals);
            destinations.Add(egholm);
            destinations.Add(lundby);

            
            Movement move = new Movement(150, 20, 400);
            animals.Add(new Animal(1,"Predo", "Sild", "Fish/SildAnimator", true, AnimalSize.large, move, krabbe ));
            animals.Add(new Animal(2,"Predo2", "Sild", "Fish/SildAnimator", true, AnimalSize.Small, move, krabbe));
            animals.Add(new Animal(3,"Predo3", "Torsk", "Fish/SildAnimator", true, AnimalSize.Small, move, krabbe));
            animals.Add(new Animal(4,"Predo4", "Torsk", "Fish/SildAnimator", false, AnimalSize.Small, move, krabbe));

            // animalpictures.Add(krabbe);
            // animalpictures.Add(laks);
            // animalpictures.Add(fladfisk);
            // animalpictures.Add(reje);
            // animalpictures.Add(myg);
            // animalpictures.Add(edderkop);

        }
    }
}























