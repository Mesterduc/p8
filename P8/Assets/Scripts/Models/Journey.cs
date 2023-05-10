using System;
using System.Collections.Generic;
using System.Globalization;

namespace Models {
    [Serializable]
    public class Journey {
        public int id;
        public Destination destination;
        public List<string> gallery;
        private DateTime date;

        public Journey(int id, Destination destination) {
            this.id = id;
            this.destination = destination;
            this.gallery = new List<string>();
            this.date = DateTime.Now;
        }
        
        // lave metode til at tilføje mange billeder

        public string GetDateTimeFormated() {
            return date.Date.ToString("dddd dd-MM-yyyy", new CultureInfo("en-US"));
        }

    }
}