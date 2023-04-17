using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataPersistence {
    // Place to get data 
    [System.Serializable]
    public class GameData {
        public Player player;

        public GameData(Player player) {
            this.player = player;
        }
    }
}
