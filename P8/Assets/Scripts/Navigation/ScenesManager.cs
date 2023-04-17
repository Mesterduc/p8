using UnityEngine;
using UnityEngine.SceneManagement;

namespace Navigation {
    public class ScenesManager : MonoBehaviour {
        public static ScenesManager Instance;

        private void Awake() {
            Instance = this;
        }
    
        public enum Scene {
            Menu,
            AddAnimal,
            Colletions,
            Friends,
            Guides
        }

        public void LoadScene(Scene scene) {
            SceneManager.LoadScene(scene.ToString());
        }

        public void LoadMenu() {
            SceneManager.LoadScene(Scene.Menu.ToString());
        }
    }
}
