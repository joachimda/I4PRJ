using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smartpool.Application.Presentation;
using Smartpool.Connection.Client;
using Smartpool.Connection.Model;

//ReSharper disable once CheckNamespace 
namespace Smartpool.Application.Web
{
    

    public class HomeController : Controller
    {
        static string Ip = "Ip-address" ;

        public ActionResult Index()
        {
            return View();
        }


       public class ASPLoginView : ILoginView
        {
        
            public IViewController Controller { get; set; }
            
            ASPLoginView()
            {
                   var clientMessager = new ClientMessager(new SynchronousSocketClient(Ip));
                    Controller = new LoginViewController(this,clientMessager);
            }


            public void LoginAccepted()
            {
                
            }
        }

        public ActionResult Login()
        {
            var LoginView = new ASPLoginView();
            ViewBag.Message = "Login Page";

            return View(ASPLoginView);
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

        

        public ActionResult About()
        {
            return View();
        }

    }
}