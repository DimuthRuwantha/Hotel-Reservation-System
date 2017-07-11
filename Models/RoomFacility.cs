using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReservationSystem.Models
{
    public class RoomFacility
    {
        [Key]
        public int ClassID { get; set; }
        public String ClassType { get; set; }
        public String View { get; set; }
        public String Tv { get; set; }
        public String Wifi { get; set; }
        public int No_of_Guests { get; set; }
        public int PricePerPerson { get; set; }
    }
}