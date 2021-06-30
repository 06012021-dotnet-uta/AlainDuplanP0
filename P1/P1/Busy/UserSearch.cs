using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopperContext;

namespace Busy
{
    /// <summary>
    /// handles searching for user, limited to only authorized users
    /// </summary>
    public class UserSearch : IUserSearch
    {
        ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();
        /// <summary>
        /// Searches for users via a query
        /// </summary>
        /// <param name="user">user object containing query fields</param>
        /// <returns>List of user objects</returns>
        public ArrayList listUsers(ModelsDefault.User user)
        {
            ArrayList arr = new ArrayList();
            
            var choices = context.Customers.Where(x => x.CustomerFname.Contains(user.findF) || x.CustomerLname.Contains(user.findL)).ToList();
            if (!choices.Any())
            {
                return arr;
            }
            if(user.findF == "" && user.findL == "")
            {
                choices = context.Customers.ToList();
            }

            foreach(var c in choices)
            {
                ModelsDefault.User temp = new ModelsDefault.User();
                temp.admin = user;
                temp.auth = (int)c.Auth;
                temp.id = c.CustomerId;
                temp.storeId = (int)c.CustomerTop;
                temp.fname = c.CustomerFname;
                temp.lname = c.CustomerLname;
                temp.totalOrders = context.Orders.Where(x => x.CustomerId == temp.id).Count();
                temp.totalSpent = (double)(from oi in context.OrderInventories
                                           join o in context.Orders on oi.OrdersId equals o.OrdersId
                                           join i in context.Items on oi.ItemId equals i.ItemId
                                           where o.CustomerId == temp.id
                                           select oi.Quantity * i.ItemPrice).Sum();
                arr.Add(temp);
            }


            return arr;
        }

    }
}
