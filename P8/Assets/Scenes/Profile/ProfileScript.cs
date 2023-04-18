using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Profile {
    public class ProfileScript : MonoBehaviour {
        public TMP_Text text;
        // Start is called before the first frame update
        void Start() {
            text.text = "My name is Hong";
        }
    }
}
