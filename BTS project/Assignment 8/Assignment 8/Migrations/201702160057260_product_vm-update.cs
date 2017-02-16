namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product_vmupdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Product_vm", new[] { "PromotionId_PromotionId" });
            RenameColumn(table: "dbo.Product_vm", name: "PromotionId_PromotionId", newName: "PromotionId");
            AlterColumn("dbo.Product_vm", "PromotionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product_vm", "PromotionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product_vm", new[] { "PromotionId" });
            AlterColumn("dbo.Product_vm", "PromotionId", c => c.Int());
            RenameColumn(table: "dbo.Product_vm", name: "PromotionId", newName: "PromotionId_PromotionId");
            CreateIndex("dbo.Product_vm", "PromotionId_PromotionId");
        }
    }
}
