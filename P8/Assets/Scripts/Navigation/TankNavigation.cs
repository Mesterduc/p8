using System.Collections;
using System.Collections.Generic;
using Navigation;
using UnityEngine;
using UnityEngine.UI;

public class TankNavigation : MonoBehaviour {
    [SerializeField] private Button _menu;

    void Start() {
        _menu.onClick.AddListener(() => ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.Menu));
    }
}