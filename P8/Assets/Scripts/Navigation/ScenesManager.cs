using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Navigation {
    public class ScenesManager : MonoBehaviour {
        private static bool destroyed = false;
        private static ScenesManager instance;
        private int lastScene;

        public static ScenesManager Instance {
            get {
                if (instance == null) {
                    // Search for existing instance.
                    instance = (ScenesManager)FindObjectOfType(typeof(ScenesManager));

                    // Create new instance if one doesn't already exist.
                    if (instance == null) {
                        // Need to create a new GameObject to attach the singleton to.
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<ScenesManager>();
                        singletonObject.name = typeof(SceneManager).ToString() + " (Singleton)";

                        // Make instance persistent.
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return instance;
            }
        }

        public enum Scene {
            Menu,
            TankScene,
            AddAnimalsScene,
            Gallery,
            ChooseTrip,
            PlayTrip,
            CameraScene,

        }

        public void LoadSceneName(Scene scene) {
            Instance.lastScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(scene.ToString());
        }

        public void LoadSceneIndex(int index) {
            Instance.lastScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }

        public void LoadPreviousScene() {
            SceneManager.LoadScene(Instance.lastScene);
        }

        private void Awake() {
            lastScene = 0;
        }

        private void OnApplicationQuit() {
            destroyed = true;
        }
    }
}