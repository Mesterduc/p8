using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Button InventoryButton;
    public List<Fish> availableFish = new List<Fish>();

    public void AddFish(Fish fish)
    {
        availableFish.Add(fish);
    }
    public void RemoveFish(Fish fish)
    {
        availableFish.Remove(fish);

        void Start()
        {
            for (int i = 0; i < availableFish.Count; i++)
            {
                Fish fish = availableFish[i];
                Button InventoryButton = Instantiate(InventoryButton, transform);

            }

        }


    }
}
