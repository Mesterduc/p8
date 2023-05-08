using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DataPersistence;
using Models;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GalleryScript : MonoBehaviour, IDataPersistence {
    private List<Journey> journeys = new List<Journey>();
    [SerializeField] private Transform placement;

    void Start() {
        for (int i = 0; i < journeys.Count; i++) {
            GameObject prefab = Resources.Load<GameObject>("prefabs/UdflugtPrefab");
            GameObject journeyItem = Instantiate(prefab, placement);
            journeyItem.transform.Find("content/activeTrip/LocationIcon/Title/Text").GetComponent<TMP_Text>().text =
                journeys[i].destination.name;
            journeyItem.transform.Find("content/activeTrip/Date/").GetComponent<TMP_Text>().text =
                // dddd: dag i text
                journeys[i].GetDateTimeFormated();

            // Billeder --------------------------------------------
            Transform gallery = journeyItem.transform.Find("content/activeTrip/GalleryScroller/Mask/Gallery").transform;
            if (Directory.Exists(Application.persistentDataPath + "/" + journeys[i].id)) {
                DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/" + journeys[i].id);
                FileInfo[] info = dir.GetFiles();
                // Debug.Log(info.Length);
                for (int j = 0; j < info.Length; j++) {
                    Debug.Log(info[j].ToString());
                    GameObject image = new GameObject("Image");

                    image.AddComponent<Image>().sprite = LoadSprite(info[j].ToString());
                    image.transform.SetParent(gallery);
                }
            }
            // dir.GetFiles().Length;
            // Application.persistentDataPath + "/" + journeys[i].id;
            // gallery.transform
            // gallery.
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