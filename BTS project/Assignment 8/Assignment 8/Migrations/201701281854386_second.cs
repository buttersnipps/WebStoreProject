namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product_vm", "productImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product_vm", "productImage", c => c.Binary());
        }
    }
}
