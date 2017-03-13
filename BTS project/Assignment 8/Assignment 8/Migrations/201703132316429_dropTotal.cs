namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropTotal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesReportAdds", "Total", c => c.Single(nullable: false));
            DropColumn("dbo.SalesReports", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesReports", "Total", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesReportAdds", "Total", c => c.Int(nullable: false));
        }
    }
}
