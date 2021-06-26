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
    public class StoresController : Controller
    {
        public int auth;
        // GET: StoreController/Search
        public ActionResult Search(ModelsDefault.User user)
        {
            StoreSearch store = new StoreSearch();

            ViewBag.user = user;
            ViewBag.Auth = user.auth;
            //UserOrders uo = new UserOrders();
            return View("StoreSearch", user);
        }

        // Post : StoreController/StoreSearch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreSearch(ModelsDefault.User user)
        {
            StoreSearch store = new StoreSearch(user);


            return View("ListStore", store.listsStores(user).Cast<ModelsDefault.Store>().GetEnumerator());
        }

        public ActionResult Orders(ModelsDefault.Store store)
        {
            if (ViewBag.Auth < 1)
            {
                return View("ErrorCred");
            }

            StoreSearch sto = new StoreSearch();

            return View("Orders", sto.getOrders(store).Cast<ModelsDefault.Order>().GetEnumerator());
        }
        public ActionResult OrderDetails(ModelsDefault.Order order)
        {
            UserOrders uo = new UserOrders();
            return View("OrderDetails", uo.getOrderItems(order).Cast<ModelsDefault.Inventory>().GetEnumerator());
        }

        public ActionResult Revenue(ModelsDefault.Store store)
        {
            
            return View("Revenue", store);
        }

        public ActionResult AddStore()
        {
            if (ViewBag.Auth < 2)
            {
                return View("ErrorCred");
            }

            return View("createStore");
        }

        public ActionResult createStore(P1.Models.StoreBuilder store)
        {
            if (ViewBag.Auth < 2)
            {
                return View("ErrorCred");
            }

            StoreSearch sto = new StoreSearch();
            ModelsDefault.Store temp = sto.getStore(store.name, store.location);
            temp.user = ViewBag.user;
            if (temp == null)
            {
                return View("Error");
            }

            return View("NewStore", temp);
        }
        // GET: StoresController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoresController/Create
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

        // GET: StoresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoresController/Edit/5
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

        // GET: StoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoresController/Delete/5
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
