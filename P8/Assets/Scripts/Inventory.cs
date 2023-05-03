// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using Animals;
// using DataPersistence;

public class Inventory : MonoBehaviour
{
    public Transform inventoryPanel;
    public GameObject animalPrefab;

    private GameData gameData;

    public List<Animal> availableAnimals;

//     public GameObject scrollContent;

    public Dictionary<string, GameObject> animalPrefabs;


    void Start()
    {


        gameData = new GameData();

        availableAnimals = gameData.animals;


        animalPrefabs = new Dictionary<string, GameObject>();
        GameObject[] animalPrefabArray = Resources.LoadAll<GameObject>("trivias");
        foreach (GameObject prefab in animalPrefabArray)
        {
            animalPrefabs[prefab.name] = prefab;
        }

        UpdateAnimalList();
    }


    private void UpdateAnimalList()
    {
        for (int i = 0; i < availableAnimals.Count; i++)
        {
            GameObject prefab = Resources.Load<GameObject>("trivias/" + availableAnimals[i].animated);
            if (prefab == null)
            {
                Debug.LogError("Prefab not found for animal: " + availableAnimals[i].name);
                continue;
            }
            GameObject newAnimal = Instantiate(prefab, scrollContent.transform);
            newAnimal.transform.localPosition = new Vector3(i * 150, 0, 0);
            TextMeshProUGUI[] animalInfo = newAnimal.GetComponentsInChildren<TextMeshProUGUI>();
            animalInfo[0].text = availableAnimals[i].name;
        }




//     }


//     public void RemoveAnimal(Animal animal)
//     {
//         availableAnimals.Remove(animal);
//     }
// }