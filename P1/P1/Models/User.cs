using System;
using System.Collections;
using ShopperContext;
using System.Linq;
namespace Models
{
    /// <summary>
    /// Object containing User Info upon login
    /// </summary>
    public class User
    {

        public string fname { get; set; }
        public string lname { get; set; }
        public int id { get; set; }

        public int storeId { get; set; }

        public int auth { get; set; }

        public User(string fname, string lname)
        {
            if (fname == "")
            {
                this.fname = "defaultFName";
            }
            else { this.fname = fname; }
            if (lname == "")
            {
                this.lname = "defaultLName";
            }
            else { this.lname = lname; }
            id = 0;
            auth = 0;
        }

        public User(ShopperContext.ShopperContext context, int CId)
        {
            this.fname = context.Customers.Where(x => x.CustomerId == CId).Select(x => x.CustomerFname).FirstOrDefault();
            this.lname = context.Customers.Where(x => x.CustomerId == CId).Select(x => x.CustomerLname).FirstOrDefault();
            var top = context.Customers.Where(x => x.CustomerId == CId).Select(x => x.CustomerTop).FirstOrDefault();
            if (top == null)
                storeId = 0;
            else
                storeId = (int)top;
            this.id = CId;
            auth = (int)context.Customers.Where(x => x.CustomerId == CId).Select(x => x.Auth).FirstOrDefault();
        }

    }

}
