namespace Booking.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenerateFirstEntities3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BaseUserEntities", newName: "Employees");
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
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Employees", "BarbershopId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Employees", "Id");
            AddForeignKey("dbo.Employees", "Id", "dbo.BaseUserEntities", "Id");
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "FirstName");
            DropColumn("dbo.Employees", "Username");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "IsAdmin");
            DropColumn("dbo.Employees", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Employees", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Employees", "Username", c => c.String());
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            AddColumn("dbo.Employees", "LastName", c => c.String());
            DropForeignKey("dbo.Employees", "Id", "dbo.BaseUserEntities");
            DropIndex("dbo.Employees", new[] { "Id" });
            AlterColumn("dbo.Employees", "BarbershopId", c => c.Guid());
            DropTable("dbo.BaseUserEntities");
            RenameTable(name: "dbo.Employees", newName: "BaseUserEntities");
        }
    }
}
