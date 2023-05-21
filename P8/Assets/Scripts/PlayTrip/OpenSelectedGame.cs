using UnityEngine;

namespace PlayTrip {
    public class OpenSelectedGame : MonoBehaviour {
        public GameObject dyrepaneler;
        private int current;

        public void Start() {
            dyrepaneler.transform.GetChild(0).gameObject.SetActive(true);
            current = 0;
        }

        public void NextAnimal(int direction) {
            dyrepaneler.transform.GetChild(current).gameObject.SetActive(false);
            current = current + direction;
            if (current >= dyrepaneler.transform.childCount) {
                current = 0;
            }
            else if (current < 0) {
                current = dyrepaneler.transform.childCount - 1;
            }
            dyrepaneler.transform.GetChild(current).gameObject.SetActive(true);
        }
    }
}