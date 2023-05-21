using System;
using System.Collections.Generic;
using DataPersistence;
using DataStore;
using Models;
using Navigation;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MapScene {
    public class MapManager : MonoBehaviour, IDataPersistence {
        public Map map;
        public GameObject modal;
        public GameObject title;
        public Transform list;
        public GameObject home;
        public TMP_Text car;
        public TMP_Text bus;
        [SerializeField] private Button chooseTrip;
        private int currentWindow = -1;

        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
        }

        void Start() {
            chooseTrip.onClick.AddListener(NextVisit);
            for (int i = 0; i < map.destinations.Count; i++) {
                GameObject objectToSpawn = Resources.Load<GameObject>("Prefabs/" + map.destinations[i].type.name);
                if (objectToSpawn) {
                    GameObject location = Instantiate(objectToSpawn, map.destinations[i].position, Quaternion.identity);
                    location.transform.SetParent(GameObject.Find("pngdenmark").transform, false);
                    // navn til location gameobject, dette bruges til af showModal linje 50, til at vise den rigtige location/destination
                    location.name = i.ToString();
                    location.transform.Find("DestinationName").GetComponent<TMP_Text>().text = map.destinations[i].name;
                }
            }
        }
        // Modal vises udfra panel navn/som er panel id
        public void ShowModal(string tag, Vector3 position) {
            double travel = Math.Round(Vector3.Distance(position, home.transform.position), 1) * 20;
            double travelbus = travel * 2;
            string travelTime = travel.ToString();
            string travelTimeBus = travelbus.ToString();

            int id = int.Parse(tag);
            if (!modal.activeSelf) {
                title.GetComponent<TMP_Text>().text = map.destinations[id].name;
                car.text = travelTime + " min";
                bus.text = travelTimeBus + " min";
                currentWindow = id;
                PopulateAnimals(id);
                modal.SetActive(true);
            }
            else if (modal.activeSelf && currentWindow != id) {
                DePopulateAnimals();
                PopulateAnimals(id);
                title.GetComponent<TMP_Text>().text = map.destinations[id].name;
                car.text = travelTime + " minutes";
                bus.text = travelTimeBus + " minutes";
                currentWindow = id;
            }
            else {
                DePopulateAnimals();
                modal.SetActive(false);
            }
        }

        private void DePopulateAnimals() {
            while (list.transform.childCount > 0) {
                DestroyImmediate(list.transform.GetChild(0).gameObject);
            }
        }

        private void PopulateAnimals(int index) {
            for (int i = 0; i < map.destinations[index].type.available_animals.Count; i++) {
                GameObject objectToSpawn =
                    Resources.Load("Trivias/" + map.destinations[index].type.available_animals[i].name) as GameObject;
                GameObject animalpicture = Instantiate(objectToSpawn, list);
            }
        }

        private void NextVisit()
        {
            ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.Menu);
        }


        public void LoadData(GameData data) {
            this.map = data.map;
        }

        public void SaveData(GameData data) {
            data.map = this.map;
        }
    }
}