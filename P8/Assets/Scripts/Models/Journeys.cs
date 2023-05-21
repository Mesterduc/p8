using System.Collections.Generic;

namespace Models {
    public class Journeys {
        private List<Journey> journeys;
        public Journeys() {
            this.journeys = new List<Journey>();
        }

        public void AddJourney(Journey journey) {
            journeys.Add(journey);
        }
        
        public List<Journey> GetJourney() {
            return journeys;
        }
        
        public int JourneyCount() {
            return journeys.Count;
        }

        public Journey FindJourney(int id) {
            foreach (var journey in journeys) {
                if (journey.id == id) {
                    return journey;
                }
            }
            return null;
        }
            
    }
}