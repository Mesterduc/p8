using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataPersistence {
    // Place data here 
    [System.Serializable]
    public class GameData {
        public PlayerData playerData;
        public string _name;
        public List<Friend> friends = new List<Friend>();
        

        public GameData() {
            PreLoad();
        }
        
        
        private void PreLoad() {
            this.playerData = new PlayerData("halla halla");
            
            this._name = "Ole";
            
            friends.Add(new Friend("Ole", 10, 4));
            friends.Add(new Friend("Jax", 99, 99));
            friends.Add(new Friend("Sune", 490, 13));
        }
    }
}
