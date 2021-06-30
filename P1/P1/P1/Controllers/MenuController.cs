using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Busy;

namespace P1.Controllers
{
    /// <summary>
    /// Handles functions from the main menu page
    /// </summary>
    public class MenuController : Controller
    {
        
        // GET: MenuController/PrevOrder
        public ActionResult PrevOrder(ModelsDefault.User user) // Previous orders
        {
            UserOrders uo = new UserOrders(user);
            
            return View("PrevOrder", uo.getOrders(user).Cast<ModelsDefault.Order>().GetEnumerator());
        }

        // GET: MenuController/OrderDetails
        public ActionResult OrderDetails(ModelsDefault.Order order)//Details on an order
        {
            UserOrders uo = new UserOrders();
            return View("OrderDetails", uo.getOrderItems(order).Cast<ModelsDefault.Inventory>().GetEnumerator());
        }
        // GET: MenuController/Search
        public ActionResult Search(ModelsDefault.User user)//Searches for a user, checks credibility
        {
            if (user.auth < 1)
            {
                return View("ErrorCred");
            }
            //UserOrders uo = new UserOrders();
            return View("UserSearch", user);
        }
        // Post : MenuController/UserSearch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserSearch(ModelsDefault.User user)
        {
            UserSearch us = new UserSearch();


            return View("ListUsers", us.listUsers(user).Cast<ModelsDefault.User>().GetEnumerator());
        }
        // GET: MenuController/DetailsUser
        public ActionResult DetailsUser(ModelsDefault.User user)//user details on search
        {
           
            return View("DetailsUser", user);
        }
        public ActionResult Index()
        {
            return View();
        }

              
    }
}
