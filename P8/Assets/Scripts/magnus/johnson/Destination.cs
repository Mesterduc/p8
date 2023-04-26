using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Destination
{
    public string name { get; set; }
    public string information{get; set; }
    public Vector2 position{get; set; }

    public Biome type { get; set; }




    public Destination(string name, string info, Biome biome, Vector2 position)
    {
        this.name = name;
        this.information = info;
        this.type = biome;
        this.position = position;
    }


}
