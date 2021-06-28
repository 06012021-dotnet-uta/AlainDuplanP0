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
    public class OrderController : Controller
    {
        
        // GET: OrderController/Search
        public ActionResult Search(ModelsDefault.User user)
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

        // GET: OrderController/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult createOrder(ModelsDefault.Order order)
        {
            NewOrder newOrder = new NewOrder();

            if (newOrder.checkStore(order.store))
            {
                return View("ErrorStore");
            }

            ModelsDefault.Order temp = newOrder.startOrder(order);

            return View("ViewOrder", temp);

        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
