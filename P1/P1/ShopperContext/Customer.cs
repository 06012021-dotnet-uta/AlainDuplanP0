using System;
using System.Collections.Generic;

#nullable disable

namespace ShopperContext
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerFname { get; set; }
        public string CustomerLname { get; set; }
        public int? CustomerTop { get; set; }
        public int? Auth { get; set; }

        public virtual Item CustomerTopNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
