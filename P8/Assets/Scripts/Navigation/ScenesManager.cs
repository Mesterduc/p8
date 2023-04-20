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
            TankScene,
            AddAnimalsScene,
            CollectionScene,
            FriendsScrene, //obs. fejl i navnet
            GuideScene,
            ProfileScene,
            Friends
        }

        public void LoadScene(Scene scene) {
            SceneManager.LoadScene(scene.ToString());
        }

        public void LoadMenu() {
            SceneManager.LoadScene(Scene.Menu.ToString());
        }

        public void LoadTanks () {
            SceneManager.LoadScene(Scene.TankScene.ToString());
        }

        public void LoadAddAnimal () {
            SceneManager.LoadScene(Scene.AddAnimalsScene.ToString());
        }
        
        //obs. fejl i navnet
        public void LoadFriends () {
            SceneManager.LoadScene(Scene.Friends.ToString());
        }

        public void LoadCollection () {
            SceneManager.LoadScene(Scene.CollectionScene.ToString());
        }

        public void LoadGuides () {
            SceneManager.LoadScene(Scene.GuideScene.ToString());
        }

        public void LoadProfile () {
            SceneManager.LoadScene(Scene.ProfileScene.ToString());
        }
    }
}
