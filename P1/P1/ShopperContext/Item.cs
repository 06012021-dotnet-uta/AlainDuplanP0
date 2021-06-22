using System;
using System.Collections.Generic;

#nullable disable

namespace ShopperContext
{
    public partial class Item
    {
        public Item()
        {
            Customers = new HashSet<Customer>();
            OrderInventories = new HashSet<OrderInventory>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<OrderInventory> OrderInventories { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
