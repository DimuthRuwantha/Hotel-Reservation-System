namespace HotelReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addguestno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Room", "No_of_Guests", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Room", "No_of_Guests");
        }
    }
}
