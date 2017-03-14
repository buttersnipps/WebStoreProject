namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtypetoint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PromotionEditForms", "ProductIds", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PromotionEditForms", "ProductIds");
        }
    }
}
