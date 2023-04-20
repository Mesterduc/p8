using System.Collections.Generic;
using System.Linq;
using DataPersistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.FriendsScene {
    public class FriendsScript : MonoBehaviour, IDataPersistence {
        [SerializeField]
        public GameObject Friend;
        [SerializeField]
        public Transform Friendslist;

        private List<Friend> Friends;
        void Start() {
            GameObject newFriend;
            for (int i = 0; i < Friends.Count; i++) {
                newFriend = Instantiate(Friend, Friendslist);
                // TODO: Image
                Transform newFriendImage = newFriend.transform.GetChild(1);
                
                // Nested components
                Transform newFriendInfo = newFriend.transform.GetChild(1).transform;
                newFriendInfo.GetChild(0).GetComponent<TMP_Text>().text = "Name: " + Friends[i].name;
                newFriendInfo.GetChild(1).GetComponent<TMP_Text>().text = "Level: " + Friends[i].level;
                newFriendInfo.GetChild(2).GetComponent<TMP_Text>().text = "Achievements: " + Friends[i].numberOfAchievements;
                
                

            }
            Destroy(Friend);
        
        }

        void Update()
        {
        
        }

        public void LoadData(GameData data) {
            this.Friends = data.friends;
        }

        public void SaveData(GameData data) {
            // throw new System.NotImplementedException();
        }
    }
}
