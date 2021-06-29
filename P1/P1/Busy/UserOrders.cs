using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopperContext;

namespace Busy
{
    public class UserOrders
    {
        ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();

        ModelsDefault.User user;

        public UserOrders() { }
        public UserOrders(ModelsDefault.User user)
        {
            this.user = user;
        }

        public ArrayList getOrders(ModelsDefault.User cust)
        {
            ArrayList arr = new ArrayList();
            var orders = context.Orders.Where(x => x.CustomerId == cust.id).ToList();
            if (!orders.Any())
            {
                return arr;
            }
            foreach(var o in orders)
            {
                ModelsDefault.Order order = new ModelsDefault.Order();
                order.custId = cust.id;
                order.time = (System.DateTime)o.OrdersDateTime;
                order.store = o.StoreId;
                order.id = o.OrdersId;
                order.total = 0;

                var inv = context.OrderInventories.Where(x => x.OrdersId == o.OrdersId).ToList();

                if (inv.Any())
                {
                    foreach( var i in inv)
                    {
                        double price = (double)context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemPrice).FirstOrDefault();
                        order.total += price * i.Quantity;
                    }
                }
                arr.Add(order);

            }
            return arr;
        }
        public ArrayList getOrderItems(ModelsDefault.Order order)
        {
            ArrayList arr = new ArrayList();

            var items = context.OrderInventories.Where(x => x.OrdersId == order.id).ToList();
            if (!items.Any())
            {
                return arr;
            }
            foreach(var i in items)
            {
                ModelsDefault.Inventory inv = new ModelsDefault.Inventory();
                inv.id = i.ItemId;
                inv.name = context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemName).FirstOrDefault();
                inv.quantity = i.Quantity;
                inv.price = (double)context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemPrice).FirstOrDefault();
                inv.descr = context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemDescription).FirstOrDefault();
                inv.order = i.OrdersId;

                arr.Add(inv);
            }
            return arr;
        }

    }
}
