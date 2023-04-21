using System.Collections;
using System.Collections.Generic;
using Navigation;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsScript : MonoBehaviour
{
    [SerializeField] private Button _tank;
    void Start()
    {
        _tank.onClick.AddListener(() => ScenesManager.Instance.LoadTanks());
        
    }
}
