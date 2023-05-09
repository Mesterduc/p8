using System.Collections;
using System;
using System.Collections.Generic;
using Animals;
using magnus.johnson;
using Models;
using UnityEngine;


namespace DataPersistence
{
    // Place test data here 
    [System.Serializable]
    public class GameData
    {
        public PlayerData playerData;
        public List<Friend> friends = new List<Friend>();
        public List<Animal> animals = new List<Animal>();
        public List<FishTrivia> species = new List<FishTrivia>();
        public List<Journey> journeys = new List<Journey>();

        //Magnus datamodel
        public List<Destination> destinations = new List<Destination>();


        public GameData()
        {
            PreLoad();
        }

        // loader program med standard data
        private void PreLoad() {
            måskeSlet();
            listOfSpices();

            // -------------------------------------------- Activity ---------------------------------------------------------------
            Activity fang_krabber = new Activity("Krabbejagt", "Find en tøjklemme og en snor. Put en blåmusling på tøjklemmen og sænk den ned i vandet. Så er der krabber!");
            Activity fang_fisk = new Activity("Fisketur", "Anskaf dig en fiskestang og se en video");
            Activity fang_insekter = new Activity("Insektjagt", "Insekter kan du fange sådan her:");
            Activity fang_edderkopper = new Activity("Edderkoppe-Eventyr", "Find et edderkoppenet. Find en flue. Put en flue i nettet. WIN!");

            List<Activity> hede_aktiviteter = new List<Activity>();
            hede_aktiviteter.Add(fang_edderkopper);
            hede_aktiviteter.Add(fang_insekter);

            List<Activity> strand_aktiviteter = new List<Activity>();
            strand_aktiviteter.Add(fang_fisk);
            strand_aktiviteter.Add(fang_krabber);

            List<Activity> havn_aktiviteter = new List<Activity>();
            havn_aktiviteter.Add(fang_fisk);
            havn_aktiviteter.Add(fang_krabber);

            List<Activity> skov_aktiviteter = new List<Activity>();
            skov_aktiviteter.Add(fang_edderkopper);
            skov_aktiviteter.Add(fang_insekter);
            
            //--------------------------------------------------- Trivia -------------------------------------------------------------------------------------
            
            FishTrivia guldsmed = new FishTrivia("Guldsmed","Fish/Sild", "", fang_insekter, "Andre insekter", "Sjælden", "Guldsmeden flyver tit ved ferskvandssøer");
            FishTrivia hornbille = new FishTrivia("Hornbille", "Fish/Sild","",fang_insekter, "Bæ", "Almindelig", "Hornbiller har horn");
            FishTrivia husedderkop = new FishTrivia("Husedderkop","Fish/Sild", "",fang_edderkopper, "Fluer", "Sjælden", "Husedderkoppen kan blive KÆÆÆÆMPE stor");
            FishTrivia stinkbille = new FishTrivia("Stinkbille", "Fish/Sild","",fang_insekter, "Kolort", "Sjælden", "Stinkbillen er kendt for at stinke");
            FishTrivia spyflue = new FishTrivia("Spyflue", "Fish/Sild","",fang_insekter, "Andre insekter", "Almindelig", "Jeg hader den her flue");
            FishTrivia tæge = new FishTrivia("Tæge", "Fish/Sild","",fang_insekter, "Andre insekter", "Almindelig", "En tæge. Ikke en flåt.");
            FishTrivia snegl = new FishTrivia("Snegl", "Fish/Sild","",fang_insekter, "Blade", "almindelig", "Find din snegl i din nærmeste bøgehæk");

            FishTrivia krabbe = new FishTrivia("Krabbe","Fish/Sild","", fang_krabber, "Kød", "Almindelig", "Krabben er fandeme over det hele man");
            FishTrivia ørred = new FishTrivia("Ørred", "Fish/Sild","",fang_fisk, "Andre fisk", "Sjælden", "Ørred finder du aldrig min dud");
            FishTrivia hornfisk = new FishTrivia("Hornfisk", "Fish/Sild","",fang_fisk, "Andre fisk", "Almindelig", "Den er længere end turen hjem fra Roskilde");
            FishTrivia skrubbe = new FishTrivia("Skrubbe", "Fish/Sild","",fang_fisk, "Rejer, muslinger", "Almindelig", "Skrubben er svær at finde (fordi den er flad)");
            FishTrivia pighvar = new FishTrivia("Pighvar","Fish/Sild", "",fang_fisk, "Rejer, muslinger", "Sjælden", "Hans mener han er jordens bedste til at fange dem");
            FishTrivia sild = new FishTrivia("Sild", "Fish/Sild","",fang_fisk, "Alt", "Almindelig", "Du kan næsten ikke undgå at finde sild");
            FishTrivia torsk = new FishTrivia("Torsk", "Fish/Sild","",fang_fisk, "Alt", "Sjælden", "Engang var der mange torsk. Nu kan de være svære at finde");
            
            List<FishTrivia> hede_dyr = new List<FishTrivia>();
            hede_dyr.Add(hornbille);
            hede_dyr.Add(husedderkop);
            hede_dyr.Add(stinkbille);
            hede_dyr.Add(spyflue);
            
            List<FishTrivia> skov_dyr = new List<FishTrivia>();
            skov_dyr.Add(guldsmed);
            skov_dyr.Add(spyflue);
            skov_dyr.Add(snegl);
            skov_dyr.Add(tæge);
            
            List<FishTrivia> strand_dyr = new List<FishTrivia>();
            strand_dyr.Add(krabbe);
            strand_dyr.Add(ørred);
            strand_dyr.Add(hornfisk);
            strand_dyr.Add(skrubbe);
            strand_dyr.Add(pighvar);
            
            List<FishTrivia> havn_dyr = new List<FishTrivia>();
            havn_dyr.Add(torsk);
            havn_dyr.Add(sild);
            havn_dyr.Add(hornfisk);

            // --------------------------------------- Biome --------------------------------------------------------------------
            Biome strand = new Biome("Strand", strand_aktiviteter, strand_dyr);
            Biome havn = new Biome("Havn", havn_aktiviteter, havn_dyr);
            Biome skov = new Biome("Skov", skov_aktiviteter, skov_dyr);
            Biome hede = new Biome("Hede", hede_aktiviteter, hede_dyr);
            
            // --------------------------------------- Destination --------------------------------------------------------------------
            Destination dall_hede = new Destination("Dall Hede", "Dall hede er et sted man kan slappe af om sommeren.", hede, new Vector3(-2.288f, 4.229f, 1f), "Dall Hede, Hedevej 12b, 9930");
            Destination egholm = new Destination("Egholm", "En stor mark med en masse insekter", hede, new Vector3(-2.28f, 5.497f, 1f), "Ingen Addresse for denne destination");
            Destination rold_skov = new Destination("Rold Skov", "Rold skov er fandeme ikke et sted du skal slappe for meget af", skov, new Vector3(-1.859f, 3.659f, 1f), "Rold Skov, Rebild Skovhusevej 30, 9520");
            Destination aalborghavn = new Destination("Aalborg Havn", "Her kan du altid finde en ødelagt flaske eller to", havn, new Vector3(-1.533f, 5.313f, 1f), "Ingen Addresse for denne destination");
            Destination oest_stranden = new Destination("Øst-stranden", "Ved en strand er der sand. Og ved sand er der vand.", strand, new Vector3(-0.325f, 4.3679f, 1f), "Ingen Addresse for denne destination");
            Destination limfjorden = new Destination("Østersstranden", "Jeg fandt den her strand da jeg kiggede på ugler", strand, new Vector3(-4.799f, 3.678f, 1f), "Ingen Addresse for denne destination");
            Destination nibehavn = new Destination("Nibe Havn", "Jeg fandt den her strand da jeg kiggede på ugler", havn, new Vector3(-2.438f, 4.995f, 1f), "Ingen Addresse for denne destination");
            Destination løgstør = new Destination("Løgstør Havn", "Jeg fandt den her strand da jeg kiggede på ugler", havn, new Vector3(-3.778f, 4.612f, 1f), "Ingen Addresse for denne destination");
            Destination trend = new Destination("Trend Havn", "Jeg fandt den her strand da jeg kiggede på ugler", havn, new Vector3(-3.919f, 4.126f, 1f), "Ingen Addresse for denne destination");
            Destination hals = new Destination("Hals Havn", "Jeg fandt den her strand da jeg kiggede på ugler", havn, new Vector3(-0.598f, 4.873f, 1f), "Ingen Addresse for denne destination");
            Destination lundby = new Destination("Lundby Krat", "Lundby krat er et fedt sted", skov, new Vector3(-1.146f, 4.412f, 1f), "Ingen Addresse for denne destination");

            destinations.Add(dall_hede);
            destinations.Add(rold_skov);
            destinations.Add(oest_stranden);
            destinations.Add(limfjorden);
            destinations.Add(egholm);
            destinations.Add(lundby);

            Journey g1 = new Journey(1, rold_skov);
            Journey g2 = new Journey(2, lundby);
            Journey g3 = new Journey(3, dall_hede);
            journeys.Add(g1);
            journeys.Add(g2);
            journeys.Add(g3);
            
            // ----------------------------------- Animal ---------------------------------------------------------------------------------
            
           
            // Movement move = new Movement(150, 20, 400);
            Animal predo4 = new Animal(4, "Predo4", "Fish/Sild", "Fish/SildAnimator", AnimalSize.Small, krabbe, g1);
            predo4.isDisplayed = false;
            Animal predo5 = new Animal(5, "Predo5", "Fish/Sild", "Fish/SildAnimator", AnimalSize.Small, krabbe, g1);
            predo5.isDisplayed = false;
            animals.Add(new Animal(1,"Predo", "Fish/Sild", "Fish/SildAnimator", AnimalSize.large, krabbe, g1));
            animals.Add(new Animal(2,"Predo2", "Fish/Sild", "Fish/SildAnimator", AnimalSize.Small, krabbe, g2));
            animals.Add(new Animal(3,"Predo3", "Fish/Sild", "Fish/SildAnimator", AnimalSize.Small, krabbe, g3));
            animals.Add(predo4);
            animals.Add(predo5);

        }

