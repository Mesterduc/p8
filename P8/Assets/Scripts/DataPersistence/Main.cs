using UnityEngine;

namespace DataPersistence {
    public class Main : MonoBehaviour
    {
        // Runs before a scene gets loaded
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadMain()
        {
            GameObject main = GameObject.Instantiate(new GameObject());
            DataPersistenceManager hej = main.AddComponent<DataPersistenceManager>();
            hej.PreLoad();
            GameObject.DontDestroyOnLoad(main);
        }
        // You can choose to add any "Service" component to the Main prefab.
        // Examples are: Input, Saving, Sound, Config, Asset Bundles, Advertisements
    }
}
