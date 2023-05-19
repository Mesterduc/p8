using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DataStore;
using JetBrains.Annotations;
using UnityEngine.UI;

// Class for saving and loading game objects 
// Save methods
namespace DataPersistence {
    public class DataPersistenceManager : MonoBehaviour {
        [Header("File Storage Config")]
        // Data filnavn som indenholder vores data
        [SerializeField] private string fileName = "data.json";
        // Button til at manual gemme 
        [SerializeField] [CanBeNull] private Button manualSaveGame;
        [SerializeField] [CanBeNull] private Button manualLoadGame;
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

        private void Start() {
            // Application.persistentDataPath file location
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

            // this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            if (manualSaveGame) {
                manualSaveGame.onClick.AddListener(SaveGame);
            }
            if (manualLoadGame) {
                manualLoadGame.onClick.AddListener(manualLoadData);
            }
            // NewGame();
            // PreLoad();
            // LoadGame();
            // SaveGame();
        }

        public void NewGame() {
            this.gameData = new GameData();
        }

        public void SaveGame() {
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
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

        private void OnDestroy() {
            SaveGame();
        }

        public void manualLoadData() {
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            this.gameData = this.dataHandler.Load();
            // Looper alle aktive scener der implementere IdataPersistence
            foreach (IDataPersistence dataObject in dataPersistenceObjects) {
                // kalder scriptes loaddata funtion
                dataObject.LoadData(gameData);
            }
        }

        // finder alle aktive scener der implementere IdataPersistence
        private List<IDataPersistence> FindAllDataPersistenceObjects() {
            IEnumerable<IDataPersistence> dataPersistencesObjects =
                FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();
            return new List<IDataPersistence>(dataPersistencesObjects);
        }

        // init: what should be in the game when starting
        public void PreLoad() {
            // initialize a new clean gameData object where data is pre populate 
            gameData = new GameData();
            gameData.PreLoad();
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            dataHandler.Save(gameData);
        }
    }
}