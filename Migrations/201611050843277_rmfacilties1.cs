namespace HotelReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rmfacilties1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoomFacilty", newName: "RoomFacility");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RoomFacility", newName: "RoomFacilty");
        }
    }
}
