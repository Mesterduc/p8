using Animals;
using DataPersistence;
using magnus.johnson;
using TMPro;
using UnityEngine;

namespace AddAnimal {
    public class CreateAnimalScript : MonoBehaviour, IDataPersistence {
        public GameObject textName;
        public int size;
        
        public Animal AddAnimal() {
            Debug.Log(textName.transform.GetComponent<TMP_Text>().text);
            Debug.Log(AnimalSize.large == (AnimalSize)size);
            Movement move = new Movement(150, 20, 400);
            Activity fang_fisk = new Activity("Fisketur", "Anskaf dig en fiskestang og se en video");
            FishTrivia ørred = new FishTrivia("Ørred", "Fish/Sild",fang_fisk, "Andre fisk", "Sjælden", "Ørred finder du aldrig min dud");
            Animal animal = new Animal(5, "Predo", "Fish/Sild", "Fish/SildAnimator", true, AnimalSize.large, move, ørred);
            // animalListGameList.Add(animal);
            return animal;
        }
        
        // public void
        public void LoadData(GameData data) {
            // throw new System.NotImplementedException();
        }

        public void SaveData(GameData data) {
            // throw new System.NotImplementedException();
            // data.animals.Add(AddAnimal());
        }
    }
}