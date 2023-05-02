using System.Collections.Generic;
using DataPersistence;
using TMPro;
using UnityEngine;

namespace magnus.johnson {
    public class MenuScript : MonoBehaviour, IDataPersistence {
        public List<Destination> destinations;
        public GameObject modal;
        public GameObject title;
        public Transform list;
        private bool isHidden = true;
        private int currentWindow = -1;

        void Start() {
            for (int i = 0; i < destinations.Count; i++) {
                GameObject objectToSpawn = Resources.Load<GameObject>("Prefabs/" + destinations[i].type.name);
                if (objectToSpawn) {
                    GameObject location = Instantiate(objectToSpawn, destinations[i].position, Quaternion.identity);
                    location.transform.SetParent(GameObject.Find("pngdenmark").transform, false);
                    location.name = i.ToString();
                }
            }
        }

        public void ShowModal(string tag) {
            int id = int.Parse(tag);
            if (isHidden == true) {
                title.GetComponent<TMP_Text>().text = destinations[id].name;
                currentWindow = id;
                PopulateAnimals(id);
                modal.SetActive(isHidden);
                isHidden = !isHidden;
            }
            else if (isHidden == false && currentWindow != id) {
                DePopulateAnimals();
                PopulateAnimals(id);
                title.GetComponent<TMP_Text>().text = destinations[id].name;
                currentWindow = id;
            }
            else {
                DePopulateAnimals();
                modal.SetActive(isHidden);
                isHidden = !isHidden;
            }
        }

        private void DePopulateAnimals() {
            while (list.transform.childCount > 0) {
                DestroyImmediate(list.transform.GetChild(0).gameObject);
            }
        }

        private void PopulateAnimals(int index) {
            for (int i = 0; i < destinations[index].type.available_animals.Count; i++) {
                GameObject objectToSpawn =
                    Resources.Load("Trivias/" + destinations[index].type.available_animals[i].name) as GameObject;
                GameObject animalpicture = Instantiate(objectToSpawn, list);
            }
        }


        public void LoadData(GameData data) {
            this.destinations = data.destinations;
        }

        public void SaveData(GameData data) {
            data.destinations = this.destinations;
        }
    }
}