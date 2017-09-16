namespace CodeFirstEmployee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShopAttendances",
                c => new
                    {
                        AttendaceId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ShopId = c.Int(nullable: false),
                        AttendaceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AttendaceId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Shop", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false),
                        EmployeeTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.EmployeeType", t => t.EmployeeTypeId, cascadeDelete: true)
                .Index(t => t.EmployeeTypeId);
            
            CreateTable(
                "dbo.EmployeeType",
                c => new
                    {
                        EmployeeTypeId = c.Int(nullable: false, identity: true),
                        EmployeeTypeName = c.String(nullable: false),
                        Salary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeTypeId);
            
            CreateTable(
                "dbo.Shop",
                c => new
                    {
                        ShopId = c.Int(nullable: false, identity: true),
                        ShopName = c.String(nullable: false),
                        Address = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.ShopId);
            
            /*CreateTable(
                "dbo.ShopEmployee",
                c => new
                    {
                        Shop_ShopId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Shop_ShopId, t.Employee_EmployeeId })
                .ForeignKey("dbo.Shop", t => t.Shop_ShopId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Shop_ShopId)
                .Index(t => t.Employee_EmployeeId);
            */
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopAttendances", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.ShopAttendances", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.ShopEmployee", "Employee_EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.ShopEmployee", "Shop_ShopId", "dbo.Shop");
            DropForeignKey("dbo.Employee", "EmployeeTypeId", "dbo.EmployeeType");
            DropIndex("dbo.ShopEmployee", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.ShopEmployee", new[] { "Shop_ShopId" });
            DropIndex("dbo.Employee", new[] { "EmployeeTypeId" });
            DropIndex("dbo.ShopAttendances", new[] { "ShopId" });
            DropIndex("dbo.ShopAttendances", new[] { "EmployeeId" });
            DropTable("dbo.ShopEmployee");
            DropTable("dbo.Shop");
            DropTable("dbo.EmployeeType");
            DropTable("dbo.Employee");
            DropTable("dbo.ShopAttendances");
        }
    }
}
