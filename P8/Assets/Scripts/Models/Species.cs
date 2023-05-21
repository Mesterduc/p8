using System.Collections.Generic;

namespace Models {
    public class Species {
        private List<Trivia> species;

        public Species() {
            this.species = new List<Trivia>();
        }

        public List<Trivia> GetSpecies() {
            return species;
        }
        
        public int SpeciesCount() {
            return species.Count;
        }
        
        public void AddSpecie(Trivia trivia) {
            species.Add(trivia);
        }
    }
}