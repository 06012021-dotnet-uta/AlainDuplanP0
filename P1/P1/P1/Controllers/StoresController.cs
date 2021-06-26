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
        StoreSearch sto3 = new StoreSearch();
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
            ViewBag.Auth = user.auth;
            sto3.admin = user.auth;

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
            if (ViewBag.Auth < 1)
            {
                return View("ErrorCred");
            }
            UserOrders uo = new UserOrders();
            return View("OrderDetails", uo.getOrderItems(order).Cast<ModelsDefault.Inventory>().GetEnumerator());
        }

        public ActionResult Revenue(ModelsDefault.Store store)
        {
            
            return View("Revenue", store);
        }

        public ActionResult AddStore()
        {

           // if (sto3.admin < 2)
           // {
           //     return View("ErrorCred");
           // }

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

        public ActionResult Inventory(ModelsDefault.Store store)
        {
            StoreSearch sto = new StoreSearch();

            return View("Inventory", sto.getInventory(store).Cast<ModelsDefault.Inventory>().GetEnumerator());
        }
        
        public ActionResult Restock(ModelsDefault.Inventory x)
        {
            return View("AddItem", x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(ModelsDefault.Inventory store)
        {
            StoreSearch sto = new StoreSearch();
            sto.addItem(store.adder, store);
            ModelsDefault.Store temp = sto.getStore2(store.store);
            return View("Inventory", sto.getInventory(temp).Cast<ModelsDefault.Inventory>().GetEnumerator());
        }
        // GET: StoresController
        public ActionResult Index()
        {
            return View();
        }

        
        
    }
}
