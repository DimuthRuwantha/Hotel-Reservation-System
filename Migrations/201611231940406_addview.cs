namespace HotelReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomFacility", "View", c => c.String());
            AddColumn("dbo.Room", "View", c => c.String());
            DropColumn("dbo.RoomFacility", "Hotwater");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoomFacility", "Hotwater", c => c.String());
            DropColumn("dbo.Room", "View");
            DropColumn("dbo.RoomFacility", "View");
        }
    }
}
