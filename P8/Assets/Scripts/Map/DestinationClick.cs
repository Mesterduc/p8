using DataStore;
using UnityEngine;

namespace Map {
    public class DestinationClick : MonoBehaviour
    {
        void OnMouseDown()
        {
            GameObject menu = GameObject.Find("UI");
            MapManager script = menu.GetComponent<MapManager>();

            script.ShowModal(this.name, transform.position);

            GameObject maincamera = GameObject.Find("MainCamera");
            MainCamera camerascript = maincamera.GetComponent<MainCamera>();

            camerascript.MoveToSelection(transform.position);

            Hogsmeade.nextTrip = int.Parse(this.name);
            Debug.Log(Hogsmeade.nextTrip);

        }


    }
}