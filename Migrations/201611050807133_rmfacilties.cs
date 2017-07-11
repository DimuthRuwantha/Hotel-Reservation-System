namespace HotelReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rmfacilties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomFacilty",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        ClassType = c.String(),
                        Hotwater = c.String(),
                        Tv = c.String(),
                        Wifi = c.String(),
                        No_of_Guests = c.String(),
                        PricePerPerson = c.Int(nullable: false),
                        Room_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ClassID)
                .ForeignKey("dbo.Room", t => t.Room_ID)
                .Index(t => t.Room_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomFacilty", "Room_ID", "dbo.Room");
            DropIndex("dbo.RoomFacilty", new[] { "Room_ID" });
            DropTable("dbo.RoomFacilty");
        }
    }
}
