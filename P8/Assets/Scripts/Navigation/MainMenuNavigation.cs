using UnityEngine;
using UnityEngine.UI;

namespace Navigation {
    public class MainMenuNavigation : MonoBehaviour {
        [SerializeField] private Button _Menu;
    
        // Start is called before the first frame update
        void Start()
        {
            _Menu.onClick.AddListener(LoadMainMenu);
        
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
