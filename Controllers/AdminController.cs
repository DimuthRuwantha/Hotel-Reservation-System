using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelReservationSystem.DAL;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Controllers
{
    public class AdminController : Controller
    {
       
        private HotelContext db = new HotelContext();

        public ActionResult Index()
        {
            if (AdminCheck(Session["UserType"].ToString()) == true)
            {
                return RedirectToAction("RoomDetails");
            }
            else
            {
                return RedirectToAction("badrequest");
            }
           
        }

        // GET: Admin
        //[HttpPost]
        //public ActionResult Index()
        //{
        //    var rms = from s in db.Rooms select s;
        //    return View(db.Rooms.ToList());
        //    //return View(rms.ToList());
        //}

        // GET: Admin/Details/5

        public ActionResult RoomDetails(int? i)
        {          
            var rooms = from s in db.Rooms select s;
                return View(rooms.ToList()); 
        }

        public ActionResult ClassDetails()
        {
            var rmfacilities = from s in db.RoomFacilities select s;
            return View(rmfacilities.ToList());
        }

 
        public ActionResult RoomCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoomCreate(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("RoomDetails");
            }

            return View(room);
        }

       
        public ActionResult ClassCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClassCreate(RoomFacility rmfc)
        {

            if (ModelState.IsValid)
            {
                db.RoomFacilities.Add(rmfc);
                db.SaveChanges();
               // Details(2);
                return RedirectToAction("ClassDetails");
            }

            return View(rmfc);
        }

        public ActionResult ClassEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomFacility rmfacility = db.RoomFacilities.Find(id);
            if (rmfacility == null)
            {
                return HttpNotFound();
            }
            return View(rmfacility);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClassEdit([Bind(Include = "ClassID,ClassType,View,Tv,Wifi,No_of_Guests,PricePerPerson")] RoomFacility rmfacility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rmfacility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ClassDetails");
            }
            return View(rmfacility);
        }

        public ActionResult ClassDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomFacility rmfacility = db.RoomFacilities.Find(id);
            if (rmfacility == null)
            {
                return HttpNotFound();
            }
            return View(rmfacility);
        }

        [HttpPost, ActionName("ClassDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ClassDeleteConfirmed(int id)
        {
            RoomFacility rmfacility = db.RoomFacilities.Find(id);
            db.RoomFacilities.Remove(rmfacility);
            db.SaveChanges();
            return RedirectToAction("ClassDetails");
        }


        // GET: Admin/Edit/5
        public ActionResult RoomEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoomEdit([Bind(Include = "ID,RoomNo,ClassType,No_of_Guests,Reserved,ReservedFrom,ReservedTo")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("RoomDetails");
            }
            return View(room);
        }

        // GET: Admin/Delete/5
        public ActionResult RoomDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("RoomDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("RoomDetails");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool AdminCheck(string usertype)
        {
         //   try
        //    {
                bool auth = false;
               // String user = Session["UserType"].ToString().ToLower();
            //    string s = user;
           //     if (Session["UserType"].ToString().ToLower() == "admin")
           if(usertype.ToLower()=="admin")
                {
                    auth = true;
                }
                return auth;
         //   }
            //catch(NullReferenceException e)
            //{
              
            //    return false;
            //}
           
        }

        public ActionResult badrequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

    }
}
