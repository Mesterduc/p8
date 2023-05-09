using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenSelectedGame : MonoBehaviour
{
    public GameObject dyrepaneler;
    private int current;

    public void Start()
    {
        current = 0;
        NextAnimal(0);
    }

    public void NextAnimal(int direction)
    {
            dyrepaneler.transform.GetChild(current).gameObject.SetActive(false);
            current = current + direction;
            dyrepaneler.transform.GetChild(current).gameObject.SetActive(true);
    }

}
