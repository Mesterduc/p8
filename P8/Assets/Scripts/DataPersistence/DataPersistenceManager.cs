using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine.UI;

// Class for saving and loading game objects 
// Save methods
namespace DataPersistence {
    public class DataPersistenceManager: MonoBehaviour {
        [Header("File Storage Config")]
        [SerializeField] private string fileName;
        [SerializeField] [CanBeNull] private Button manualSaveGame;
        
        private GameData gameData;
        private PlayerData player;
        private List<IDataPersistence> dataPersistenceObjects;
        private FileDataHandler dataHandler;

        // Static only one instance of this class can be initialized
        public static DataPersistenceManager Instance { get; private set; }

        private void Awake() 
        {
            if (Instance != null) {
                Debug.LogError("Found more the one instance of DataPersistenceManager in the scene.");
            }
            Instance = this;
        }
        // loads the data to classes.
        private void Start() {
            // Application.persistentDataPath common file location for unity
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            if (manualSaveGame) {
                manualSaveGame.onClick.AddListener(SaveGame2);
            }
            PreLoad();
            LoadGame();
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

            foreach (IDataPersistence dataObject in dataPersistenceObjects) {
                dataObject.LoadData(gameData);
            }
        }

        public void SaveGame() {
            // if we don't have any data to save, log a warning here
            if (this.gameData == null) 
            {
                Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
                return;
            }
            
            foreach (IDataPersistence dataObject in dataPersistenceObjects) {
                dataObject.SaveData(gameData);
            }
            dataHandler.Save(gameData);
        }

        private void SaveGameOnQuit() {
            SaveGame();
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
        
        // Custom save methods here
        public void SaveGame2() {
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