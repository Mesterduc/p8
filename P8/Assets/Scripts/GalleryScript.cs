using System.Collections;
using System.Collections.Generic;
using DataPersistence;
using Models;
using UnityEngine;

public class GalleryScript : MonoBehaviour, IDataPersistence {
    private List<Gallery> galleries = new List<Gallery>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data) {
        this.galleries = data.galleries;
    }

    public void SaveData(GameData data) {
        data.galleries = this.galleries;
    }
}
