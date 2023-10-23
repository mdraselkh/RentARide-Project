using Renat_A_Ride.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Renat_A_Ride.Controllers
{
    

    public class UserController : Controller
    {
        //private const string userId;
        RentARideEntitiesDatabase DB = new RentARideEntitiesDatabase();
        // GET: User
        
        public ActionResult UserRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserRegistration([Bind(Include = "userName, userEmail, userPhone, userAddress, userCity, userNID, userPassword")] User user)
        {
            user.userType = "Normal";
            DB.Users.Add(user);

            DB.SaveChanges();

            ViewBag.RegSuccess = "Registration Successful. Please Log In.";

            return View();
        }

        [HttpPost]
        public ActionResult userLogIn(User user)
        {
            User inputUser = DB.Users.Where(x => x.userEmail == user.userEmail && x.userPassword == user.userPassword).FirstOrDefault();
            if (inputUser != null)
            {
                Session["userID"] = inputUser.userID;
                Session["userName"] = inputUser.userName;

                //userId=inputUser.userID;

                return RedirectToAction("Services", "Home");
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