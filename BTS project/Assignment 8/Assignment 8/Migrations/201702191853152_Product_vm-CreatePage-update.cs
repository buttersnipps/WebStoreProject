namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_vmCreatePageupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product_vm", "PromotionId", "dbo.Promotion_vm");
            AddColumn("dbo.Product_vm", "Promotion_PromotionId", c => c.Int());
            AddColumn("dbo.Promotion_vm", "Product_vm_ProductId", c => c.Int());
            CreateIndex("dbo.Product_vm", "Promotion_PromotionId");
            CreateIndex("dbo.Promotion_vm", "Product_vm_ProductId");
            AddForeignKey("dbo.Promotion_vm", "Product_vm_ProductId", "dbo.Product_vm", "ProductId");
            AddForeignKey("dbo.Product_vm", "Promotion_PromotionId", "dbo.Promotion_vm", "PromotionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_vm", "Promotion_PromotionId", "dbo.Promotion_vm");
            DropForeignKey("dbo.Promotion_vm", "Product_vm_ProductId", "dbo.Product_vm");
            DropIndex("dbo.Promotion_vm", new[] { "Product_vm_ProductId" });
            DropIndex("dbo.Product_vm", new[] { "Promotion_PromotionId" });
            DropColumn("dbo.Promotion_vm", "Product_vm_ProductId");
            DropColumn("dbo.Product_vm", "Promotion_PromotionId");
            AddForeignKey("dbo.Product_vm", "PromotionId", "dbo.Promotion_vm", "PromotionId");
        }
    }
}
