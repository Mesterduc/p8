using System;
using System.Collections.Generic;
using magnus.johnson;

namespace Models {
    [System.Serializable]
    public class Gallery {
        private Destination destination;
        public List<string> gallery;
        private DateTime date;

        public Gallery(Destination destination) {
            this.destination = destination;
            this.gallery = new List<string>();
            this.date = DateTime.Now.Date;
        }
        
        // lave metode til at tilføje mange billeder

    }
}