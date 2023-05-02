using UnityEngine;

namespace magnus.johnson {
    [System.Serializable]

    public class Destination
    {
        public string name { get; set; }
        public string information{get; set; }
        public Vector3 position{get; set; }

        public Biome type { get; set; }




        public Destination(string name, string info, Biome biome, Vector3 position)
        {
            this.name = name;
            this.information = info;
            this.type = biome;


            this.position = position;
        }


    }
}
