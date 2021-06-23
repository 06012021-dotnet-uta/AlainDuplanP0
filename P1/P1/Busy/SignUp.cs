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
            await context.Customers.AddAsync(new Customer
            {
                CustomerFname = fname,
                CustomerLname = lname,
                CustomerTop = top
            });
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
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
    }
}
