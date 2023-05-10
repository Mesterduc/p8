using System;
using DataPersistence;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Profile {
    public class ProfileScript : MonoBehaviour, IDataPersistence {
        
        private string _name = "";
        public TMP_Text text;

        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
        }

        void Start() {
            text.text = _name;
        }

        private void Update() {
            text.text = _name;
        }

        public void LoadData(GameData data) {
            this._name = data.playerData.name;
        }

        public void SaveData(GameData data) {
            data.playerData.name = this.name;
        }
    }
}
