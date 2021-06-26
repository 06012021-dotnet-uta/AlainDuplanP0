using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
//using ShopperContext;
using System.Linq;
namespace ModelsDefault
{
    /// <summary>
    /// Object containing User Info upon login
    /// </summary>
    public class User
    {

        public string fname { get; set; }
        public string lname { get; set; }

        [Range(1000, 1099)]
        public int id { get; set; }

        public int storeId { get; set; }

        public int auth { get; set; }

        public int totalOrders { get; set; }

        public double totalSpent { get; set; }

        public string findF { get; set; }

        public string findL { get; set; }

        public User admin { get; set; }

        public string findStore { get; set; }
        public User()
        {
            findF = "";
            findL = "";
            findStore = "";

        }

       /* public User(string fname, string lname)
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
        } */

       /* public User(ShopperContext.ShopperContext context, int CId)
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
        }*/

        

    }

}
