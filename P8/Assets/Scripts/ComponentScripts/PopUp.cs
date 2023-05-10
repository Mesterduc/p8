using System;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentScripts {
    public class PopUp : MonoBehaviour
    {
        [SerializeField] public Button closeButton;
        [SerializeField] public Button addButton;
        [SerializeField] public Button showModal;
        [SerializeField] public GameObject modal;

        private Boolean isHidden = true;

        // Start is called before the first frame update
        private void Start()
        {
            showModal.onClick.AddListener(Show);
            if (closeButton) {
                closeButton.onClick.AddListener(Show);
            }
            if (addButton)
            {
                addButton.onClick.AddListener(Show);
            }
        }
        private void Show()
        {
            modal.SetActive(isHidden);
            isHidden = !isHidden;
        }
    }
}
