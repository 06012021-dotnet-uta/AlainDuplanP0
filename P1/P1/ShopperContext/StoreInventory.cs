using System;
using System.Collections.Generic;

#nullable disable

namespace ShopperContext
{
    public partial class StoreInventory
    {
        public int ItemId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual Store Store { get; set; }
    }
}
