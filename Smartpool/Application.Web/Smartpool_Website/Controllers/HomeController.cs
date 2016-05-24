using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//ReSharper disable once CheckNamespace 
namespace Smartpool.Application.Web
{
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult StatView()
        {
            ViewBag.Message = "StatView page";

            return View();
        }

        public ActionResult EditUserView()
        {
            return View();
        }
        

        public ActionResult About()
        {
            return View();
        }

        public ActionResult AddPoolView()
        {
            return View();
        }

    }
}