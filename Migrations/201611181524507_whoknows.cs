namespace HotelReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whoknows : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Room", "ReservedFrom", c => c.DateTime());
            AlterColumn("dbo.Room", "ReservedTo", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Room", "ReservedTo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Room", "ReservedFrom", c => c.DateTime(nullable: false));
        }
    }
}
