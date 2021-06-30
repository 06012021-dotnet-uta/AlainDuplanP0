using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopperContext;

namespace Busy
{
    /// <summary>
    /// Responsiblle for creating new orders
    /// </summary>
    public class NewOrder : INewOrder
    {
        /// <summary>
        /// Responsible for checking if store id was valid
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>Whether store ID is valid</returns>
        public bool checkStore(int id)
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();

            var check = context.Stores.Where(x => x.StoreId == id).FirstOrDefault();

            return check == null;
        }
        /// <summary>
        /// Builds a new order object
        /// </summary>
        /// <param name="order">Order object with a customer id and store id field filled in</param>
        /// <returns>Returns updated order object</returns>
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
        /// <summary>
        /// Check if item exists in the store
        /// </summary>
        /// <param name="id">store id</param>
        /// <param name="item">item id</param>
        /// <returns>whether or not item exist in the store</returns>
        public bool checkItem(int id, int item)
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();

            var check = context.StoreInventories.Where(x => x.StoreId == id && x.ItemId == item).FirstOrDefault();

            return check == null;
        }
        /// <summary>
        /// checks if store has sufficient quanitiy of an item
        /// </summary>
        /// <param name="id">store id</param>
        /// <param name="item">item id</param>
        /// <param name="quant">quanitity asked</param>
        /// <returns>If store can payout</returns>
        public bool checkQuantity(int id, int item, int quant)
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();

            var check = context.StoreInventories.Where(x => x.StoreId == id && x.ItemId == item).FirstOrDefault();

            return check.Quantity < quant;
        }

        /// <summary>
        /// Check if duplicate items exist in an order
        /// </summary>
        /// <param name="id">order id</param>
        /// <param name="item">store id</param>
        /// <returns>if item doesnt exist, returns true</returns>
        public bool checkDuplicates(int id, int item)
        {
            ShopperContext.ShopperContext context = new ShopperContext.ShopperContext();

            var check = context.OrderInventories.Where(x => x.OrdersId == id && x.ItemId == item).FirstOrDefault();

            return check == null;
        }

        /// <summary>
        /// Build order based of newest order in database(the order we are working on)
        /// </summary>
        /// <returns>New fully built order</returns>
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
        /// <summary>
        /// Updates data base with order info
        /// </summary>
        /// <param name="id">order id</param>
        /// <param name="item">item id</param>
        /// <param name="quant">quantity taken</param>
        /// <param name="store">store id</param>
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
