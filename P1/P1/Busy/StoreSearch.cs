using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopperContext;

namespace Busy
{
    public class StoreSearch
    {
        ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();
        ModelsDefault.User us;
        public int admin { get; set; }
        public StoreSearch() { }
        public StoreSearch(ModelsDefault.User us)
        {
            this.us = us;
        }

        

            public ArrayList listsStores (ModelsDefault.User user)
        {
            ArrayList arr = new ArrayList();

            int a = user.auth;


            var choices = context.Stores.Where(x => x.StoreName.Contains(user.findStore)).ToList();
            if (!choices.Any())
            {
                return arr;
            }
            if (user.findStore == "")
            {
                choices = context.Stores.ToList();
            }

            foreach (var c in choices)
            {
                ModelsDefault.Store temp = new ModelsDefault.Store();
                temp.admin = user.id;
                temp.id = c.StoreId;
                temp.name = c.StoreName;
                temp.location = c.StoreLocation;
                temp.numOrders = context.Stores.Where(x => x.StoreId == c.StoreId).Count();
                temp.total = (double)(from oi in context.OrderInventories
                                      join o in context.Orders on oi.OrdersId equals o.OrdersId
                                      join i in context.Items on oi.ItemId equals i.ItemId
                                      where o.StoreId == temp.id
                                      select oi.Quantity * i.ItemPrice).Sum(); 
                arr.Add(temp);
            }


            return arr;
        }

        public ArrayList getOrders(ModelsDefault.Store cust)
        {
            ArrayList arr = new ArrayList();
            var orders = context.Orders.Where(x => x.StoreId == cust.id).ToList();
            if (!orders.Any())
            {
                return arr;
            }
            foreach (var o in orders)
            {
                ModelsDefault.Order order = new ModelsDefault.Order();
                order.custId = o.CustomerId;
                order.time = (System.DateTime)o.OrdersDateTime;
                order.store = o.StoreId;
                order.id = o.OrdersId;
                order.total = 0;
                //order.auth = (int)context.Customers.Where(x => x.CustomerId == cust.admin).Select(x => x.Auth).FirstOrDefault();

                var inv = context.OrderInventories.Where(x => x.OrdersId == o.OrdersId).ToList();

                if (inv.Any())
                {
                    foreach (var i in inv)
                    {
                        double price = (double)context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemPrice).FirstOrDefault();
                        order.total += price * i.Quantity;
                    }
                }
                arr.Add(order);

            }
            return arr;
        }

        public ModelsDefault.Store getStore(string name, string location){

            ShopperContext.Store store = new ShopperContext.Store();

            store.StoreName = name;
            store.StoreLocation = location;

            context.Stores.Add(store);
            try
            {
                context.SaveChanges();
            }
            catch
            {
                //Console.WriteLine(ex); 
                return null;
            }
            int id = context.Stores.Select(x => x.StoreId).Max();
            ModelsDefault.Store temp = new ModelsDefault.Store();
            temp.id = id;
            temp.name = name;
            temp.location = location;

            return temp;


        }
        public ModelsDefault.Store getStore2(int id)
        {

            ShopperContext.Store c;
            c = context.Stores.Where(x => x.StoreId == id).FirstOrDefault();

            ModelsDefault.Store temp = new ModelsDefault.Store();
            //temp.admin = user.id;
            temp.id = c.StoreId;
            temp.name = c.StoreName;
            temp.location = c.StoreLocation;
            temp.numOrders = context.Stores.Where(x => x.StoreId == c.StoreId).Count();
            temp.total = (double)(from oi in context.OrderInventories
                                  join o in context.Orders on oi.OrdersId equals o.OrdersId
                                  join i in context.Items on oi.ItemId equals i.ItemId
                                  where o.StoreId == temp.id
                                  select oi.Quantity * i.ItemPrice).Sum();
            return temp;


        }
        public ArrayList getInventory(ModelsDefault.Store store)
        {
            ArrayList arr = new ArrayList();

            var choices = context.StoreInventories.Where(x => x.StoreId == store.id).ToList();

            if (!choices.Any())
            {
                return arr;
            }
            foreach(var i in choices)
            {
                ModelsDefault.Inventory inv = new ModelsDefault.Inventory();
                inv.store = i.StoreId;
                inv.id = i.ItemId;

                inv.name = context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemName).FirstOrDefault();
                inv.quantity = i.Quantity;
                inv.price = (double)context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemPrice).FirstOrDefault();
                inv.descr = context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemDescription).FirstOrDefault();

                arr.Add(inv);
            }

            return arr;
        }
        public void addItem(int add, ModelsDefault.Inventory inv)
        {
            ShopperContext.StoreInventory temp = context.StoreInventories.Where(x => x.StoreId == inv.store && x.ItemId == inv.id).FirstOrDefault();
            temp.Quantity += add;
            context.StoreInventories.Attach(temp);
            context.Entry(temp).Property(x => x.Quantity).IsModified = true;
            context.SaveChanges();
            return;
        }

        public ArrayList getInventorybyID(int id)
        {
            ArrayList arr = new ArrayList();

            var choices = context.StoreInventories.Where(x => x.StoreId == id).ToList();

            if (!choices.Any())
            {
                return arr;
            }
            foreach (var i in choices)
            {
                ModelsDefault.Inventory inv = new ModelsDefault.Inventory();
                inv.store = i.StoreId;
                inv.id = i.ItemId;

                inv.name = context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemName).FirstOrDefault();
                inv.quantity = i.Quantity;
                inv.price = (double)context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemPrice).FirstOrDefault();
                inv.descr = context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemDescription).FirstOrDefault();

                arr.Add(inv);
            }

            return arr;
        }
    }
}
