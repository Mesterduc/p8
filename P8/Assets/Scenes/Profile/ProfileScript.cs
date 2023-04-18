using System;
using DataPersistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Profile {
    public class ProfileScript : MonoBehaviour, IDataPersistence {
        public TMP_Text text;
        // Start is called before the first frame update
        void Start() {
            text.text = "My name is Hong";
        }


        public void LoadData(GameData data) {
            // text.text = data
        }

        public void SaveData(GameData data) {
            throw new NotImplementedException();
        }
    }
}
