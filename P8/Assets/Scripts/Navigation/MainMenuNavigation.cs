using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Navigation {
    public class MainMenuNavigation : MonoBehaviour {
        [SerializeField] private Button _menu;
        
        private void Start() {
            _menu.onClick.AddListener(LoadMainMenu);
        }

        private void LoadMainMenu() {
            ScenesManager.Instance.LoadMenu();
        }
    }
}