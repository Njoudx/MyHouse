namespace MyHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class housetypename : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HouseTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HouseTypes", "Name", c => c.Int(nullable: false));
        }
    }
}
