namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idFix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "Promotion_PromotionId" });
            RenameColumn(table: "dbo.Products", name: "Promotion_PromotionId", newName: "PromotionId");
            AlterColumn("dbo.Products", "PromotionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "PromotionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "PromotionId" });
            AlterColumn("dbo.Products", "PromotionId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "PromotionId", newName: "Promotion_PromotionId");
            CreateIndex("dbo.Products", "Promotion_PromotionId");
        }
    }
}
