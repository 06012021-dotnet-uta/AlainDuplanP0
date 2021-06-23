﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Busy;
using ModelsDefault;

namespace P1.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignUp  signUp = new SignUp();

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

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
                RedirectToAction("Login");
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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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
