using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFood : MonoBehaviour
{
    public FoodScript foodScript;

    public void ToggleEnable()
    {
        foodScript.isEnabled = !foodScript.isEnabled;
    }
}
