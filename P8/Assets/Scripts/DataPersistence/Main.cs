using UnityEngine;

namespace DataPersistence {
    public class Main : MonoBehaviour
    {
        // Runs before a scene gets loaded
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadMain()
        {
            GameObject main = GameObject.Instantiate(new GameObject());
            DataPersistenceManager data = main.AddComponent<DataPersistenceManager>();
            data.PreLoad();
            GameObject.DontDestroyOnLoad(main);
        }
    }
}
