using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataPersistence {
    // Place data here 
    [System.Serializable]
    public class GameData {
        // Alle data modeller samles her, det er dem som bliver gemt i en fil.
        public PlayerData playerData;
        public string _name;
        public List<Friend> friends = new List<Friend>();
        

        public GameData() {
            PreLoad();
        }
        
        // loader vores program med nogen standard data
        private void PreLoad() {
            this.playerData = new PlayerData("halla halla");
            
            this._name = "Ole";
            
            friends.Add(new Friend("Predo", 10, 4, "pedro"));
            friends.Add(new Friend("Jax", 99, 99, "sifos"));
            friends.Add(new Friend("Yuli", 490, 13, "yuli"));
            friends.Add(new Friend("Sifos", 490, 13, "sifos"));
            friends.Add(new Friend("Sune", 490, 13, "pedro"));
        }
    }
}
