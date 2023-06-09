using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts {
    public class PopupMenu : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] Button closeUIButton;

        public static PopupMenu Instance;

        void Awake () {
            Instance = this;

            closeUIButton.onClick.RemoveAllListeners ();
            closeUIButton.onClick.AddListener (Hide);
        }

        public void Show () {
            canvas.SetActive (true);
        }

        public void Hide () {
            canvas.SetActive (false);
        }
    }
}

   

