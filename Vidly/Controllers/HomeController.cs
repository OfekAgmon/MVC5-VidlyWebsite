using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.BusinessLogic;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            

        }
        public ActionResult Index()
        {
            ViewBag.Message = "Application Home";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}