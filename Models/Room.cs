using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservationSystem.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomNo { get; set; }
        public string ClassType { get; set; }
        public string View { get; set; }
        public int No_of_Guests { get; set; }
        public string Reserved { get; set; }
       // [Required(ErrorMessage = "Date Required")]
        public DateTime? ReservedFrom { get; set; }
      //  [Required(ErrorMessage = "Date Required")]
        public DateTime? ReservedTo { get; set; }
        //    public Value roomfor { get; set; }
        public string UserID { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<RoomFacility> RoomFacilities { get; set; }
        //public virtual ICollection<Menu> Menues { get; set; }
    }


}