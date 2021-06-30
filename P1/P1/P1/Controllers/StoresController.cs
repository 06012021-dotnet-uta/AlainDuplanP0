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
    /// Handle store functions
    /// </summary>
    public class StoresController : Controller
    {
        public int auth;
        StoreSearch sto3 = new StoreSearch();
        // GET: StoreController/Search
        public ActionResult Search(ModelsDefault.User user)//checks authorizatio of user
        {
            StoreSearch store = new StoreSearch();

            ViewBag.user = user;
            ViewBag.Auth = user.auth;

             if (user.auth < 1)
            {
                return View("ErrorCred");
            }
            //UserOrders uo = new UserOrders();
            return View("StoreSearch", user);
        }

        // GET: StoreController/Search2
        public ActionResult Search2(ModelsDefault.User user)//used when making order, public view
        {
            StoreSearch store = new StoreSearch();

            
            //UserOrders uo = new UserOrders();
            return View("StoreSearch2", user);
        }

        // Post : StoreController/StoreSearch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreSearch(ModelsDefault.User user)//searches for stores
        {
            StoreSearch store = new StoreSearch(user);
            ViewBag.Auth = user.auth;
            sto3.admin = user.auth;

            return View("ListStore", store.listsStores(user).Cast<ModelsDefault.Store>().GetEnumerator());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreSearch2(ModelsDefault.User user)//searches for stores; made for basic user
        {
            StoreSearch store = new StoreSearch(user);
            ViewBag.Auth = user.auth;
            sto3.admin = user.auth;

            return View("ListStore2", store.listsStores(user).Cast<ModelsDefault.Store>().GetEnumerator());
        }

        // GET: StoreController/Orders
        public ActionResult Orders(ModelsDefault.Store store)//list orders of a store
        {
            if (ViewBag.Auth < 1)
            {
                return View("ErrorCred");
            }

            StoreSearch sto = new StoreSearch();

            return View("Orders", sto.getOrders(store).Cast<ModelsDefault.Order>().GetEnumerator());
        }
        // GET: StoreController/OrderDetails
        public ActionResult OrderDetails(ModelsDefault.Order order)//list details of an order
        {
            if (ViewBag.Auth < 1)
            {
                return View("ErrorCred");
            }
            UserOrders uo = new UserOrders();
            return View("OrderDetails", uo.getOrderItems(order).Cast<ModelsDefault.Inventory>().GetEnumerator());
        }
        // GET: StoreController/Revenue
        public ActionResult Revenue(ModelsDefault.Store store)//displays revenue of store
        {
            
            return View("Revenue", store);
        }
        // GET: StoreController/AddStore
        public ActionResult AddStore()//opens an new store
        {

           // if (sto3.admin < 2)
           // {
           //     return View("ErrorCred");
           // }

            return View("createStore");
        }

        // GET: StoreController/CreateStore
        public ActionResult createStore(P1.Models.StoreBuilder store)//build store 
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

        // GET: StoreController/Inventory
        public ActionResult Inventory(ModelsDefault.Store store)//returns inventory of a store
        {
            StoreSearch sto = new StoreSearch();

            return View("Inventory", sto.getInventory(store).Cast<ModelsDefault.Inventory>().GetEnumerator());
        }
        // GET: StoreController/Restock
        public ActionResult Restock(ModelsDefault.Inventory x)//restock an item
        {
            return View("AddItem", x);
        }
        // Post: StoreController/AddItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(ModelsDefault.Inventory model)//add items to order/store
        {
            StoreSearch sto = new StoreSearch();
            sto.addItem(model.adder, model);
            ModelsDefault.Store temp = sto.getStore2(model.store);
            return View("Inventory", sto.getInventory(temp).Cast<ModelsDefault.Inventory>().GetEnumerator());
            //return View("AddItem", model);
        }
        // GET: StoresController
        public ActionResult Index()
        {
            return View();
        }

        
        
    }
}
