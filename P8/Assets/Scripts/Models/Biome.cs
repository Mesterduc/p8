using System.Collections.Generic;

namespace Models {
    [System.Serializable]
    public class Biome
    {   
        public string name;
        public List<Species> available_animals;
        public List<Activity> activities;



        public Biome(string name, List<Activity> activity, List<Species> trivia)
        {
            this.name = name;

            available_animals = trivia;

            activities = activity;
        }


        /*
    private List<Species> PopulateAnimals(string type){
    List<Species> list = new List<Species>();

        return list;
    }

    private List<Activity> PopulateActivities(string type){
        List<Activity> list = new List<Activity>();

        return list;
 }*/


    }
}
