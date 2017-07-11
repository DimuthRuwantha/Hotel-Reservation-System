namespace HotelReservationSystem.Migrations
{
    using HotelReservationSystem.Models;
    using HotelReservationSystem.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using HotelReservationSystem.Helpers;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelReservationSystem.DAL.HotelContext>
    {
        Encryption encrypt = new Encryption();
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //Runs when execute "update-database" in PM>
        protected override void Seed(HotelReservationSystem.DAL.HotelContext context)
        {
            var users = new List<User>
            {

                 new User
            {
               // UserID = 2,
               
                Username = "nadeera",
                Password = encrypt.MD5Encryption("def456"),
                ConfirmPassword =encrypt.MD5Encryption("def456"),
                FirstName = "Nadeera",
                LastName = "Priyashantha",
                Email = "nadeerapriyashantha@gmail.com",
                gender = "Male",
                Bday = DateTime.Parse("1989-02-19"),
                //Room_No = "null",
                Usertype="Guest"

            },
                  new User
            {
               // UserID = 2,
                Username = "Dimru",
                Password = encrypt.MD5Encryption("123"),
                ConfirmPassword =encrypt.MD5Encryption("123"),
                FirstName = "Dimuth",
                LastName = "Ruwantha",
                Email = "dimuthruwantha@gmail.com",
                gender = "Male",
                Bday = DateTime.Parse("1991-07-19"),
                //Room_No = "null",
                Usertype="Admin"
            }
            };
            //context.Users.AddOrUpdate()
            users.ForEach(s => context.Users.AddOrUpdate(s));
            context.SaveChanges();

            var rooms = new List<Room>
            {
                new Room
                {
                    RoomNo = "A11",
                    ClassType = "Presidential",
                    No_of_Guests=2,
                    Reserved = "false",
                    ReservedFrom = null,
                    ReservedTo = null
                },
                new Room
            {
                RoomNo = "A12",
                ClassType = "Presidential",
                No_of_Guests = 3,
                Reserved = "false",
                ReservedFrom = null,
                ReservedTo = null
            },
                new Room
            {
                RoomNo = "B13",
                ClassType = "Executive",
                No_of_Guests = 2,
                Reserved = "true",
                ReservedFrom = null,
                ReservedTo = null
            }
            };
            rooms.ForEach(s => context.Rooms.AddOrUpdate(p => p.RoomNo, s));
            context.SaveChanges();

            var roomfacilities = new List<RoomFacility>
            {
                new RoomFacility
                {
                    ClassType="Class A",
                    View="Sea View",
                    Tv="yes",
                    Wifi="yes",
                    No_of_Guests=2,
                    PricePerPerson=3000
                },
                new RoomFacility
                {
                    ClassType="Class B",
                    View="Sun Rise",
                    Tv="yes",
                    Wifi="yes",
                    No_of_Guests=3,
                    PricePerPerson=3000
                },
                new RoomFacility
                {
                    ClassType="Class C",
                    View="City View",
                    Tv="yes",
                    Wifi="yes",
                    No_of_Guests=3,
                    PricePerPerson=3000
                }
            };
            roomfacilities.ForEach(s => context.RoomFacilities.AddOrUpdate(p => p.ClassID, s));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            ////var menus = new List<Menu>
            ////{
            ////    new Menu
            ////    {
            ////        Lunch="Class A",
            ////       Dinner="",
            ////       Dessert=""
            ////    },
            ////    new Menu
            ////    {
            ////       Lunch="",
            ////       Dinner="",
            ////       Dessert=""
            ////    },
            ////    new Menu
            ////    {
            ////      Lunch="",
            ////      Dinner="",
            ////      Dessert=""
            ////    }
            ////};
          //  menus.ForEach(s => context.M
          //  context.SaveChanges();
        }
    }
}
