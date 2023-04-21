using System;
using System.Collections;
using System.Collections.Generic;
using DataPersistence;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] public Button closeButton;
    [SerializeField] public Button addButton;
    [SerializeField] public Button showModal;
    [SerializeField] public GameObject modal;
    
    private Boolean isHidden = true;

    // Start is called before the first frame update
    private void Awake() {
        showModal.onClick.AddListener(Show);
        closeButton.onClick.AddListener(Show);
        addButton.onClick.AddListener(Show);
    }
    private void Show() 
    {
        modal.SetActive(isHidden);
        isHidden = !isHidden;
    }
}
