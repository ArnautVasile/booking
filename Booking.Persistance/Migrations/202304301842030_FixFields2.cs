namespace Booking.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFields2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAppointments", "Date", c => c.String());
            AddColumn("dbo.UserAppointments", "Time", c => c.String());
            AddColumn("dbo.UserAppointments", "SetByEmployee", c => c.Boolean(nullable: false));
            DropTable("dbo.EmployeeAvailabilities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeAvailabilities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                        Date = c.String(),
                        Time = c.String(),
                        SetByEmployee = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.UserAppointments", "SetByEmployee");
            DropColumn("dbo.UserAppointments", "Time");
            DropColumn("dbo.UserAppointments", "Date");
        }
    }
}
