using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player {
    private string name;

    public Player(string name) {
        this.name = name;
    }

    public string GetName() {
        return this.name;
    }

    public void SetName(string newName) {
        this.name = newName;
    }
}