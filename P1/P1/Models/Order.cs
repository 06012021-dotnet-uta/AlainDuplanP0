using System;
using System.Collections;
using Microsoft.Extensions.DependencyInjection;


namespace Models
{
    /// <summary>
    /// Holds information on the Order worked on
    /// </summary>
    public class Order
    {

        public int store { get; set; }
        public User customer { get; set; }
        private DateTime time { get; }

        public int id { get; set; }
        //public double total{ get; set; }

        private ArrayList products = new ArrayList();



        public Order()
        {
            store = 0;
            customer = null;

            time = DateTime.Now;

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
                all += (i.total * i.quantity);
            }
            return all;
        }
    }
}