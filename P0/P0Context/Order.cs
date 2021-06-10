using System;
using System.Collections.Generic;

#nullable disable

namespace P0Context
{
    public partial class Order
    {
        public Order()
        {
            OrderInventories = new HashSet<OrderInventory>();
        }

        public int OrdersId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrdersDateTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderInventory> OrderInventories { get; set; }
    }
}
