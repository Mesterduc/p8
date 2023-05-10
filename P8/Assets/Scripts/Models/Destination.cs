using UnityEngine;

namespace Models {
    [System.Serializable]

    public class Destination
    {
        public string name { get; set; }
        public string information{get; set; }
        public Vector3 position{get; set; }
        public string address {get; set;}
        public Biome type { get; set; }




        public Destination(string name, string info, Biome biome, Vector3 position, string address)
        {
            this.name = name;
            this.information = info;
            this.type = biome;
            this.address = address;

            this.position = position;
        }


    }
}
