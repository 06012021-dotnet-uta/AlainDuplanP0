using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Busy;

namespace P1.Controllers
{
    public class MenuController : Controller
    {
        // GET: MenuController1
        // GET: MenuController/PrevOrder
        public ActionResult PrevOrder(ModelsDefault.User user)
        {
            UserOrders uo = new UserOrders(user);
            
            return View("PrevOrder", uo.getOrders(user).Cast<ModelsDefault.Order>().GetEnumerator());
        }

        // GET: MenuController/OrderDetails
        public ActionResult OrderDetails(ModelsDefault.Order order)
        {
            UserOrders uo = new UserOrders();
            return View("OrderDetails", uo.getOrderItems(order).Cast<ModelsDefault.Inventory>().GetEnumerator());
        }
        // GET: MenuController/Search
        public ActionResult Search(ModelsDefault.User user)
        {
            if (user.auth < 1)
            {
                return View("ErrorCred");
            }
            //UserOrders uo = new UserOrders();
            return View("UserSearch", user);
        }
        // Post : MenuController/FoundUsers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserSearch(ModelsDefault.User user)
        {
            UserSearch us = new UserSearch();


            return View("ListUsers", us.listUsers(user).Cast<ModelsDefault.User>().GetEnumerator());
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: MenuController1/Details/5
        public ActionResult DetailsUser(ModelsDefault.User user)
        {
            return View("DetailsUser", user);
        }

       
    }
}
