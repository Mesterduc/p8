using System.Collections.Generic;
using System.Linq;
using DataPersistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace AddAnimal {
public class AddAnimalScript : MonoBehaviour, IDataPersistence
{
    List<Trivia> animalpictures = new List<Trivia>();

    private void Awake()
        {
        
        }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.animalpictures = data.animalpictures;
    }

    public void SaveData(GameData data)
    {
         // throw new System.NotImplementedException();
        data.animalpictures = this.animalpictures;
    }
}}
