using System;
using System.Collections.Generic;
using System.Globalization;
using magnus.johnson;

namespace Models {
    [System.Serializable]
    public class Journey {
        public int id;
        public string destinationName;
        public List<string> gallery;
        private DateTime date;

        public Journey(int id, string destinationName) {
            this.id = id;
            this.destinationName = destinationName;
            this.gallery = new List<string>();
            this.date = DateTime.Now.Date;
        }
        
        // lave metode til at tilføje mange billeder

        public string GetDateTimeFormated() {
            return date.ToString("dddd dd-MM-yyyy", new CultureInfo("en-US"));
        }

    }
}