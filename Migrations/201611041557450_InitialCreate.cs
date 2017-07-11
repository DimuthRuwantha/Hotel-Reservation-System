namespace HotelReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoomNo = c.String(),
                        ClassType = c.String(),
                        Reserved = c.String(),
                        ReservedFrom = c.DateTime(),
                        ReservedTo = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        gender = c.String(nullable: false),
                        Bday = c.DateTime(nullable: false),
                        Room_No = c.String(),
                        Room_ID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Room", t => t.Room_ID)
                .Index(t => t.Room_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Room_ID", "dbo.Room");
            DropIndex("dbo.User", new[] { "Room_ID" });
            DropTable("dbo.User");
            DropTable("dbo.Room");
        }
    }
}
