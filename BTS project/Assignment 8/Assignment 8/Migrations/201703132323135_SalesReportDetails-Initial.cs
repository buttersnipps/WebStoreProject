namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesReportDetailsInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesReport_vm",
                c => new
                    {
                        SalesReportId = c.Int(nullable: false, identity: true),
                        SalesReportName = c.String(),
                        Month = c.DateTime(nullable: false),
                        Total = c.Single(nullable: false),
                        PercentageChange = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.SalesReportId);
            
            CreateTable(
                "dbo.SalesReportDetails",
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
            DropTable("dbo.SalesReportDetails");
            DropTable("dbo.SalesReport_vm");
        }
    }
}
