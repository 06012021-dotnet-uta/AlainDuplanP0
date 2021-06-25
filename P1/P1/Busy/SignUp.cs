using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopperContext;

namespace Busy
{
    public class SignUp
    {
       ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();
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

        public int getTop()
        {
            return context.Stores.Select(x => x.StoreId).Max();
        }

        public int getID()
        {
            return context.Customers.Select(x => x.CustomerId).Max();
        }

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
