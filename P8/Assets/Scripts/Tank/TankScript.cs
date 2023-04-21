using System;
using JetBrains.Annotations;
using Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace Tank {
    public class TankScript : MonoBehaviour
    {
        [SerializeField] private Button _menu;
        [SerializeField] private Button _achievements;
        [SerializeField] [CanBeNull] private Button _editTank;
        // Start is called before the first frame update
        private void Awake() {
            _menu.onClick.AddListener(() => ScenesManager.Instance.LoadMenu());
            _achievements.onClick.AddListener(() => ScenesManager.Instance.LoadAchievements());
        }
        // void Start()
        // {
        //
        // }

        // Update is called once per frame
        // void Update()
        // {
        //
        // }
    }
}
