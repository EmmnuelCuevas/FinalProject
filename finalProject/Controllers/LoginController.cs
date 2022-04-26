using DataAccessLayer.Context;
using DataAccessLayer.Models;
using finalProject.Helpers;
using finalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginPageViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AppDbContext())
                {
                    var password =  EncryptHelper.Encode(model.password);

                    User user = context.Users
                                       .Where(u => u.email == model.email && u.password == password)
                                       .FirstOrDefault();

                    if (user != null)
                    {
                        Session["UserName"] = user.email;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["UserName"] = string.Empty;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AppDbContext())
                {
                    user.password = EncryptHelper.Encode(user.password);
                    context.Users.Add(user);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View();

        }

    }
}
