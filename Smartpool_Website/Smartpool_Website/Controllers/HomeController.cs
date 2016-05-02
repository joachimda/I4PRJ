using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smartpool_Website.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

       /* public class ASPLoginView : ILoginView
        {
            
        }*/

        public ActionResult Login()
        {
            //var LoginView = new ASPLoginView();
            ViewBag.Message = "Login Page";

            return View(/*ASPLoginView*/);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StatView()
        {
            ViewBag.Message = "StatView page";

            return View();
        }

    }
}