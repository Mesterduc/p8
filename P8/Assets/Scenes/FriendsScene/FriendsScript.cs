using System.Collections.Generic;
using System.Linq;
using DataPersistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Scenes.FriendsScene {
    public class FriendsScript : MonoBehaviour, IDataPersistence {
        // set in editor
        [SerializeField] public GameObject Friend;
        [SerializeField] public Transform Friendslist;
        
        // Data
        private List<Friend> Friends;

        void Start() {

            GameObject newFriend;
            for (int i = 0; i < Friends.Count; i++) {
                newFriend = Instantiate(Friend, Friendslist);
                newFriend.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ProfileIcon/" + Friends[i].image);

                // Nested components
                Transform newFriendInfo = newFriend.transform.GetChild(1).transform;
                newFriendInfo.GetChild(0).GetComponent<TMP_Text>().text = "Name: " + Friends[i].name;
                newFriendInfo.GetChild(1).GetComponent<TMP_Text>().text = "Level: " + Friends[i].level;
                newFriendInfo.GetChild(2).GetComponent<TMP_Text>().text =
                    "Achievements: " + Friends[i].numberOfAchievements;
            }

            Destroy(Friend);
        }

        void Update() {
        }

        public void LoadData(GameData data) {
            this.Friends = data.friends;
        }

        public void SaveData(GameData data) {
            // throw new System.NotImplementedException();
        }
    }
}