using System.Collections.Generic;
using DataPersistence;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;
using Navigation;

namespace magnus.johnson {
    public class MenuScript : MonoBehaviour, IDataPersistence {
        public List<Destination> destinations;
        public GameObject modal;
        public GameObject title;
        public Transform list;
        public GameObject home;
        public TMP_Text car;
        public TMP_Text bus;
        [SerializeField] private Button chooseTrip;


        private bool isHidden = true;
        private int currentWindow = -1;

        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
        }

        void Start() {
            chooseTrip.onClick.AddListener(NextVisit);
            for (int i = 0; i < destinations.Count; i++) {
                GameObject objectToSpawn = Resources.Load<GameObject>("Prefabs/" + destinations[i].type.name);
                if (objectToSpawn) {
                    GameObject location = Instantiate(objectToSpawn, destinations[i].position, Quaternion.identity);
                    location.transform.SetParent(GameObject.Find("pngdenmark").transform, false);
                    location.name = i.ToString();
                }
            }
        }

        public void ShowModal(string tag, Vector3 position) {


            double travel = Math.Round(Vector3.Distance(position, home.transform.position), 1) * 20;
            double travelbus = travel * 2;

            string travelTime = travel.ToString();
            string travelTimeBus = travelbus.ToString();

            int id = int.Parse(tag);
            if (isHidden == true) {
                title.GetComponent<TMP_Text>().text = destinations[id].name;
                car.text = travelTime + " minutes";
                bus.text = travelTimeBus + " minutes";
                currentWindow = id;
                PopulateAnimals(id);
                modal.SetActive(isHidden);
                isHidden = !isHidden;
            }
            else if (isHidden == false && currentWindow != id) {
                DePopulateAnimals();
                PopulateAnimals(id);
                title.GetComponent<TMP_Text>().text = destinations[id].name;
                car.text = travelTime + " minutes";
                bus.text = travelTimeBus + " minutes";
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

        private void NextVisit()
        {
            ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.ChooseTrip);
        }


        public void LoadData(GameData data) {
            this.destinations = data.destinations;
        }

        public void SaveData(GameData data) {
            data.destinations = this.destinations;
        }
    }
}