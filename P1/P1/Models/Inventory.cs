using System;
namespace Models
{
    /// <summary>
    /// Contains item id, quantity and total for data use
    /// </summary>
    public class Inventory
    {

        public int item { get; set; }
        public int quantity { get; set; }
        internal double total { get; set; }


        public Inventory(int item, int quantity, double total)
        {
            this.item = item;
            this.quantity = quantity;
            this.total = total;
        }
    }
}