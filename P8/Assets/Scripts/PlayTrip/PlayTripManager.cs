using System.Collections.Generic;
using DataPersistence;
using DataStore;
using Models;
using UnityEngine;

namespace PlayTrip {
    public class PlayTripManager : MonoBehaviour, IDataPersistence {
        [SerializeField] private List<Journey> journeys = new List<Journey>();
        [SerializeField] private List<Destination> destinations = new List<Destination>();

        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
        }

        // Start is called before the first frame update
        void Start() {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        public void LoadData(GameData data) {
            this.destinations = data.destinations;
            this.journeys = data.journeys;
        }

        public void SaveData(GameData data) {
            data.destinations = this.destinations;
            data.journeys = this.journeys;
        }
    }
}