using System.Collections.Generic;
using Animals;

namespace Models {
    public class Inventory {
        private List<Animal> inventory;

        public Inventory() {
            this.inventory = new List<Animal>();
        }

        public void AddInventory(Animal item) {
            inventory.Add(item);
        }

        public List<Animal> GetInventory() {
            return inventory;
        }

        public int InventoryCount() {
            return inventory.Count;
        }
    }
}