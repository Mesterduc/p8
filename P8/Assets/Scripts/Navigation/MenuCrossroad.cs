using UnityEngine;
using UnityEngine.UI;

namespace Navigation {
    public class MenuCrossroad : MonoBehaviour {
        [SerializeField] private Button _tanks;
        [SerializeField] private Button _addAnimal;
        [SerializeField] private Button _friends;
        [SerializeField] private Button _collection;
        [SerializeField] private Button _guides;
        [SerializeField] private Button _profile;
    
        // Start is called before the first frame update
        private void Start()
        {
            _tanks.onClick.AddListener(LoadTanks);
            _addAnimal.onClick.AddListener(LoadAddAnimal);
            _friends.onClick.AddListener(LoadFriends);
            _collection.onClick.AddListener(LoadCollection);
            _guides.onClick.AddListener(LoadGuides);
            _profile.onClick.AddListener(LoadProfile);
        
        }



        private void LoadTanks() {
            ScenesManager.Instance.LoadTanks();
        }

        private void LoadAddAnimal() {
            ScenesManager.Instance.LoadAddAnimal();
        }

        private void LoadFriends() {
            ScenesManager.Instance.LoadFriends();
        }

        private void LoadCollection() {
            ScenesManager.Instance.LoadCollection();
        }

        private void LoadGuides() {
            ScenesManager.Instance.LoadGuides();
        }

        private void LoadProfile() {
            ScenesManager.Instance.LoadProfile();
        }
    }
}
