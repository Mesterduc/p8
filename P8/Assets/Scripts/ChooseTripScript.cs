using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataPersistence;
using magnus.johnson;
using UnityEngine.UI;
using TMPro;

public class ChooseTripScript : MonoBehaviour, IDataPersistence
{
    private List<Destination> destinations;
    public GameObject content;
    public GameObject tripInfo;
    public GameObject playInfo;
    public GameObject bottomPanel;
    

    void Start()
    {

        if(Hogsmeade.nextTrip == null){
            NoTrip();
        }
        else{
            activeTrip();
        }

    }

    private void activeTrip()
    {
        PopulatePanels();
        OpenWindows();
        
    }
    private void NoTrip()
    {
 
        content.transform.Find("activeTrip").gameObject.SetActive(false);
        content.transform.Find("noTrip").gameObject.SetActive(true);
        content.transform.Find("comingTrip").gameObject.SetActive(false);

    }

    private void PopulatePanels()
    {
        tripInfo.GetComponent<TMP_Text>().text = destinations[Hogsmeade.nextTrip].address;
    }
    private void OpenWindows()
    {
        content.transform.Find("activeTrip").gameObject.SetActive(false);
        content.transform.Find("noTrip").gameObject.SetActive(false);
        content.transform.Find("comingTrip").gameObject.SetActive(true);
        bottomPanel.SetActive(true);
    }







    public void LoadData(GameData data) {
        this.destinations = data.destinations;
}

    public void SaveData(GameData data) {
        data.destinations = this.destinations;
        }
}
