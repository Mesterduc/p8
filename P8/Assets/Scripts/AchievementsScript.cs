using System.Collections;
using System.Collections.Generic;
using Navigation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AchievementsScript : MonoBehaviour
{
    [SerializeField] private Button _tank;
    [SerializeField] private Button _menu;

    void Start()
    {
        _menu.onClick.AddListener(() => ScenesManager.Instance.LoadPreviousScene());
        _tank.onClick.AddListener(() => ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.Friends));

    }
}
