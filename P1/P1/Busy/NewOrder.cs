using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopperContext;

namespace Busy
{
    public class NewOrder
    {
        public bool checkStore(int id)
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();

            var check = context.Stores.Where(x => x.StoreId == id).FirstOrDefault();

            return check == null;
        }

        public ModelsDefault.Order startOrder(ModelsDefault.Order order)
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();
            ShopperContext.Order temp = new ShopperContext.Order();

            temp.CustomerId = order.custId;
            temp.StoreId = order.store;
            DateTime now = DateTime.Now;
            temp.OrdersDateTime = order.time = now;
            context.Orders.Add(temp);
            context.SaveChanges();

            order.id = context.Orders.Select(x => x.OrdersId).Max();

            return order;
            
        }

        public bool checkItem(int id, int item)
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();

            var check = context.StoreInventories.Where(x => x.StoreId == id && x.ItemId == item).FirstOrDefault();

            return check == null;
        }

        public bool checkQuantity(int id, int item, int quant)
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();

            var check = context.StoreInventories.Where(x => x.StoreId == id && x.ItemId == item).FirstOrDefault();

            return check.Quantity < quant;
        }

        public bool checkDuplicates(int id, int item)
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();

            var check = context.OrderInventories.Where(x => x.OrdersId == id && x.ItemId == item).FirstOrDefault();

            return check == null;
        }

        public ModelsDefault.Order buildOrder()
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();
            ModelsDefault.Order order = new ModelsDefault.Order();
            int id = context.Orders.Select(x => x.OrdersId).Max();
            var temp = context.Orders.Where(x => x.OrdersId == id).FirstOrDefault();

            order.custId = temp.CustomerId;
            order.time = (System.DateTime)temp.OrdersDateTime;
            order.store = temp.StoreId;
            order.id = temp.OrdersId;
            order.total = 0;

            var inv = context.OrderInventories.Where(x => x.OrdersId == temp.OrdersId).ToList();

            if (inv.Any())
            {
                foreach (var i in inv)
                {
                    double price = (double)context.Items.Where(x => x.ItemId == i.ItemId).Select(x => x.ItemPrice).FirstOrDefault();
                    order.total += price * i.Quantity;
                }
            }

            return order;
        }

        public void updateOrder(int id, int item, int quant, int store)
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();
            ShopperContext.OrderInventory oi = new ShopperContext.OrderInventory();
            oi.ItemId = item;
            oi.OrdersId = id;
            oi.Quantity = quant;
            context.OrderInventories.Add(oi);
            context.SaveChanges();

            ShopperContext.StoreInventory si = context.StoreInventories.Where(x => x.ItemId == item && x.StoreId == store).FirstOrDefault();
            si.Quantity -= quant;

            ShopperContext.ShopperContext context2 = new ShopperContext.ShopperContext();
            context2.StoreInventories.Attach(si);
            context2.Entry(si).Property(x => x.Quantity).IsModified = true;
            context2.SaveChanges();
            
        }
    }
}
