namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "productImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "productImage", c => c.Binary());
        }
    }
}
