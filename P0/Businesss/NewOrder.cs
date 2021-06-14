using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P0Context;
using Model;

namespace Businesss
{
    public class NewOrder
    {
        ShopperContext context = new ShopperContext();
        public Model.Order storeSelect()
        {
            Model.Order orderM = new Model.Order();

            int SId = checkId();
            P0Context.Store orderC = context.Stores.Where(x => x.StoreId == SId).FirstOrDefault();
            if (orderC == null)
            {
                Console.WriteLine("That ID was invalid, lets try this again :)");
                orderM = storeSelect();
            }
            if (orderC != null)
            {
                orderM = new Model.Order();
                orderM.id = orderC.StoreId;
                Console.WriteLine($"You selected to shop at {orderC.StoreName}(#{orderC.StoreId}) at {orderC.StoreLocation}");
            }

            return orderM;
        }
        private int checkId()
        {
            Console.WriteLine("Enter Store ID to shop at");
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

        public bool takeItem(Model.Order order)
        {
            Console.WriteLine("Enter an item to search");
            string Fname = Console.ReadLine().Trim();
            var items = (from s in context.StoreInventories
                         join i in context.Items on s.ItemId equals i.ItemId
                         where s.StoreId == order.store && i.ItemName.Contains(Fname)                        
                         select s.ItemId);
                
            if (!items.Any() || items.Count() == 0)
            {
                Console.WriteLine("This store has no items");
                return false;
            }
            foreach(var i in items)
            {
                ShopperContext c = new ShopperContext();
                var price = c.Items.Where(x => x.ItemId == i)
                    .Select(x => x.ItemPrice)
                    .FirstOrDefault();
                var name = c.Items.Where(x => x.ItemId == i).Select(x => x.ItemName).FirstOrDefault();
                var quantity = c.StoreInventories.Where(x => x.ItemId == i && x.StoreId == order.store).Select(x => x.Quantity).FirstOrDefault();
                Console.WriteLine($"\n{quantity} {name} found for ${price} each. Its ID is {i}");
                //Console.WriteLine(i);
            }
            return true;
        }
    }
}
