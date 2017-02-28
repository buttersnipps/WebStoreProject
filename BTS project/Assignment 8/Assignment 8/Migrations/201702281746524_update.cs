namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionEditForms", "PromotionId");
            DropColumn("dbo.PromotionEditForms", "ProductsList_DataGroupField");
            DropColumn("dbo.PromotionEditForms", "ProductsList_DataTextField");
            DropColumn("dbo.PromotionEditForms", "ProductsList_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PromotionEditForms", "ProductsList_DataValueField", c => c.String());
            AddColumn("dbo.PromotionEditForms", "ProductsList_DataTextField", c => c.String());
            AddColumn("dbo.PromotionEditForms", "ProductsList_DataGroupField", c => c.String());
            DropForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionEditForms");
        }
    }
}
