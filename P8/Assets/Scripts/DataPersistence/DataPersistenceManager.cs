using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Class for saving and loading game objects 
namespace DataPersistence {
    public class DataPersistenceManager: MonoBehaviour {
        [Header("File Storage Config")]
        [SerializeField] private string fileName;
        
        private GameData gameData;
        private Player player;
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
        
        private void Start() {
            // Application.persistentDataPath common file location for unity
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }

        public void NewGame() {
            this.player = new Player("Anivia"); 
            this.gameData = new GameData(this.player);
        }
        // public void CreateTank() { }
        // public void LoadTank() { }
        // public void CreatePlayer() { }
        // public void CreateFish() { }
        
        public void LoadGame() {
            this.gameData = dataHandler.Load();
            if (this.gameData == null) {
                Debug.Log("No data is found");
                // TODO: start new game
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

    }
}