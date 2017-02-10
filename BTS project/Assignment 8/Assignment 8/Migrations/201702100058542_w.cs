namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class w : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product_vm",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        productPrice = c.Double(nullable: false),
                        productDescription = c.String(),
                        productImage = c.String(),
                        productWeight = c.Double(nullable: false),
                        productLenght = c.Double(nullable: false),
                        productBreath = c.Double(nullable: false),
                        productHeight = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CategoryList_DataGroupField = c.String(),
                        CategoryList_DataTextField = c.String(),
                        CategoryList_DataValueField = c.String(),
                        CategoryName = c.String(),
                        productPromo_promotionId = c.Int(),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.Promotion_vm", t => t.productPromo_promotionId)
                .Index(t => t.productPromo_promotionId);
            
            CreateTable(
                "dbo.Promotion_vm",
                c => new
                    {
                        promotionId = c.Int(nullable: false, identity: true),
                        promotionPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.promotionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_vm", "productPromo_promotionId", "dbo.Promotion_vm");
            DropIndex("dbo.Product_vm", new[] { "productPromo_promotionId" });
            DropTable("dbo.Promotion_vm");
            DropTable("dbo.Product_vm");
        }
    }
}
