using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTrivia

{
    public string name;
    public string picture;
    public Activity activities;
    public string diet;
    public string status;
    public string bio;

    public FishTrivia(string name, string picture, Activity activities, string diet, string status, string bio)
    {
        this.name = name;
        this.picture = picture;
        this.activities = activities;
        this.diet = diet;
        this.status = status;
        this.bio = bio;
    }
}
