using UnityEngine;

namespace DataPersistence {
    // Save and load game data manager
    public class DataPersistenceManager {
        private GameData gameData;
        private Player player;
        
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
            
        }

        public void SaveGame() {
            
        }

        private void SaveGameOnQuit() {
            SaveGame();
        }
        
    }
}