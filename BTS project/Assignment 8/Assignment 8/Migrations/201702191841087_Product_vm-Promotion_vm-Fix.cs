namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_vmPromotion_vmFix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Promotion_vm", newName: "PromotionAddForms");
            CreateTable(
                "dbo.Promotion_vm",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PercentageOff = c.Double(nullable: false),
                        PromotionName = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            AddColumn("dbo.Product_vm", "PromotionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product_vm", "PromotionId");
            AddForeignKey("dbo.Product_vm", "PromotionId", "dbo.Promotion_vm", "PromotionId");
            AddForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionAddForms", "PromotionId");
            DropColumn("dbo.PromotionAddForms", "ProductList_DataGroupField");
            DropColumn("dbo.PromotionAddForms", "ProductList_DataTextField");
            DropColumn("dbo.PromotionAddForms", "ProductList_DataValueField");
            DropColumn("dbo.PromotionAddForms", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PromotionAddForms", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.PromotionAddForms", "ProductList_DataValueField", c => c.String());
            AddColumn("dbo.PromotionAddForms", "ProductList_DataTextField", c => c.String());
            AddColumn("dbo.PromotionAddForms", "ProductList_DataGroupField", c => c.String());
            DropForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionAddForms");
            DropForeignKey("dbo.Product_vm", "PromotionId", "dbo.Promotion_vm");
            DropIndex("dbo.Product_vm", new[] { "PromotionId" });
            DropColumn("dbo.Product_vm", "PromotionId");
            DropTable("dbo.Promotion_vm");
            RenameTable(name: "dbo.PromotionAddForms", newName: "Promotion_vm");
        }
    }
}
