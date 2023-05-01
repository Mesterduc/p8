using System.Collections.Generic;
using DataPersistence;
using TMPro;
using UnityEngine;

namespace magnus.johnson {
    [System.Serializable]
    public class MenuScript : MonoBehaviour, IDataPersistence {
        public List<Destination> destinations = new List<Destination>();
        public GameObject modal;
        public GameObject title;
        public Transform list;
        private bool isHidden = true;
        private int currentWindow = -1;


        private void Awake() {
        }

        void Start() {
            for (int i = 0; i < destinations.Count; i++) {
                Debug.Log(destinations[0].name);
                GameObject objectToSpawn = Resources.Load("Prefabs/" + destinations[i].type.name) as GameObject;
                GameObject location = Instantiate(objectToSpawn, destinations[i].position, Quaternion.identity);
                location.transform.SetParent(GameObject.Find("pngdenmark").transform, false);
                location.name = i.ToString();
            }
        }

        // Update is called once per frame
        void Update() {
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
            destinations = data.destinations;
        }

        public void SaveData(GameData data) {
            // throw new System.NotImplementedException();
            data.destinations = this.destinations;
        }
    }
}