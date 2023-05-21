using System.Collections.Generic;
using DataPersistence;
using DataStore;
using Models;
using UnityEngine;

namespace PlayTrip {
    public class PlayTripManager : MonoBehaviour, IDataPersistence {
        [SerializeField] private Journeys journeys = new Journeys();
        [SerializeField] private Map map = new Map();

        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
        }

        // Start is called before the first frame update
        void Start() {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        public void LoadData(GameData data) {
            this.map = data.map;
            this.journeys = data.journeys;
        }

        public void SaveData(GameData data) {
            data.map = this.map;
            data.journeys = this.journeys;
        }
    }
}