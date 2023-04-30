using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Biome
{   
    public string name;
    public List<FishTrivia> available_animals = new List<FishTrivia>();
    public List<Activity> activities = new List<Activity>();



    public Biome(string name, List<Activity> activity, List<FishTrivia> trivia)
    {
        this.name = name;

        available_animals = trivia;

        activities = activity;
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
