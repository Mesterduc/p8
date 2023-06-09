using System.Collections.Generic;
using DataPersistence;
using DataStore;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.FriendsScene {
    public class FriendsScript : MonoBehaviour, IDataPersistence {
        // set in editor
        [SerializeField] public GameObject friend;
        [SerializeField] public Transform friendslist;
        [SerializeField] public Button addFriend;
        private string friendIdName;

        // Data
        private List<Friend> Friends;

        private void Awake() {
            DataPersistenceManager.Instance.manualLoadData();
            addFriend.onClick.AddListener(() => {
                Friends.Add(new Friend(friendIdName, 10, 4, "pedro"));
                UpdateUi();
            });
        }

        void Start() {
            for (int i = 0; i < Friends.Count; i++) {
                GameObject newFriend = Instantiate(friend, friendslist);
                // Image
                newFriend.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("ProfileIcon/" + Friends[i].image);
                // Nested components: friend Information
                Transform newFriendInfo = newFriend.transform.GetChild(1).transform;
                newFriendInfo.GetChild(0).GetComponent<TMP_Text>().text = "Name: " + Friends[i].name;
                newFriendInfo.GetChild(1).GetComponent<TMP_Text>().text = "Level: " + Friends[i].level;
                newFriendInfo.GetChild(2).GetComponent<TMP_Text>().text =
                    "Achievements: " + Friends[i].numberOfAchievements;
            }

            friend.SetActive(false);
            // Destroy(friend);
        }

        // bruges af UI til at få input, til at finde friend
        public void ReadStringInput(string id) {
            friendIdName = id;
        }

        void UpdateUi() {
            GameObject newFriend;
            int i = Friends.Count - 1;
            newFriend = Instantiate(friend, friendslist);
            newFriend.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("ProfileIcon/" + Friends[i].image);

            // Nested components
            Transform newFriendInfo = newFriend.transform.GetChild(1).transform;
            newFriendInfo.GetChild(0).GetComponent<TMP_Text>().text = "Name: " + Friends[i].name;
            newFriendInfo.GetChild(1).GetComponent<TMP_Text>().text = "Level: " + Friends[i].level;
            newFriendInfo.GetChild(2).GetComponent<TMP_Text>().text =
                "Achievements: " + Friends[i].numberOfAchievements;
            newFriend.SetActive(true);
        }

        public void LoadData(GameData data) {
            this.Friends = data.friends;
        }

        public void SaveData(GameData data) {
            data.friends = this.Friends;
        }
    }
}