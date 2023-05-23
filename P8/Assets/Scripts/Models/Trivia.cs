using System.Collections.Generic;

namespace Models {
    public class Trivia {
        private List<Species> species;

        public Trivia() {
            this.species = new List<Species>();
        }

        public List<Species> GetSpecies() {
            return species;
        }
        
        public int SpeciesCount() {
            return species.Count;
        }
        
        public void AddSpecie(Species species) {
            this.species.Add(species);
        }
    }
}