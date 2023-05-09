using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine.UI;
using System;


// Class for saving and loading game objects 
// Save methods
namespace DataPersistence {
    public class DataPersistenceManager : MonoBehaviour {
        [Header("File Storage Config")]
        // Data filnavn som indenholder vores data
        [SerializeField]
        private string fileName = "data.json";

        // Button til at manual gemme 
        [SerializeField] [CanBeNull] private Button manualSaveGame;
        [SerializeField] [CanBeNull] private Button manualLoadGame;
        // [SerializeField] [CanBeNull] private Button manualLoadDataButton;

        // Tom gameData class 
        public GameData gameData;

        // indenholder alle scenes som implementer IDataPersistence interface, så man kan loade og gemme data
        private List<IDataPersistence> dataPersistenceObjects;

        // Håndtere fil konvertering fra Objekter til JSON fil
        private FileDataHandler dataHandler;


        // Static: kun en instance af denne class kan blive initialized, den bliver sat i Awake() methoden:  
        public static DataPersistenceManager Instance { get; private set; } // shorthand for en get og set methode

        private void Awake() {
            if (Instance != null) {
                // Debug.LogError("Found more the one instance of DataPersistenceManager in the scene.");
            }

            Instance = this;
        }

        // Start bliver kaldt i starten af programmet,og giver data til alle classer
        private void Start() {
            // Application.persistentDataPath  file location
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            // Udkommentere Debug hvis man vil se hvor filen bliver gemt
            // Debug.Log(Application.persistentDataPath);

            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            if (manualSaveGame) {
                manualSaveGame.onClick.AddListener(SaveGame2);
            }

            if (manualLoadGame) {
                manualLoadGame.onClick.AddListener(manualLoadData);
            }
        
            // PreLoad();
            LoadGame();
            // SaveGame();
        }

        public void NewGame() {
            this.gameData = new GameData();
        }

        public void LoadGame() {
            this.gameData = dataHandler.Load();
            if (this.gameData == null) {
                Debug.Log("No data is found dataManager");
                NewGame();
            }

            // Looper alle scener der implementere IDataPersistence interface, og loader alt data ind til gameData
            foreach (IDataPersistence dataObject in dataPersistenceObjects) {
                dataObject.LoadData(gameData);
            }
        }

        public void SaveGame() {
            // if we don't have any data to save
            if (this.gameData == null) {
                Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
                return;
            }

            // Looper alle scener der implementere IDataPersistence interface, og gemmer alt data ind til gameData
            foreach (IDataPersistence dataObject in dataPersistenceObjects) {
                dataObject.SaveData(gameData);
            }


            // gemmer gameData til fil
            dataHandler.Save(gameData);
        }

        private void SaveGameOnQuit() {
            SaveGame();
        }

        public void manualLoadData() {
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            this.gameData = dataHandler.Load();
            foreach (IDataPersistence dataObject in dataPersistenceObjects) {
                dataObject.LoadData(gameData);
            }
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects() {
            IEnumerable<IDataPersistence> dataPersistencesObjects =
                FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
            return new List<IDataPersistence>(dataPersistencesObjects);
        }

        // Add things here ----------------------------------------------------------------------------------------------

        // init: what should be in the game when starting
        private void PreLoad() {
            // initialize a new clean gameData object where data is pre populate 
            gameData = new GameData();
            dataHandler.Save(gameData);
        }

        // Manual Save
        public void SaveGame2() {
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            foreach (IDataPersistence dataObject in dataPersistenceObjects) {
                dataObject.SaveData(gameData);
            }

            dataHandler.Save(gameData);
            // foreach (IDataPersistence dataObject in dataPersistenceObjects) {
            //     dataObject.LoadData(gameData);
            // }
        }
    }
}