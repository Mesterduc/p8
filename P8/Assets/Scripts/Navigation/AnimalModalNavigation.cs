using UnityEngine;
using UnityEngine.UI;

namespace Navigation {
    public class AnimalModalNavigation : MonoBehaviour
    {
        [SerializeField] private Button gallery;
        [SerializeField] private Button close;
        [SerializeField] private GameObject self;

        private void Start() {
            gallery.onClick.AddListener(() => ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.Gallery));
            close.onClick.AddListener(() => Destroy(self));
        }
    }
}
