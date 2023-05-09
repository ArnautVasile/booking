namespace Booking.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenerateFirstEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barbershops",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BaseUserEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        BarbershopId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barbershops", t => t.BarbershopId, cascadeDelete: true)
                .Index(t => t.BarbershopId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ServiceType = c.String(),
                        Name = c.String(),
                        Employee_Id = c.Guid(),
                        Barbershop_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseUserEntities", t => t.Employee_Id)
                .ForeignKey("dbo.Barbershops", t => t.Barbershop_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Barbershop_Id);
            
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
            
            CreateTable(
                "dbo.UserAppointments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        BarbershopId = c.Guid(nullable: false),
                        ServiceId = c.Guid(nullable: false),
                        EmploeeAvId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "Barbershop_Id", "dbo.Barbershops");
            DropForeignKey("dbo.BaseUserEntities", "BarbershopId", "dbo.Barbershops");
            DropForeignKey("dbo.Services", "Employee_Id", "dbo.BaseUserEntities");
            DropIndex("dbo.Services", new[] { "Barbershop_Id" });
            DropIndex("dbo.Services", new[] { "Employee_Id" });
            DropIndex("dbo.BaseUserEntities", new[] { "BarbershopId" });
            DropTable("dbo.UserAppointments");
            DropTable("dbo.EmployeeAvailabilities");
            DropTable("dbo.Services");
            DropTable("dbo.BaseUserEntities");
            DropTable("dbo.Barbershops");
        }
    }
}
