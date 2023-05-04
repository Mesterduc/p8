using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Navigation;

public class AddAnimalNavigation : MonoBehaviour
{
    [SerializeField] private Button _GoToTank;
    [SerializeField] private Button _GoToMenu;
    // Start is called before the first frame update
    void Start()
    {
        _GoToTank.onClick.AddListener(() => ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.TankScene));
        _GoToMenu.onClick.AddListener(() => ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.Menu));
    }
}
