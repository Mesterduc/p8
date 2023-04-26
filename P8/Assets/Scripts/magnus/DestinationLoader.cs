using System.Collections.Generic;
using DataPersistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.FriendsScene
{
    public class DestinationLoader : MonoBehaviour, IDataPersistence
    {
        // set in editor
        [SerializeField] private GameObject destinationPrefab; 
        [SerializeField] private Transform destinationList;
        private string destinationID;

        // Data
        private List<Destination> destinations; 

        private void Awake()
        {
            UpdateUi();
        }

        void Start()
        {
            for (int i = 0; i < destinations.Count; i++)
            {
                GameObject newDestination = Instantiate(destinationPrefab, destinationList); 
                // Image
                newDestination.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("DestinationIcon/" + destinations[i].image);
                // Nested components: destination information
                Transform newDestinationInfo = newDestination.transform.GetChild(1).transform;
                newDestinationInfo.GetChild(0).GetComponent<TMP_Text>().text = destinations[i].name;
                newDestinationInfo.GetChild(1).GetComponent<TMP_Text>().text = destinations[i].information;
                newDestinationInfo.GetChild(2).GetComponent<TMP_Text>().text = destinations[i].biome; 
            }
        }

        public void ReadStringInput(string id)
        {
            destinationID = id;
        }

        void UpdateUi()
        {
            GameObject newDestination;
            int i = destinationList.Count - 1;
            newDestination = Instantiate(destinationPrefab, destinationList); 
            newDestination.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("DestinationIcon/" + destinations[i].image);

            // Nested components
            Transform newDestinationInfo = newDestination.transform.GetChild(1).transform;
            newDestinationInfo.GetChild(0).GetComponent<TMP_Text>().text = destinations[i].name;
            newDestinationInfo.GetChild(1).GetComponent<TMP_Text>().text = destinations[i].information;
            newDestinationInfo.GetChild(2).GetComponent<TMP_Text>().text = destinations[i].biome; 
        }

        public void LoadData(GameData data)
        {
            this.destinations = data.destinations; 
        }

        public void SaveData(GameData data)
        {
            // throw new System.NotImplementedException();
            data.destinationList = this.destinationList;
        }
    }
}