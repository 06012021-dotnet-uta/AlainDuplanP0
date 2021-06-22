using System;
using System.Collections.Generic;

#nullable disable

namespace ShopperContext
{
    public partial class OrderInventory
    {
        public int ItemId { get; set; }
        public int OrdersId { get; set; }
        public int Quantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Orders { get; set; }
    }
}
