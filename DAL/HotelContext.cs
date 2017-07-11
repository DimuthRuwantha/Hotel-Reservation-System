using HotelReservationSystem.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HotelReservationSystem.DAL
{

    public class HotelContext : DbContext
    {
        public HotelContext() : base("HotelContext")
        {
            Database.SetInitializer<HotelContext>(new MyDbInitializer());
            Database.SetInitializer<HotelContext>(new MyDbInitializer1());
        }

        public DbSet <User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}