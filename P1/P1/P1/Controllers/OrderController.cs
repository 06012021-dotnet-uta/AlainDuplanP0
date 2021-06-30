using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Busy;
using ModelsDefault;

namespace P1.Controllers
{
    /// <summary>
    /// Handles order functions
    /// </summary>
    public class OrderController : Controller
    {
        
        // GET: OrderController/Search
        public ActionResult Search(ModelsDefault.User user)// creates new orders
        {
            //StoreSearch store = new StoreSearch();

            ViewBag.user = user;
            ViewBag.Auth = user.auth;

            ModelsDefault.Order order = new ModelsDefault.Order();
            order.custId = user.id;
            order.store = user.storeId;
            

            
            //UserOrders uo = new UserOrders();
            return View("createOrder", order);
        }

        // Post: OrderController/createOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult createOrder(ModelsDefault.Order order)//prompts user for store
        {
            NewOrder newOrder = new NewOrder();

            if (newOrder.checkStore(order.store))
            {
                return View("ErrorStore");
            }

            ModelsDefault.Order temp = newOrder.startOrder(order);

            return View("ViewOrder", temp);

        }

        // GET: OrderController/ViewItems
        public ActionResult ViewItems(ModelsDefault.Order order)//view items of a store
        {
            StoreSearch sto = new StoreSearch();

            return View("viewItems", sto.getInventorybyID(order.store).Cast<ModelsDefault.Inventory>().GetEnumerator());
        }

        // GET: OrderController/AddItems
        public ActionResult AddItems(ModelsDefault.Order order)// add items to an order
        {
            order.itemIDHolder = 0;
            order.amountHolder = 0;
            return View("ItemAdder", order);
        }

        // GET: OrderController/Home
        public ActionResult Home(ModelsDefault.Order order)//redirects to home page
        {
            ModelsDefault.User user = new ModelsDefault.User();
            user.id = order.custId;

            return RedirectToAction("LoginUser", "Login", user);
        }

        // Post: OrderController/ItemAdder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ItemAdder(ModelsDefault.Order order)//does verious checks before updating order and database
        {
            NewOrder newOrder = new NewOrder();
            if(newOrder.checkItem(order.store, order.itemIDHolder))
            {
                return View("NoItem");
            }
            if(newOrder.checkQuantity(order.store, order.itemIDHolder, order.amountHolder))
            {
                return View("QuantError");
            }
            if (!newOrder.checkDuplicates(order.id, order.itemIDHolder))
            {
                return View("DupError");
            }

            UserOrders uo = new UserOrders();
            newOrder.updateOrder(order.id, order.itemIDHolder, order.amountHolder, order.store);
            ViewBag.id = order.id;

            return View("OrderDetails", uo.getOrderItems(order).Cast<ModelsDefault.Inventory>().GetEnumerator());
        }

        // GET: OrderController/Build
        public ActionResult Build()//rebuild order object
        {
            
            NewOrder newOrder = new NewOrder();

            return View("ViewOrder", newOrder.buildOrder());
        }
        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        
    }
}
