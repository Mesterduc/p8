using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataPersistence {
    // Place to get data 
    [System.Serializable]
    public class GameData {
        public PlayerData playerData;
        
        public GameData(PlayerData playerData) {
            this.playerData = playerData;
        }
    }
}
