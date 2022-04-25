using DataAccessLayer.Context;
using DataAccessLayer.Models;
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
                    var password = model.password;

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
                        ModelState.AddModelError("", "Invalid User Name or Password");
                        return View(model);
                    }
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["UserName"] = string.Empty;
            return RedirectToAction("Index", "Home");
        }

    }
}
