using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Activity
{
    public string name;
    public string guide;
    public string image;

    public Activity(string name, string guide)
    {
        this.name = name;
        this.guide = guide;
    }
}
