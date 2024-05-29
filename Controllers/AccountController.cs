using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;
using Test.Models;
using System.Web.Security;

namespace SITClone.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ExamEntities1 db = new ExamEntities1();
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            User user = db.Users.Where(e => e.Email == email).FirstOrDefault();

            if (user == null)
            {
                ViewBag.Error = "No user found.";
                return View();
            }
            else if (user.Password != password)
            {
                ViewBag.Error = "Incorrect password.";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                Session["UserId"] = user.UserId;
                Session["Type"] = user.Type;

                return RedirectToAction("Index", "Event");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            User existingUser = db.Users.Where(u => u.Email == user.Email).FirstOrDefault();

            if (existingUser != null)
            {
                ViewBag.Error = $"User already exist with email address: {user.Email}";
                return View(user);
            }
            user.Type = "customer";
            user.CreatedOn = DateTime.Now;
            user.UpdatedOn = DateTime.Now;
            user.Isdeleted = 0;
            db.Users.Add(user);
            db.SaveChanges();

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}