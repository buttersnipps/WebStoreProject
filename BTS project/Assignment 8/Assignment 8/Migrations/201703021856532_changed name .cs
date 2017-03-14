namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PromotionEditForms", "ProductIdToEdit", c => c.Int(nullable: false));
            DropColumn("dbo.PromotionEditForms", "ProductIds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PromotionEditForms", "ProductIds", c => c.Int(nullable: false));
            DropColumn("dbo.PromotionEditForms", "ProductIdToEdit");
        }
    }
}
