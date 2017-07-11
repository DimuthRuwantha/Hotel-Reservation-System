using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HotelReservationSystem.DAL;
using HotelReservationSystem.Models;
using HotelReservationSystem.Helpers;

namespace HotelReservationSystem.Controllers
{
   
    public class HomeController : Controller
    {
        Encryption encrypt = new Encryption();
        private HotelContext db = new HotelContext();

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(Rooms rooms)
        //{
            
        //}

        public ActionResult HomeGallery()
        {
            ViewBag.Message = "this is Gallery from outside.";

            return View();
        }
      
        
        // [HttpPost]
       // [ValidateAntiForgeryToken]
        public ViewResult Login()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Login(User usr)
        {
            //  User user = new User();
            //  var user1 = db.users.Where(d => d.Username == User_name && d.Password == Password);
            // string username = "user_name";
            // var user1 = db.users.FirstOrDefault(d => d.Username == usr.Username && d.Password == usr.Password);
            //if(ModelState.IsValid)
            //{
                using (HotelContext db = new HotelContext())
                {
                string password;
                if(usr.Password==null)
                {
                    password = "null";
                }
                 password = encrypt.MD5Encryption(usr.Password);
                    var user1 = db.Users.FirstOrDefault(d => d.Username == usr.Username && d.Password == password );

                    if (user1 != null)
                    {
                  //  Session["User_name"] = "Temporary user"; //REMOVE THIS IN THE END OF PROJECT
                    Session["UserType"] = user1.Usertype.ToString();
                        Session["User_name"] = user1.Username.ToString();
                    Session["User_ID"] = user1.UserID;
                    //    return RedirectToAction("Home");
                    return RedirectToAction("User", "User", new { area = "" });
                    //return View(user1.ToList()) ;
                }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Credentials");
                        ViewBag.Message = "Invalid Credentials";
                     
                    return View();
                    }
                }
            //}
            //else
            //{
            //    return View();
            //}
           
        }

        public ViewResult Home()
        {
            ViewBag.Message = Session["User_name"];
            return View();
        }


        public ActionResult Signup()
        {
           // ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Signup(User usr)
        {
         //   string name = usr.gender.ToString();
            if(ModelState.IsValid)
            {
                
                usr.Password = encrypt.MD5Encryption(usr.Password.ToString());
                usr.ConfirmPassword = encrypt.MD5Encryption(usr.ConfirmPassword.ToString());
                usr.Usertype = "Guest";
                using (HotelContext db = new HotelContext())
                {
                    db.Users.Add(usr);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Successfully registered";
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Signup");
            }
            
        }
    }
}