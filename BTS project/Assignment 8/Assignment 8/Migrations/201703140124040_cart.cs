namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesReports",
                c => new
                    {
                        SalesReportId = c.Int(nullable: false, identity: true),
                        SalesReportName = c.String(),
                        Month = c.DateTime(nullable: false),
                        Total = c.Single(nullable: false),
                        PercentageChange = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.SalesReportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalesReports");
        }
    }
}
