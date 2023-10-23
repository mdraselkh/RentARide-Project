using Renat_A_Ride.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Renat_A_Ride.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
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
       

        public ActionResult Services()
        {
         
            return View();
        }

       
        public ActionResult Pricing1()
        {
            return View();
        }

        public ActionResult Pricing2()
        {
            return View();
        }

        public ActionResult Pricing3()
        {
            return View();
        }

        public ActionResult Pricing4()
        {
            return View();
        }

        public ActionResult Pricing5()
        {
            return View();
        }

    }
}