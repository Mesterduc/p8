using System.Collections.Generic;

namespace Models {
    [System.Serializable]
    public class Biome
    {   
        public string name;
        public List<Trivia> available_animals;
        public List<Activity> activities;



        public Biome(string name, List<Activity> activity, List<Trivia> trivia)
        {
            this.name = name;

            available_animals = trivia;

            activities = activity;
        }


        /*
    private List<Trivia> PopulateAnimals(string type){
    List<Trivia> list = new List<Trivia>();

        return list;
    }

    private List<Activity> PopulateActivities(string type){
        List<Activity> list = new List<Activity>();

        return list;
 }*/


    }
}
