using System;
using System.Collections;
//using Microsoft.Extensions.DependencyInjection;


namespace ModelsDefault
{
    /// <summary>
    /// Holds information on the Order worked on
    /// </summary>
    public class Order
    {

        public int store { get; set; }
        public int custId { get; set; }
        public DateTime time { get; set; }

        public double total { get; set; }
        public int id { get; set; }
        //public double total{ get; set; }

        private ArrayList products = new ArrayList();



        public Order()
        {
            

        }
        /// <summary>
        /// Adds item to inventory
        /// </summary>
        /// <param name="item">Inventory item of item id, quantity and total</param>
        public void addItem(Inventory item)
        {
            products.Add(item);
        }
        /// <summary>
        /// Retrieves items in the order
        /// </summary>
        /// <returns>Items in order</returns>
        public ArrayList getOrder()
        {
            return products;
        }
        /// <summary>
        /// Gets the total of all the items in the inventory
        /// </summary>
        /// <returns>Total cost</returns>
        public double getTotal()
        {
            double all = 0;
            foreach (Inventory i in products)
            {
                all += (i.price * i.quantity);
            }
            return all;
        }
    }
}