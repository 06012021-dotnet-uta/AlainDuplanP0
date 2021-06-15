using System;
namespace Model
{
    public class Inventory
    {

        public int item { get; set; }
        public int quantity { get; set; }
        public double total { get; set; }


        public Inventory(int item, int quantity, double total)
        {
            this.item = item;
            this.quantity = quantity;
            this.total = total;
        }
    }
}
