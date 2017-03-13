namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PercentageChangeSalesReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesReports", "PercentageChange", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesReports", "PercentageChange");
        }
    }
}
