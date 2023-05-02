using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Animals;
using DataPersistence;

public class Inventory : MonoBehaviour
{
    public Transform inventoryPanel;
    public GameObject animalPrefab;

    private GameData gameData;

    public List<Animal> availableAnimals;

    public GameObject scrollContent;


    void Start()
    {

        gameData = new GameData();

        availableAnimals = gameData.animals;

        UpdateAnimalList();
    }

    private void UpdateAnimalList()
    {
        for (int i = 0; i < availableAnimals.Count; i++)
        {
            GameObject newAnimal = Instantiate(animalPrefab, scrollContent.transform);
            newAnimal.transform.localPosition = new Vector3(i * 150, 0, 0);
            TextMeshProUGUI[] animalInfo = newAnimal.GetComponentsInChildren<TextMeshProUGUI>();
            animalInfo[0].text = availableAnimals[i].name;
        }




    }


    public void RemoveAnimal(Animal animal)
    {
        availableAnimals.Remove(animal);
    }
}