using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.DAL
{
    public class MyDbInitializer1 : DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            context.Users.Add(new User
            {
                //  UserID = 2,
                Username = "nadeera",
                Password = "def456",
                ConfirmPassword ="def456",
                FirstName = "Nadeera",
                LastName = "Priyashantha",
                Email = "nadeerapriyashantha@gmail.com",
                gender = "Male",
                Bday = DateTime.Parse("1989-02-19"),
                //Room_No="null",
                Usertype="Guest"
            });
            context.SaveChanges();
            context.Users.Add(new User
            {
              //  UserID = 2,
                Username = "Dimru",
                Password = "123",
                ConfirmPassword="123",
                FirstName = "Dimuth",
                LastName = "Ruwantha",
                Email = "dimuthruwantha@gmail.com",
                gender = "Male",
                Bday = DateTime.Parse("1991-07-19"),
                Usertype = "admin"
            });
               context.SaveChanges();

            context.Rooms.Add(new Room
            {
                RoomNo = "A11",
                ClassType = "Presidential",
                No_of_Guests=2,
                Reserved = "false",
                ReservedFrom = null,
                ReservedTo = null,
                UserID=null
            });
            context.SaveChanges();
            context.Rooms.Add(new Room
            {
                RoomNo = "A12",
                ClassType = "Presidential",
                No_of_Guests=3,
                Reserved = "false",
                ReservedFrom = null,
                ReservedTo = null,
                UserID=null
            });
            context.SaveChanges();
            context.Rooms.Add(new Room
            {
                RoomNo = "B13",
                ClassType = "Executive",
                No_of_Guests=2,
                Reserved = "true",
                ReservedFrom = null,
                ReservedTo = null,
                UserID=null
            });
            context.SaveChanges();


            base.Seed(context);

        }

    }

    public class MyDbInitializer : CreateDatabaseIfNotExists<HotelContext>
  //  public class MyDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            context.Users.Add(new User
            {
               // UserID = 1,
                Username = "admin",
                Password = "abc123",
                FirstName = "Dimuth",
                LastName = "Ruwantha",
                Email = "dimuthruwantha@gmail.com",
                gender = "Male",
                Bday = DateTime.Parse("1991-07-19")
            });
            context.Users.Add(new User
            {
              //  UserID = 2,
                Username = "user1",
                Password = "def456",
                FirstName = "Nadeera",
                LastName = "Priyashantha",
                Email = "nadeerapriyashantha@gmail.com",
                gender = "Male",
                Bday = DateTime.Parse("1989-02-19")
            });
            //     context.SaveChanges();

            context.Rooms.Add(new Room
            {
                RoomNo = "A11",
                ClassType = "Presidential",
                Reserved = "false",
                ReservedFrom = null,
                ReservedTo = null,
                UserID=null            
            });
            context.Rooms.Add(new Room
            {
                RoomNo = "A12",
                ClassType = "Presidential",
                Reserved = "false",
                ReservedFrom = null,
                ReservedTo = null,
                UserID=null
            });
            context.Rooms.Add(new Room
            {
                RoomNo = "B13",
                ClassType = "Executive",
                Reserved = "true",
                ReservedFrom = null,
                ReservedTo = null,
                UserID=null
            });
            base.Seed(context);

        }
        

    }
}