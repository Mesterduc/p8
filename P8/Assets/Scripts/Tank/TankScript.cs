using System;
using JetBrains.Annotations;
using Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace Tank {
    public class TankScript : MonoBehaviour {
        [SerializeField] private Button _PrevOrAchievementsScene;

        void Start() {
            _PrevOrAchievementsScene.onClick.AddListener(() =>
                ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.AchievementsScene));
        }
    }
}