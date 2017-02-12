namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Promotions_PromotionId", newName: "Promotion_PromotionId");
            RenameIndex(table: "dbo.Products", name: "IX_Promotions_PromotionId", newName: "IX_Promotion_PromotionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_Promotion_PromotionId", newName: "IX_Promotions_PromotionId");
            RenameColumn(table: "dbo.Products", name: "Promotion_PromotionId", newName: "Promotions_PromotionId");
        }
    }
}
