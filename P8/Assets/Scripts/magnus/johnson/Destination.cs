using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination
{
    public string name { get; set; }
    public string information{get; set; }

    public Biome type { get; set; }




    public Destination(string name, string info, Biome biome)
    {
        this.name = name;
        this.information = info;
        this.type = biome;
    }


}
