using UnityEngine;

namespace magnus.johnson {
    public class DestinationClick : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        { 

        }

        void OnMouseDown()
        {
            GameObject menu = GameObject.Find("UI");
            MenuScript script = menu.GetComponent<MenuScript>();

            script.ShowModal(this.name, transform.position);

            GameObject maincamera = GameObject.Find("MainCamera");
            MainCamera camerascript = maincamera.GetComponent<MainCamera>();

            camerascript.MoveToSelection(transform.position);

        }


    }
}