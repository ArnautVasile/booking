namespace Booking.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenerateFirstEntities2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "Employee_Id", "dbo.BaseUserEntities");
            DropForeignKey("dbo.BaseUserEntities", "BarbershopId", "dbo.Barbershops");
            DropForeignKey("dbo.Services", "Barbershop_Id", "dbo.Barbershops");
            DropIndex("dbo.BaseUserEntities", new[] { "BarbershopId" });
            DropIndex("dbo.Services", new[] { "Employee_Id" });
            DropIndex("dbo.Services", new[] { "Barbershop_Id" });
            CreateTable(
                "dbo.EmployeeServices",
                c => new
                    {
                        Employee_Id = c.Guid(nullable: false),
                        Service_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_Id, t.Service_Id })
                .ForeignKey("dbo.BaseUserEntities", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.BarbershopEmployees",
                c => new
                    {
                        Barbershop_Id = c.Guid(nullable: false),
                        Employee_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Barbershop_Id, t.Employee_Id })
                .ForeignKey("dbo.Barbershops", t => t.Barbershop_Id, cascadeDelete: true)
                .ForeignKey("dbo.BaseUserEntities", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Barbershop_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.BarbershopServices",
                c => new
                    {
                        Barbershop_Id = c.Guid(nullable: false),
                        Service_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Barbershop_Id, t.Service_Id })
                .ForeignKey("dbo.Barbershops", t => t.Barbershop_Id, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .Index(t => t.Barbershop_Id)
                .Index(t => t.Service_Id);
            
            DropColumn("dbo.Services", "Employee_Id");
            DropColumn("dbo.Services", "Barbershop_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Barbershop_Id", c => c.Guid());
            AddColumn("dbo.Services", "Employee_Id", c => c.Guid());
            DropForeignKey("dbo.BarbershopServices", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.BarbershopServices", "Barbershop_Id", "dbo.Barbershops");
            DropForeignKey("dbo.BarbershopEmployees", "Employee_Id", "dbo.BaseUserEntities");
            DropForeignKey("dbo.BarbershopEmployees", "Barbershop_Id", "dbo.Barbershops");
            DropForeignKey("dbo.EmployeeServices", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.EmployeeServices", "Employee_Id", "dbo.BaseUserEntities");
            DropIndex("dbo.BarbershopServices", new[] { "Service_Id" });
            DropIndex("dbo.BarbershopServices", new[] { "Barbershop_Id" });
            DropIndex("dbo.BarbershopEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.BarbershopEmployees", new[] { "Barbershop_Id" });
            DropIndex("dbo.EmployeeServices", new[] { "Service_Id" });
            DropIndex("dbo.EmployeeServices", new[] { "Employee_Id" });
            DropTable("dbo.BarbershopServices");
            DropTable("dbo.BarbershopEmployees");
            DropTable("dbo.EmployeeServices");
            CreateIndex("dbo.Services", "Barbershop_Id");
            CreateIndex("dbo.Services", "Employee_Id");
            CreateIndex("dbo.BaseUserEntities", "BarbershopId");
            AddForeignKey("dbo.Services", "Barbershop_Id", "dbo.Barbershops", "Id");
            AddForeignKey("dbo.BaseUserEntities", "BarbershopId", "dbo.Barbershops", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Services", "Employee_Id", "dbo.BaseUserEntities", "Id");
        }
    }
}
