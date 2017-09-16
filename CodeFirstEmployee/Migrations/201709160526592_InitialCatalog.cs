namespace CodeFirstEmployee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCatalog : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ShopAttendances");
            DropColumn("dbo.ShopAttendances", "AttendaceId");
            AddColumn("dbo.ShopAttendances", "AttendanceId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ShopAttendances", "AttendanceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShopAttendances", "AttendaceId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ShopAttendances");
            DropColumn("dbo.ShopAttendances", "AttendanceId");
            AddPrimaryKey("dbo.ShopAttendances", "AttendaceId");
        }
    }
}
