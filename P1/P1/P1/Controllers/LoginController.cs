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
    /// Handles loggging in, sign up and home page
    /// </summary>
    public class LoginController : Controller
    {
        private readonly SignUp  signUp = new SignUp();

        /// <summary>
        /// Main Login In Sceen
        /// </summary>
        /// <returns></returns>
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

       /// <summary>
       /// Creates a new user
       /// </summary>
       /// <returns></returns>
        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View("CreateUser");
        }

        // POST: LoginController/CreateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(P1.Models.User user)
        {
            //check that the model binding worked.
            if (!ModelState.IsValid)
            {
                RedirectToAction("Create");
            }
            return View("VerifyCreateUser", user);
        }

        // POST: LoginController/CreateNewUser
        public async Task<ActionResult> CreateNewUser(P1.Models.User user)
        {
            //check that the model binding worked.
            if (!ModelState.IsValid)
            {
                RedirectToAction("Create");
            }

            bool myBool = await signUp.registerUser(user.Fname, user.Lname, user.top);

            if (myBool)
            {
                ViewBag.ID = signUp.getID();
                ModelsDefault.User userNew = new ModelsDefault.User(){
                    fname = user.Fname,
                    lname = user.Lname,
                    id = ViewBag.ID,
                    storeId = user.top
                };
                return View("SucCreate", userNew);
            }
            else
            {
                ViewBag.ErrorText = "There was an error!";
                return View("ErrorLogin");
            }
        }
        /// <summary>
        /// Brings login page
        /// </summary>
        /// <returns></returns>
        // GET: LoginController/Login
        public ActionResult Login()
        {
            return View("LoginUser");
        }
        /// <summary>
        /// Error on loggin in
        /// </summary>
        /// <returns></returns>
        // GET: LoginController/OopsLogin
        public ActionResult OopsLogin()
        {
            return View("OopsLogin");
        }
        
        // Get: LoginController/LoginUser        
        public ActionResult LoginUser(ModelsDefault.User user)
        {
            //check that the model binding worked.
            if (!ModelState.IsValid)
            {
                RedirectToAction("OopsLogin");
            }

            if (signUp.checkID(user.id))
            {
                return View("Welcome", signUp.getUser(user));
            }

            return RedirectToAction("OopsLogin");
        }


    }
}
