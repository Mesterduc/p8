using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Navigation;

public class ToMap : MonoBehaviour
{
    public void GoToMap()
    {
        ScenesManager.Instance.LoadSceneName(ScenesManager.Scene.Menu);
    }
}
