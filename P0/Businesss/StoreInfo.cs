using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using P0Context;

namespace Businesss
{   
    /// <summary>
    /// Used to check store info
    /// </summary>
    public class StoreInfo : GHelpers, SHelpers
    {
        ShopperContext context = new ShopperContext();
        /// <summary>
        /// Select a store based on user input
        /// </summary>
        /// <returns>Store object</returns>
        public Model.Store storeSelect()
        {
            Model.Store storeM = new Model.Store();
            
            int SId = checkId();
            P0Context.Store storeC= context.Stores.Where(x => x.StoreId == SId).FirstOrDefault();
            if(storeC == null)
            {
                Console.WriteLine("That ID was invalid, lets try this again :)");
                storeM = storeSelect();
            }
            if(storeC != null)
            {
                storeM = new Model.Store(storeC.StoreName, storeC.StoreLocation, storeC.StoreId);
            }
            Console.WriteLine(displayInfo(storeM));
            return storeM;
        }
        /// <summary>
        /// Display Info about the store
        /// </summary>
        /// <param name="cust">Store object</param>
        /// <returns>String to be printed</returns>
        public string displayInfo(Model.Store cust)
        {
            string output = $"Store's name is {cust.name}. \nStores's ID is {cust.id}.";
            string local;
            if (cust.location != null)
                local = $"Store's is located at {cust.location}.";
            else
                local = "Store has no location data!";
            output += local;
            var orderCount = context.Orders.Where(x => x.StoreId == cust.id).Select(x => x.OrdersId).Count();
            var orderTotal = (from oi in context.OrderInventories
                              join o in context.Orders on oi.OrdersId equals o.OrdersId
                              join i in context.Items on oi.ItemId equals i.ItemId
                              where o.StoreId == cust.id
                              select oi.Quantity * i.ItemPrice).Sum();
            string orders = $"It has a total of {orderCount} orders and a revenue of ${orderTotal} \n";
            output += orders;
            return output;
        }

        /// <summary>
        /// Asks user for an ID to search for store
        /// </summary>
        /// <returns>A valid ID</returns>
        public int checkId()
        {
            Console.WriteLine("Enter Store ID to continue");
            string input = Console.ReadLine();
            int CId;
            bool sucessfulConversion = Int32.TryParse(input, out CId);
            while (!sucessfulConversion)
            {
                Console.WriteLine("Id is in the incorrect format, enter a new one");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out CId);
            }
            return CId;
        }
        /// <summary>
        /// Displays menu and waits for a valid user input
        /// </summary>
        /// <returns>Valid input</returns>
        public int whatNext()
        {
            Console.WriteLine("What would you want to do next?");
            Console.WriteLine("Enter 1: Check inventory");
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
        /// <summary>
        /// Checks if input was an int and loops until valid input is given
        /// </summary>
        /// <param name="input">Input string from ReadLine</param>
        /// <returns>An int input</returns>
        public int isThisAnInt(string input)
        {
            int output;
            bool sucessfulConversion = Int32.TryParse(input, out output);
            while (!sucessfulConversion)
            {
                Console.WriteLine("input is in the incorrect format, enter a new one");
                Console.WriteLine("Enter 1: Check inventory");
                Console.WriteLine("Enter 2: Check past orders");
                Console.WriteLine("Enter 3: Return to menu");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out output);
            }
            return output;
        }
        /// <summary>
        /// Returns full inventory of store
        /// </summary>
        /// <param name="cust">Store we want to check</param>
        /// <returns>string to be printed</returns>
        public string getInventory(Model.Store cust)
        {
            
           var orders = context.StoreInventories.Where(x => x.StoreId == cust.id).ToList();
           if (!orders.Any())
            {
                return "Ooops, looks like you made no orders yet!";
            }
            string ouput = "";
            foreach (var o in orders)
            {
                string name = context.Items.Where(x => x.ItemId == o.ItemId).Select(x => x.ItemName).FirstOrDefault();
                ouput += $"\nItem: {name}(ID: {o.ItemId}), Quantity held: {o.Quantity}";
            }
            return ouput;
        }
        /// <summary>
        /// Gets Order history of a specific store
        /// </summary>
        /// <param name="cust">store Object to be worked on</param>
        /// <returns>string to be printed</returns>
        public string getOrderHistory(Model.Store cust)
        {
            var orders = context.Orders.Where(x => x.StoreId == cust.id).ToList();
            if (!orders.Any())
            {
                return "Ooops, looks like you made no orders yet!";
            }
            string ouput = "";
            foreach (var o in orders)
            {
                string name = context.Customers.Where(x => x.CustomerId == o.CustomerId).Select(x => x.CustomerFname).FirstOrDefault();
                name += $" {context.Customers.Where(x => x.CustomerId == o.CustomerId).Select(x => x.CustomerFname).FirstOrDefault()}";
                var orderTotal = (from oi in context.OrderInventories
                                  join os in context.Orders on oi.OrdersId equals os.OrdersId
                                  join i in context.Items on oi.ItemId equals i.ItemId
                                  where os.StoreId == cust.id && os.OrdersId == o.OrdersId
                                  select oi.Quantity * i.ItemPrice).Sum();
                ouput += $"\nOrder #{o.OrdersId} made on {o.OrdersDateTime} by {name}(ID #{o.CustomerId}). Total spent was {orderTotal}";
            }
            return ouput;
        }
        
    }//class
}//namespace
