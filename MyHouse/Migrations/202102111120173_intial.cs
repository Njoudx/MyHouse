namespace MyHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        FullName = c.String(),
                        NationalityId = c.Int(nullable: false),
                        MaritualStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaritualStatus", t => t.MaritualStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Nationalities", t => t.NationalityId, cascadeDelete: true)
                .Index(t => t.NationalityId)
                .Index(t => t.MaritualStatusId);
            
            CreateTable(
                "dbo.MaritualStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        HouseTypeId = c.Int(nullable: false),
                        Bedrooms = c.Int(nullable: false),
                        IsFurnished = c.Boolean(nullable: false),
                        LogId = c.Int(nullable: false),
                        WarrantyStart = c.DateTime(nullable: false),
                        WarrantyEnd = c.DateTime(nullable: false),
                        RentPrice = c.Double(nullable: false),
                        ContractNumber = c.String(),
                        Owner = c.String(),
                        OwnershipRegisteration = c.String(),
                        Location = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.HouseTypes", t => t.HouseTypeId, cascadeDelete: true)
                .Index(t => t.HouseTypeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.HouseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "HouseTypeId", "dbo.HouseTypes");
            DropForeignKey("dbo.Houses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "NationalityId", "dbo.Nationalities");
            DropForeignKey("dbo.Employees", "MaritualStatusId", "dbo.MaritualStatus");
            DropIndex("dbo.Houses", new[] { "EmployeeId" });
            DropIndex("dbo.Houses", new[] { "HouseTypeId" });
            DropIndex("dbo.Employees", new[] { "MaritualStatusId" });
            DropIndex("dbo.Employees", new[] { "NationalityId" });
            DropTable("dbo.HouseTypes");
            DropTable("dbo.Houses");
            DropTable("dbo.Nationalities");
            DropTable("dbo.MaritualStatus");
            DropTable("dbo.Employees");
        }
    }
}
