using System.Collections;
using System.Collections.Generic;
using Navigation;
using UnityEngine;
using UnityEngine.UI;

public class TankNavigation : MonoBehaviour
{
    [SerializeField] private Button _menu;
    [SerializeField] private Button _achievements;
    // Start is called before the first frame update
    void Start()
    {
        _achievements.onClick.AddListener(() => ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.AchievementsScene));
        // if (_menu)
        // {
            _menu.onClick.AddListener(() => ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.Menu));
        // }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
