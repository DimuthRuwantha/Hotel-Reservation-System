using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelReservationSystem.Models;
using HotelReservationSystem.DAL;

namespace HotelReservationSystem.Controllers
{
    public class UserController : Controller
    {
        int totprice = 0;
        private HotelContext db = new HotelContext();

       

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult User()
        {
            ViewBag.Message = Session["User_name"];
            return View();
        }

        public ActionResult RoomsReservations()
        {
          //  ViewBag.Message = "RoomsGallery Reservations";
          

            return View();
        }

        [HttpPost]
        public ActionResult RoomsReservations(CommanClass comman)
        {
            string resfrom = comman.room.ReservedFrom.ToString();
            string resto = comman.room.ReservedTo.ToString();
            string view = comman.roomfacility.View.ToString();

            DateTime from1 = comman.room.ReservedFrom.Value;
            DateTime to = comman.room.ReservedTo.Value;

            int t = (to - from1).Days;



          //  ViewBag.Message = "RoomsGallery Reservations";
            int no = comman.room.No_of_Guests*t;
            var vprice = from r in db.RoomFacilities where r.View.Equals(view) select r.PricePerPerson*no;

      
            
             totprice = vprice.FirstOrDefault();

            // var rms = from s in db.Rooms where s.No_of_Guests.Equals(no) && s.Reserved.Equals("false") || s.ReservedTo < comman.room.ReservedTo || s.ReservedFrom > comman.room.ReservedFrom select s.ID;
            var rms = from s in db.Rooms where s.No_of_Guests.Equals(no) && s.Reserved.Equals("false") || s.ReservedTo < comman.room.ReservedTo || s.ReservedFrom > comman.room.ReservedFrom select s;

            //  var rms = from s in db.Rooms where s.No_of_Guests.Equals(no) select s;
            // var rms = from s in db.Rooms where s.No_of_Guests.Equals(no) && s.Reserved.Equals("false") || s.ReservedTo < rooms.ReservedFrom || s.ReservedFrom > rooms.ReservedTo select s;
            //    rms = rms.Where(s => s.No_of_Guests.Equals(no));

            //         rms = rms.Where(s => s.ClassType.Contains("Class A"));
            int rmscount;

            try
            {
                rmscount = rms.Count();
            }
            catch(NullReferenceException e)
            {
                rmscount = 0;
            }
            if (rmscount>0)
            {
               // int id = rms.FirstOrDefault();

                return RedirectToAction("Payment", "User", new { pri =totprice });
                //return RedirectToAction("Payment", "User", new { area = "" });
            }
            else
            {
                ModelState.AddModelError("", "Sorry!!! Rooms not available");
                ViewBag.Message = "Sorry!!! No Rooms available in this Category";

                return View();
            }

           // return View();
        }

        public ActionResult Payment(int? pri)
        {
            ViewBag.Price = pri;
            return View();
        }

        [HttpPost]
        public ActionResult Payment(Room room)
        {
            int id = Convert.ToInt32(Session["User_ID"]);

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult LeisureGallery()
        {
            ViewBag.Message = "Leisure Gallery";
            return View();
        }
        public ActionResult DinningGallery()
        {
            ViewBag.Message = "Dinning Gallery";
            return View();
        }
        public ActionResult RoomsGallery()
        {
            ViewBag.Message = "Rooms Gallery";
            return View();
        }
    }
}