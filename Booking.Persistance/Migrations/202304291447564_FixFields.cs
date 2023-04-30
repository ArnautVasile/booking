namespace Booking.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ServiceName", c => c.String());
            AddColumn("dbo.UserAppointments", "EmploeeId", c => c.Guid(nullable: false));
            DropColumn("dbo.Services", "Name");
            DropColumn("dbo.UserAppointments", "EmploeeAvId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAppointments", "EmploeeAvId", c => c.Guid(nullable: false));
            AddColumn("dbo.Services", "Name", c => c.String());
            DropColumn("dbo.UserAppointments", "EmploeeId");
            DropColumn("dbo.Services", "ServiceName");
        }
    }
}
