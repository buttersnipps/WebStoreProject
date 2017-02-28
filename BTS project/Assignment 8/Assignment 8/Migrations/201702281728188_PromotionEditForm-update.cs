namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PromotionEditFormupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionEditForms");
            AddColumn("dbo.PromotionEditForms", "ProductsList_DataGroupField", c => c.String());
            AddColumn("dbo.PromotionEditForms", "ProductsList_DataTextField", c => c.String());
            AddColumn("dbo.PromotionEditForms", "ProductsList_DataValueField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PromotionEditForms", "ProductsList_DataValueField");
            DropColumn("dbo.PromotionEditForms", "ProductsList_DataTextField");
            DropColumn("dbo.PromotionEditForms", "ProductsList_DataGroupField");
            AddForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionEditForms", "PromotionId");
        }
    }
}
