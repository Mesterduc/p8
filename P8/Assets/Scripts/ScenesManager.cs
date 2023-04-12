using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {
    public static ScenesManager Instance;

    private void Awake() {
        Instance = this;
    }
    
    public enum Scene {
        MainMenu,
        AddAnimal,
        Colletions,
        Friends,
        Guides
    }

    public void LoadScene(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
}
