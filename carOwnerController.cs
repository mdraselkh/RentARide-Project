using Renat_A_Ride.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Renat_A_Ride.Controllers
{
    public class carOwnerController : Controller
    {
        // GET: carOwner

        RentARideEntitiesDatabase DB = new RentARideEntitiesDatabase();
        

        public ActionResult CarOwnerRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CarOwnerRegistration([Bind(Include = "ownerName, ownerEmail, ownerPhone, ownerAddress, ownerPassport, ownerPassword")] carOwner carowner)
        {


            DB.carOwners.Add(carowner);


           DB.SaveChanges();

            ViewBag.RegSuccess = "Registration Successful. Please Log In.";

            return View();
        }

        [HttpPost]
        public ActionResult CarOwnerLogIn(carOwner carowner)
        {
            carOwner inputUser = DB.carOwners.Where(x => x.ownerEmail == carowner.ownerEmail && x.ownerPassword == carowner.ownerPassword).FirstOrDefault();
            if (inputUser != null)
            {
                Session["ownerID"] = inputUser.ownerID;
                Session["ownerName"] = inputUser.ownerName;

                //userId=inputUser.userID;

                return RedirectToAction("Index", "cars");
            }
            else
            {
                ViewBag.logError = "Wrong Credentials";
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }

    }
}