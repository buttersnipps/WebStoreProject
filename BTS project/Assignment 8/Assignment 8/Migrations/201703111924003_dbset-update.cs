namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbsetupdate : DbMigration
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
                    })
                .PrimaryKey(t => t.SalesReportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalesReports");
        }
    }
}
