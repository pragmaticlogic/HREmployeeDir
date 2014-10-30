using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleHR.DataAccess;
using SimpleHR.Models;
using System.Web.Security;
using SimpleHR.Providers;

namespace SimpleHR.Controllers
{
    public class CredentialsController : Controller
    {        
        private ILoginProvider LoginProvider;
        
        public CredentialsController(ILoginProvider provider)
        {
            LoginProvider = provider;
        }

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
            else
            {
                if (LoginProvider.ValidateUser(model.LoginId, model.PasswordHash))
                {
                    FormsAuthentication.SetAuthCookie(model.LoginId, false);
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }
            }                     
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Unauthorize()
        {
            return View();
        }
    }
}
