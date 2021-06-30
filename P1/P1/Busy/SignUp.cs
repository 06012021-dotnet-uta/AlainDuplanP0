using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopperContext;

namespace Busy
{
    /// <summary>
    /// Handles user login and signing up
    /// </summary>
    public class SignUp : ISignUP
    {
       ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="fname">First name</param>
        /// <param name="lname">Last Name</param>
        /// <param name="top">Recomended store</param>
        /// <returns>True if user was succeffuly created</returns>
        public async Task<bool> registerUser(string fname, string lname, int top)
        {
            Customer cust = new Customer();

            cust.CustomerFname = fname;
            cust.CustomerLname = lname;
            cust.CustomerTop = top;
            

            await context.Customers.AddAsync(cust);

            try
            {
                await context.SaveChangesAsync();
            }
            catch
            {
                //Console.WriteLine(ex); 
                return false;
            }
           
            return true;
        }
        /// <summary>
        /// Gets id of newest created user
        /// </summary>
        /// <returns></returns>
        public int getID()
        {
            return context.Customers.Select(x => x.CustomerId).Max();
        }
        /// <summary>
        /// Checks if user id is false
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>true if user id exists</returns>
        public bool checkID(int id)
        {
            Customer cust = context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            ModelsDefault.User user = new ModelsDefault.User();
            if (cust == null)
            {
                return false;
            }
            try
            {
                user.fname = cust.CustomerFname;
            }
            catch(System.NullReferenceException)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Fills in fields of a user item
        /// </summary>
        /// <param name="user">user item that contains a user id</param>
        /// <returns>fully built user</returns>
        public ModelsDefault.User getUser(ModelsDefault.User user)
        {
            Customer cust = context.Customers.Where(x => x.CustomerId == user.id).FirstOrDefault();
            user.fname = cust.CustomerFname;
            user.lname = cust.CustomerLname;
            user.storeId = (int)cust.CustomerTop;
            user.auth = (int)cust.Auth;
            user.totalOrders = context.Orders.Where(x => x.CustomerId == user.id).Count();
            user.totalSpent = (double)(from oi in context.OrderInventories
                               join o in context.Orders on oi.OrdersId equals o.OrdersId
                               join i in context.Items on oi.ItemId equals i.ItemId
                               where o.CustomerId == user.id
                               select oi.Quantity * i.ItemPrice).Sum();

            return user;
        }
    }
}
