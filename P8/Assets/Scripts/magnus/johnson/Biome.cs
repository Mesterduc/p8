using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Biome
{   
    public string name;
    private List<FishTrivia> available_animals;
    private List<Activity> activities;



    public Biome(string name, Activity activity, FishTrivia trivia)
    {
        this.name = name;

        available_animals = new List<FishTrivia>();
        available_animals.Add(trivia);

        activities = new List<Activity>();
        activities.Add(activity);
    }


/*
    private List<FishTrivia> PopulateAnimals(string type){
    List<FishTrivia> list = new List<FishTrivia>();

        return list;
    }

    private List<Activity> PopulateActivities(string type){
        List<Activity> list = new List<Activity>();

        return list;
 }*/


}
