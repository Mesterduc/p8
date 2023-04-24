using System;
using System.Collections.Generic;
using DataPersistence;
using JetBrains.Annotations;
using Navigation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tank
{
    public class TankScript : MonoBehaviour, IDataPersistence
    {
        [SerializeField] private Button _PrevOrAchievementsScene;
        private List<Fish> fishes = new List<Fish>();
        [SerializeField] private Transform placement;

        private GameObject fishPrefab;

        void Start()
        {
            _PrevOrAchievementsScene.onClick.AddListener(() =>
                ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.AchievementsScene));





            fishPrefab = new GameObject("fish");
            // fishPrefab.name = ;

            for (int i = 0; i < fishes.Count; i++)
            {
                GameObject newFish = Instantiate(fishPrefab, placement);
                newFish.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Fish/" + "Sild");
                newFish.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Fish/SildAnimator");
                newFish.AddComponent<RectTransform>();
                

            }
        }

        public void LoadData(GameData data)
        {
            this.fishes = data.fishes;
        }

        public void SaveData(GameData data)
        {
            data.fishes = this.fishes;
        }
    }
}