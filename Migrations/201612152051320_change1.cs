namespace HotelReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Room", "UserID", c => c.String());
            DropColumn("dbo.User", "Room_No");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Room_No", c => c.String());
            DropColumn("dbo.Room", "UserID");
        }
    }
}
