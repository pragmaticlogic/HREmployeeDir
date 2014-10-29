using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleHR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Just a simple, pretentious HR Employee Directory Application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kevin Le.";

            return View();
        }
    }
}