using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Fish> availableFish = new List<Fish>();

    public void AddFish(Fish fish)
    {
        availableFish.Add(fish);
    }
    public void RemoveFish(Fish fish)
    {
        availableFish.Remove(fish);
    }


}
