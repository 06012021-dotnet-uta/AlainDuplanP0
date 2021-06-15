using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P0Context;
using Model;

namespace Businesss
{
    public class UserInfo
    {
        ShopperContext context = new ShopperContext();

        public int whatNext()
        {
            Console.WriteLine("What would you want to do next?");
            Console.WriteLine("Enter 1: Check user stats");
            Console.WriteLine("Enter 2: Check past orders");
            Console.WriteLine("Enter 3: Return to menu");
            string input = Console.ReadLine();
            int output = isThisAnInt(input);
            if (output > 3 || output < 1)
            {
                Console.WriteLine("Input was not an option");
                output = whatNext();
            }
            return output;
        }

        private int isThisAnInt(string input)
        {
            int output;
            bool sucessfulConversion = Int32.TryParse(input, out output);
            while (!sucessfulConversion)
            {
                Console.WriteLine("input is in the incorrect format, enter a new one");
                Console.WriteLine("Enter 1: Check user stats");
                Console.WriteLine("Enter 2: Check past orders");
                Console.WriteLine("Enter 3: Return to menu");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out output);
            }
            return output;
        }
        public string displayInfo(User cust)
        {
            string output = $"User's name is {cust.fname} {cust.lname}. \nUser's ID is {cust.id}";
            string topstore = getTopStore(cust);
            output += topstore;
            var orderCount = context.Orders.Where(x => x.CustomerId == cust.id).Select(x => x.OrdersId).Count();
            var orderTotal = (from oi in context.OrderInventories
                              join o in context.Orders on oi.OrdersId equals o.OrdersId
                              join i in context.Items on oi.ItemId equals i.ItemId
                              where o.CustomerId == cust.id
                              select oi.Quantity * i.ItemPrice).Sum();
            string orders = $"\nYou have many a total of {orderCount} orders and spent ${orderTotal}";
            output += orders;
            return output;
        }

        public string getTopStore(User cust)
        {
            if(cust.storeId == 0)
                {
                //bool check = (context.Orders.Where(x => x.CustomerId == cust.id).Select(x => x.StoreId).ToList()).Count > 0;
                int given = 0;
                try
                {
                    given = context.Orders.Where(x => x.CustomerId == cust.id).Select(x => x.StoreId).Max();
                }
                catch(System.InvalidOperationException)
                {
                    return "\nNo recommended store could be listed, try making some orders!";
                }
                cust.storeId = given;
            }
            Customer up = context.Customers.Where(x => x.CustomerId == cust.id).FirstOrDefault();
            up.CustomerTop = cust.storeId;
            context.SaveChanges();
            
             string name = context.Stores.Where(x => x.StoreId == cust.storeId).Select(x => x.StoreName).FirstOrDefault();
             int id = context.Stores.Where(x => x.StoreId == cust.storeId).Select(x => x.StoreId).FirstOrDefault();
             return $"\nYour recommended store is {name} with a store id of {id}";
          
        }
        public string getOrderHistory(User cust)
        {
            var orders = context.Orders.Where(x => x.CustomerId == cust.id).ToList();
            if (!orders.Any())
            {
                return "Ooops, looks like you made no orders yet!";
            }
            string ouput = "";
            foreach(var o in orders)
            {
                string name = context.Stores.Where(x => x.StoreId == o.StoreId).Select(x => x.StoreName).FirstOrDefault();
                var orderTotal = (from oi in context.OrderInventories
                                  join os in context.Orders on oi.OrdersId equals os.OrdersId
                                  join i in context.Items on oi.ItemId equals i.ItemId
                                  where os.CustomerId == cust.id && os.OrdersId == o.OrdersId
                                  select oi.Quantity * i.ItemPrice).Sum();
                ouput += $"\nOrder #{o.OrdersId} made on {o.OrdersDateTime} at {name}(store #{o.StoreId}). Total spent was {orderTotal}";
            }
            return ouput;
        }

        
        
    }//class
}// namespace
