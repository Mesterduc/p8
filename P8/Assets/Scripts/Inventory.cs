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
    public List<Animal> availableAnimals = new List<Animal>();
    public GameObject scrollContent;

    void Start()
    {
        // Instantiate some animals to add to the inventory
        Animal salmon = new Animal(1, "Salmon", "Salmon_Animated", "swim", true, AnimalSize.medium, new Movement(5f, 3f, 50f, Vector2.zero), new FishTrivia("Salmon", "description", new Activity("Swimming", "guide"), "habitat", "diet", "range"));
        AddAnimal(salmon);
        Animal Trout = new Animal(1, "Trout", "Salmon_Animated", "swim", true, AnimalSize.medium, new Movement(5f, 3f, 50f, Vector2.zero), new FishTrivia("Salmon", "description", new Activity("Swimming", "guide"), "habitat", "diet", "range"));
        AddAnimal(Trout);
        Animal Herring = new Animal(1, "Trout", "Salmon_Animated", "swim", true, AnimalSize.medium, new Movement(5f, 3f, 50f, Vector2.zero), new FishTrivia("Salmon", "description", new Activity("Swimming", "guide"), "habitat", "diet", "range"));
        AddAnimal(Herring);
        Animal fish = new Animal(1, "Trout", "Salmon_Animated", "swim", true, AnimalSize.medium, new Movement(5f, 3f, 50f, Vector2.zero), new FishTrivia("Salmon", "description", new Activity("Swimming", "guide"), "habitat", "diet", "range"));
        AddAnimal(fish);
        Animal fisk = new Animal(1, "Trout", "Salmon_Animated", "swim", true, AnimalSize.medium, new Movement(5f, 3f, 50f, Vector2.zero), new FishTrivia("Salmon", "description", new Activity("Swimming", "guide"), "habitat", "diet", "range"));
        AddAnimal(fisk);
        Animal animal = new Animal(1, "Trout", "Salmon_Animated", "swim", true, AnimalSize.medium, new Movement(5f, 3f, 50f, Vector2.zero), new FishTrivia("Salmon", "description", new Activity("Swimming", "guide"), "habitat", "diet", "range"));
        AddAnimal(animal);


    }

    public void AddAnimal(Animal animal)
    {
        availableAnimals.Add(animal);
        for (int i = 0; i < availableAnimals.Count; i++)
        {
            GameObject newAnimal = Instantiate(animalPrefab, scrollContent.transform);
            newAnimal.transform.localPosition = new Vector3(i * 150, 0, 0);
            TextMeshProUGUI[] animalInfo = newAnimal.GetComponentsInChildren<TextMeshProUGUI>();
            animalInfo[0].text = availableAnimals[i].name;
            availableAnimals[i].species = new FishTrivia(animal.name, "description", new Activity("Swimming", "Swimming guide"), "habitat", "diet", "range");
        }

    }

    public void RemoveAnimal(Animal animal)
    {
        availableAnimals.Remove(animal);
    }
}