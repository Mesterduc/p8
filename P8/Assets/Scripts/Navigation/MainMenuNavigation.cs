using UnityEngine;
using UnityEngine.UI;

namespace Navigation {
    public class MainMenuNavigation : MonoBehaviour {
        [SerializeField] private Button _menu;
    
        // Start is called before the first frame update
        private void Start()
        {
            _menu.onClick.AddListener(LoadMainMenu);
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void LoadMainMenu() {
            ScenesManager.Instance.LoadMenu();
        }
    }
}