        private void måskeSlet() {
            this.playerData = new PlayerData("Jeff");

            friends.Add(new Friend("Johnson", 10, 4, "pedro"));
            friends.Add(new Friend("Jax", 99, 99, "sifos"));
            friends.Add(new Friend("Yuli", 490, 13, "yuli"));
            friends.Add(new Friend("Sifos", 490, 13, "sifos"));
        }

        private void listOfSpices() {
            Activity fang_krabber = new Activity("Krabbejagt", "Find en tøjklemme og en snor. Put en blåmusling på tøjklemmen og sænk den ned i vandet. Så er der krabber!");
            Activity fang_fisk = new Activity("Fisketur", "Anskaf dig en fiskestang og se en video");
            Activity fang_edderkopper = new Activity("Edderkoppe-Eventyr", "Find et edderkoppenet. Find en flue. Put en flue i nettet. WIN!");
            
            FishTrivia lundsneglen = new FishTrivia("Lundsneglen", "DyrIcon/snail", "Real/lundsnegl" , fang_krabber, "Kød", "Almindelig", "Lundsneglen er en mellemstor snegl med fladt, kugleformet hus og mørk skalåbning. Huset bliver mellem 12-22 mm i højde og 18-25 mm i brede, huset varierer i farve og tegning fra gullig til rødlig eller brunlig med eller uden mørke spiralbånd. >Kroppen er grålig");
            FishTrivia havesnegl = new FishTrivia("Havesnegl", "DyrIcon/snail", "Real/havesnegl" ,fang_fisk, "Andre fisk", "Almindelig", "Havesneglens hus varierer meget i farven fra brunt til rødt og gult. Snailen bliver ca. 2 cm lang og huset bliver ca. 2 cm i diameter. Huset kan være ensfarvet, eller det kan have 5 mørke bånd, som snor sig rundt om sneglehuset.");
            FishTrivia myre = new FishTrivia("Sorte havemyrer", "DyrIcon/myre", "Real/myre" ,fang_fisk, "Rejer, muslinger", "Almindelig", "Sorte arbejder havemyrer: 3,5-5 mm. lang. Farven er gråbrun til sortbrun med lysere ben, og følehorn med en matglinsende overflade. Tæt behåring med varierende længde. Skællet er lavt og bredt med parallelle sider og lige overkant.");
            FishTrivia edderkop = new FishTrivia("Korsedderkop", "DyrIcon/spider", "Real/Korsedderkop" ,fang_edderkopper, "Insekter", "Almindelig", "Korsedderkoppen har oftest på oversiden et lyst mønster, der ligner et kors. Korset er sammensat af mindre hvide pletter, der dog hos store individer kan mangle eller være meget små, så korset er utydeligt. Bagkroppen er altid mere eller mindre trekantet, og spidser til bagtil. Forrest på bagkroppen ses som regel to små pukler, der forstærker den trekantede facon. Hannens kropsmål er ca. 8 mm, mens hunnen bliver op til ca. 17 mm, når den om efteråret er fuld af æg. I modsætning til de voksne dyr er ungerne gule med sorte aftegninger.");
            FishTrivia kratløber = new FishTrivia("Kratløber", "DyrIcon/stinkbille", "Real/Kratløber" ,fang_edderkopper, "Insekter", "Almindelig", "Kratløber bliver 22-26 mm. i længde. En ret stor og noget kompakt løbebille, som på afstand udmærker sig ved en svagt brunlig eller blåviolet farve på dækvingerne. Kanten af pronotum og dækvingerne er ofte klart violette. Det bedste kendetegn er en generel violetfarvning kombineret med, at der på hver dækvinge er tre rækker af tydeligt runde fordybninger, ca. 10 i hver række.");
            
            // FishTrivia reje = new FishTrivia("Reje", "rejebillede", fang_rejer, "plankton", "Almindelig", "Du kan næsten ikke undgå at finde rejer");
            // FishTrivia myg = new FishTrivia("Myg", "myggebillede", fang_myg, "BLOD!", "Almindelig", "AV AV du blev stukket af en myg");
            species.Add(lundsneglen);
            species.Add(havesnegl);
            species.Add(myre);
            species.Add(edderkop);
            species.Add(kratløber);
        }
    }
}























