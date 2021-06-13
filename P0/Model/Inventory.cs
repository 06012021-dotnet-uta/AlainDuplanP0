using System;
namespace Model
{
    public class Inventory
    {

        public Item item { get; set; }
        public int quantity { get; set; }


        public Inventory(Item item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
    }
}