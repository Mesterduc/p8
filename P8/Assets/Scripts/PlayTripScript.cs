using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Models;
using magnus.johnson;
using DataPersistence;

public class PlayTripScript : MonoBehaviour, IDataPersistence {
    [SerializeField] private List<Journey> journeys = new List<Journey>();

    [SerializeField] private List<Destination> destinations = new List<Destination>();


     private void Awake() {
        DataPersistenceManager.Instance.manualLoadData();
    }

    // Start is called before the first frame update
    void Start() {
        
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public IEnumerator SaveImage() {
        yield return new WaitForSecondsRealtime(2);
    }

    // sker noget her
    public void LoadData(GameData data) {
        this.destinations = data.destinations;
        this.journeys = data.getList();
        
    }

    public void SaveData(GameData data) {
        data.destinations = this.destinations;
        data.setList(this.journeys);
    }
}