using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    // public Transform InventoryPanel;
    // public GameObject FishPrefab;
    // public List<Fish> availableFish = new List<Fish>();
    // Fish Salmon = new Fish("test", "Salmon", "water animal", 1, "lol", AnimalSize.large, "lol", true);

    // Fish Herring = new Fish("test2", "Salmon", "water animal", 1, "lol", AnimalSize.large, "lol", true);

    // Fish Trout = new Fish("test3", "Salmon", "water animal", 1, "lol", AnimalSize.large, "lol", true);

    // void Start()
    // {
    //     AddFish(Salmon);
    //     AddFish(Herring);
    //     AddFish(Trout);
    // }
    // public void AddFish(Fish fish)
    // {
    //     availableFish.Add(fish);
    //     for (int i = 0; i < availableFish.Count; i++)
    //     {
    //         GameObject newFish = Instantiate(FishPrefab, transform.position, Quaternion.identity);
    //         newFish.transform.SetParent(InventoryPanel, false);
    //         newFish.transform.localPosition = new Vector3(i * 150, 0, 0);
    //         TextMeshProUGUI[] fishInfo = newFish.GetComponentsInChildren<TextMeshProUGUI>();
    //         fishInfo[0].text = availableFish[i].name;
    //     }



    // }
    // public void RemoveFish(Fish fish)
    // {
    //     availableFish.Remove(fish);
    // }

}
