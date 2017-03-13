namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesReportAdds",
                c => new
                    {
                        SalesReportId = c.Int(nullable: false, identity: true),
                        SalesReportName = c.String(),
                        Month = c.DateTime(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesReportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalesReportAdds");
        }
    }
}
