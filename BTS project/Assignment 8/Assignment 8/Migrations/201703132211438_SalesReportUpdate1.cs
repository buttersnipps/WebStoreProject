namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesReportUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesReports", "Total", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesReports", "Total");
        }
    }
}
