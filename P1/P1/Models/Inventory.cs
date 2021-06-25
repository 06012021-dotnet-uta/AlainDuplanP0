using System;
namespace ModelsDefault
{
    /// <summary>
    /// Contains item id, quantity and total for data use
    /// </summary>
    public class Inventory
    {

        public int item { get; set; }
        public int quantity { get; set; }
        internal double price { get; set; }


        public Inventory(int item, int quantity, double price)
        {
            this.item = item;
            this.quantity = quantity;
            this.price = price;
        }
    }
}