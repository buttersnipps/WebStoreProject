namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFloatTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesReports", "Total", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesReports", "Total");
        }
    }
}
