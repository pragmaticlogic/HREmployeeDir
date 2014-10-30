using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleHR.DataAccess;
using SimpleHR.Models;
using System.Web.Security;

namespace SimpleHR.Controllers
{
    public class CredentialsController : Controller
    {
        private EmployeeDbContext db = new EmployeeDbContext();
        
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult Login(Credential model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var hasher = new SimpleHR.Utils.PasswordHasher();
            Credential credential = db.Credentials.Find(model.LoginId);

            if (credential.PasswordHash == hasher.HashPassword(model.PasswordHash))
            {
                FormsAuthentication.SetAuthCookie(credential.LoginId, false);
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }            
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
