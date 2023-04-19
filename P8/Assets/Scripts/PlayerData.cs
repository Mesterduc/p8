using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;

    // public PlayerData(Player player) {
    //     this.name = player.name;
    // }
    public PlayerData(string name) {
        this.name = name;
    }
    
    // public string GetName() {
    //     return this.name;
    // }
    //
    // public void SetName(string newName) {
    //     this.name = newName;
    // }
   
}
