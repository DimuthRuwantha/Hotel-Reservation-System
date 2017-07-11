namespace HotelReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoomFacility", "No_of_Guests", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoomFacility", "No_of_Guests", c => c.String());
        }
    }
}
