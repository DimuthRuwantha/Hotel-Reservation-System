using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password Required")]
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Firstname Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gender Required")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Date of Birth Required")]
        public DateTime Bday { get; set; }

      //  public string Room_No { get; set; }
        public string Usertype { get; set; }

        public ICollection<Room> Rooms { get; set; }
        /*
        First name
        Last name
        Email
        gender
        and date of birth

        */
    }
}