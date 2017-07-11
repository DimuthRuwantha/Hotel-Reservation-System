namespace HotelReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userlevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Usertype", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Usertype");
        }
    }
}
