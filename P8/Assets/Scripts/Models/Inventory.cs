using System.Collections.Generic;

namespace Models {
    public class Inventory {
        public List<Item> inventory;

        public Inventory() {
            this.inventory = new List<Item>();
        }
    }
}