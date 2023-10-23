using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Renat_A_Ride.Models;

namespace Renat_A_Ride.Controllers
{
    public class carsController : Controller
    {
        private RentARideEntitiesDatabase db = new RentARideEntitiesDatabase();

        // GET: cars
        public ActionResult Index()
        {
            var cars = db.cars.Include(c => c.carOwner);
            return View(cars.ToList());
        }

        // GET: cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: cars/Create
        public ActionResult Create()
        {
            ViewBag.ownerID = new SelectList(db.carOwners, "ownerID", "ownerName");
            return View();
        }

        // POST: cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "carID,carBrand,carModel,carRegNum,carRegYear,carFitnessCertificate,carPicture,serviceType,rate")] car car)
        {
           
            if (ModelState.IsValid)
            {
               
                int own = Convert.ToInt32(Session["ownerID"].ToString());
                car.ownerID = own;
                db.cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ownerID = new SelectList(db.carOwners, "ownerID", "ownerID", car.ownerID);
            return View(car);
        }

        // GET: cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.ownerID = new SelectList(db.carOwners, "ownerID", "ownerName", car.ownerID);
            return View(car);
        }

        // POST: cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carID,ownerID,carBrand,carModel,carRegNum,carRegYear,carFitnessCertificate,carPicture,serviceType,rate")] car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ownerID = new SelectList(db.carOwners, "ownerID", "ownerName", car.ownerID);
            return View(car);
        }

        // GET: cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            car car = db.cars.Find(id);
            db.cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
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
