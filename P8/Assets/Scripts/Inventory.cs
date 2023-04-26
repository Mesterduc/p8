using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Transform InventoryPanel;
    public GameObject FishPrefab;
    public List<Fish> availableFish = new List<Fish>();
    Fish Salmon = new Fish("test", "Salmon", "water animal", 1, "lol", AnimalSize.large, "lol", true);
    Fish Herring = new Fish("test", "Salmon", "water animal", 1, "lol", AnimalSize.large, "lol", true);
    void Start()
    {
        AddFish(Salmon);
    }
    public void AddFish(Fish fish)
    {
        availableFish.Add(fish);
        GameObject newFish = Instantiate(FishPrefab, transform.position, Quaternion.identity);
        newFish.transform.SetParent(InventoryPanel, false);
        newFish.transform.localPosition = Vector2.zero;


    }
    public void RemoveFish(Fish fish)
    {
        availableFish.Remove(fish);
    }

}
