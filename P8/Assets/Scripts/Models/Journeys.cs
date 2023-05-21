using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Models {
    public class Journeys {
        public List<Journey> journeys;

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
        public void ReplaceJourney(int id, Journey newJourney) {
            for (int i = 0; i < journeys.Count; i++) {
                if (journeys[i].id == id) {
                    journeys[i] = newJourney;
                }
            }
        }
    }
}