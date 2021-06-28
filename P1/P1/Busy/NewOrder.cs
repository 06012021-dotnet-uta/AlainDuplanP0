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
    }
}
