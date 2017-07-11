using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelReservationSystem.DAL;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Controllers
{
    public class MainController : Controller
    {
        private HotelContext db = new HotelContext();
        // GET: Main

        [HttpPost]
        public ActionResult Index(Room rooms)
        {
            String from = rooms.ReservedFrom.ToString();
            String to = rooms.ReservedTo.ToString();
            int no = rooms.No_of_Guests;
            //    int no = Convert.ToInt16(rooms.No_of_Guests.ToString());

          //  var rms = from s in db.Rooms where s.No_of_Guests.Equals(no) select s;
            var rms = from s in db.Rooms where s.No_of_Guests.Equals(no) && s.Reserved.Equals("false") || s.ReservedTo < rooms.ReservedFrom || s.ReservedFrom>rooms.ReservedTo select s;
            //    rms = rms.Where(s => s.No_of_Guests.Equals(no));

            //         rms = rms.Where(s => s.ClassType.Contains("Class A"));

            //   return View(rms.ToList());

            return View(rms.ToList());
        }

        public ActionResult CheckAvailability()
        {

            return View();
        }

        public ActionResult Booking()
        {
            return View();
        }

        public ActionResult CancelBooking()
        {
            return View();
        }

        public ActionResult MakePayment()
        {
            return View();
        }
    }
}