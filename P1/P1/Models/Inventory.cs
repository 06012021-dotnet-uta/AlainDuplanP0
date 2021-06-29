using System;
namespace ModelsDefault
{
    /// <summary>
    /// Contains item id, quantity and total for data use
    /// </summary>
    public class Inventory
    {
        public int id { get; set; }

        public string name { get; set; }
        public int item { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        public string descr { get; set; }

        public int store { get; set; }

        public int adder { get; set; }
        public int order { get; set; }
     


        public Inventory() { }
        public Inventory(int item, int quantity, double price)
        {
            this.item = item;
            this.quantity = quantity;
            this.price = price;
        }
    }
}