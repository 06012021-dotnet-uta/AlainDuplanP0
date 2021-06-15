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
            Console.WriteLine("Enter Store ID to shop at");
            
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
                var descr = c.Items.Where(x => x.ItemId == i).Select(x => x.ItemDescription).FirstOrDefault();
                var quantity = c.StoreInventories.Where(x => x.ItemId == i && x.StoreId == order.store).Select(x => x.Quantity).FirstOrDefault();
                Console.WriteLine($"\n{quantity} {name} found for ${price} each.{descr}. Its ID is {i}");
                //Console.WriteLine(i);
            }
            return true;
        }

        public Model.Order getItem(Model.Order order)
        {
            Console.WriteLine("Enter the item ID you want to buy");
            int id = checkId();
            var item = context.StoreInventories.Where(x => x.ItemId == id && x.StoreId == order.store).FirstOrDefault();
            if(item == null)
            {
                Console.WriteLine("That ID was invalid, lets try this again :)\nEnter the item ID you want to buy.");
                return getItem(order);
            }
            else
            {
                var name = context.Items.Where(x => x.ItemId == item.ItemId).Select(x => x.ItemName).FirstOrDefault();
                var descr = context.Items.Where(x => x.ItemId == item.ItemId).Select(x => x.ItemDescription).FirstOrDefault();
                var pce = context.Items.Where(x => x.ItemId == item.ItemId).Select(x => x.ItemPrice).FirstOrDefault();
                Console.WriteLine($"You selected to buy {name}: {descr}. It cost ${pce} each\n");
                Console.WriteLine("Enter how much you need");
                int quan = checkQuantity(item);
                double price = (double)context.Items.Where(x => x.ItemId == id).Select(x => x.ItemPrice).FirstOrDefault();
                Console.WriteLine($"You selected to by {quan} for ${quan * price}. Adding to your cart(BTW you cant change this amount <3))");
                order.addItem(new Inventory(id, quan, quan * price));
                return order;
            }
            
        }

        private int checkQuantity(P0Context.StoreInventory item)
        {
            int input = checkNum();
            if(input > item.Quantity)
            {
                Console.WriteLine("We don't have that many, lessen the amount");
                input = checkQuantity(item);
            }
            if(input > 10)
            {
                Console.WriteLine("for inventory reasons, we don't allow to check out that many items, lessen the amount");
                input = checkQuantity(item);
            }
            item.Quantity -= input;
            context.Entry(item).Property(x => x.Quantity).IsModified = true;
            return input;
        }

        private int checkNum()
        {

            string input = Console.ReadLine();
            int CId;
            bool sucessfulConversion = Int32.TryParse(input, out CId);
            while (!sucessfulConversion)
            {
                Console.WriteLine("incorrect format, enter a new one");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out CId);
            }
            return CId;
        }
        public int finalized(Model.Order order)
        {
            P0Context.Order newOrder = new P0Context.Order();
            newOrder.CustomerId = order.customer.id;
            newOrder.StoreId = order.store;
            DateTime now = DateTime.Now;
            newOrder.OrdersDateTime = now;
            context.Orders.Add(newOrder);

            context.SaveChanges();

            int id = context.Orders.Select(x => x.OrdersId).Max();
            
            
            foreach(Inventory i in order.getOrder())
            {
                P0Context.OrderInventory newOI = new P0Context.OrderInventory();
                newOI.OrdersId = id;
                newOI.ItemId = i.item;
                newOI.Quantity = i.quantity;
                context.OrderInventories.Add(newOI);
            }

            context.SaveChanges();

            return id;
        }
    }
}
