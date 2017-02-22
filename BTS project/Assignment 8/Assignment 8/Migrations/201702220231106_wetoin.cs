namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wetoin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCategories", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.ProductCategories", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductCategories", new[] { "Category_CategoryId" });
            CreateTable(
                "dbo.CheckBoxViewModels",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CheckBoxViewModel_CategoryID = c.Int(),
                        Category_vm_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.CheckBoxViewModels", t => t.CheckBoxViewModel_CategoryID)
                .ForeignKey("dbo.Category_vm", t => t.Category_vm_CategoryId)
                .Index(t => t.CheckBoxViewModel_CategoryID)
                .Index(t => t.Category_vm_CategoryId);
            
            CreateTable(
                "dbo.CategoryToProducts",
                c => new
                    {
                        CategoryToProductID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryToProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.CategoryID)
                .Index(t => t.ProductID);
            
            AddColumn("dbo.Categories", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.Categories", "Product_ProductId");
            AddForeignKey("dbo.Categories", "Product_ProductId", "dbo.Products", "ProductId");
            DropTable("dbo.ProductCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Category_CategoryId });
            
            DropForeignKey("dbo.CategoryToProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Categories", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.CategoryToProducts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.CheckBoxViewModels", "Category_vm_CategoryId", "dbo.Category_vm");
            DropForeignKey("dbo.CheckBoxViewModels", "CheckBoxViewModel_CategoryID", "dbo.CheckBoxViewModels");
            DropIndex("dbo.CategoryToProducts", new[] { "ProductID" });
            DropIndex("dbo.CategoryToProducts", new[] { "CategoryID" });
            DropIndex("dbo.Categories", new[] { "Product_ProductId" });
            DropIndex("dbo.CheckBoxViewModels", new[] { "Category_vm_CategoryId" });
            DropIndex("dbo.CheckBoxViewModels", new[] { "CheckBoxViewModel_CategoryID" });
            DropColumn("dbo.Categories", "Product_ProductId");
            DropTable("dbo.CategoryToProducts");
            DropTable("dbo.CheckBoxViewModels");
            CreateIndex("dbo.ProductCategories", "Category_CategoryId");
            CreateIndex("dbo.ProductCategories", "Product_ProductId");
            AddForeignKey("dbo.ProductCategories", "Category_CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.ProductCategories", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
