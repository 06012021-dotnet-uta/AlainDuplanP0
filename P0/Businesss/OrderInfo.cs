using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using P0Context;

namespace Businesss
{
    public class OrderInfo
    {
        ShopperContext context = new ShopperContext();
        public int whatNext()
        {
            Console.WriteLine("What would you want to do next?");
            Console.WriteLine("Enter 1: Check past order");
            Console.WriteLine("Enter 2: Create new order");
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
                Console.WriteLine("Enter 1: Check past order");
                Console.WriteLine("Enter 2: Create new order");
                Console.WriteLine("Enter 3: Return to menu");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out output);
            }
            return output;
        }
        public string getOrderHistory(Model.Order cust)
        {
            var orders = context.Orders.Where(x =>x.CustomerId == cust.customer.id).ToList();
            if (!orders.Any())
            {
                return "Ooops, looks you made no orders yet";
            }
            string ouput = "";
            foreach (var o in orders)
            {
                string name = context.Stores.Where(x => x.StoreId == o.StoreId).Select(x => x.StoreName).FirstOrDefault();
                var orderTotal = (from oi in context.OrderInventories
                                  join os in context.Orders on oi.OrdersId equals os.OrdersId
                                  join i in context.Items on oi.ItemId equals i.ItemId
                                  where os.CustomerId == cust.customer.id && os.OrdersId == o.OrdersId
                                  select oi.Quantity * i.ItemPrice).Sum();
                ouput += $"\nOrder #{o.OrdersId} made on {o.OrdersDateTime} at {name}(store #{o.StoreId}). Total spent was {orderTotal}";
            }
            return ouput;
        }

        public Model.Order storeSelect()
        {
            Model.Order orderM = new Model.Order();
           
            int SId = checkId();
            P0Context.Order  orderC = context.Orders.Where(x => x.OrdersId == SId).FirstOrDefault();
            if(orderC == null)
            {
                Console.WriteLine("That ID was invalid, lets try this again :)");
                orderM = storeSelect();
            }
            if(orderC != null)
            {
                orderM = new Model.Order();
                orderM.id = orderC.OrdersId;
            }
                      
            return orderM;
        }
        private int checkId()
        {
            Console.WriteLine("Enter Order ID to continue");
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
        public string getInventory(Model.Order cust)
        {

            var orders = context.OrderInventories.Where(x => x.OrdersId == cust.id).ToList();
            if (!orders.Any())
            {
                return "Ooops, looks you spent nothing in this order";
            }
            string ouput = "";
            foreach (var o in orders)
            {
                string name = context.Items.Where(x => x.ItemId == o.ItemId).Select(x => x.ItemName).FirstOrDefault();
                var price = context.Items.Where(x => x.ItemId == o.ItemId).Select(x => x.ItemPrice).FirstOrDefault();
                ouput += $"\nItem: {name}(ID: {o.ItemId}), Quantity held: {o.Quantity}, totaling {price * o.Quantity}";
            }
            return ouput;
        }
    }
}
