using System.Collections.Generic;
using System.IO;
using DataPersistence;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GalleryScript : MonoBehaviour, IDataPersistence {
    private List<Journey> journeys = new List<Journey>();
    [SerializeField] private Transform placement;

    private void Awake() {
        DataPersistenceManager.Instance.manualLoadData();
    }

    void Start() {
        foreach (var journey in journeys) {
            GameObject prefab = Resources.Load<GameObject>("prefabs/UdflugtPrefab");
            GameObject journeyItem = Instantiate(prefab, placement);
            journeyItem.transform.Find("content/activeTrip/LocationIcon/Title/Text").GetComponent<TMP_Text>().text =
                journey.destination.name;
            journeyItem.transform.Find("content/activeTrip/Date/").GetComponent<TMP_Text>().text =
                // dddd: dag i text
                journey.GetDateTimeFormated();

            // Billeder --------------------------------------------
            Transform gallery = journeyItem.transform.Find("content/activeTrip/GalleryScroller/Mask/Gallery").transform;
            if (Directory.Exists(Application.persistentDataPath + "/" + journey.id)) {
                foreach (var galleryPath in journey.gallery) {
                    GameObject image = new GameObject("Image");
                    image.transform.localScale -= new Vector3(0.36f, 0.36f, 0.36f);
                    image.AddComponent<Image>().sprite = LoadSprite(galleryPath);
                    image.transform.SetParent(gallery);
                }
            }
        }
    }

    private Sprite LoadSprite(string path) {
        // læser billedet og conventere det til bytes
        byte[] bytes = System.IO.File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(1, 1);
        // laver en texture ud af byes fra billedet
        texture.LoadImage(bytes);
        // putter en texture(vores billede) på en sprite 
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        // return vores nye sprite
        return sprite;
    }

    public void LoadData(GameData data) {
        this.journeys = data.journeys;
    }

    public void SaveData(GameData data) {
        data.journeys = this.journeys;
    }
}