namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Products", "Category_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Product_vm", "ProductCategory", c => c.String());
            AddColumn("dbo.Product_vm", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            DropTable("dbo.Category_vm");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Category_vm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.Product_vm", "Discriminator");
            DropColumn("dbo.Product_vm", "ProductCategory");
            DropColumn("dbo.Products", "Category_Id");
            DropColumn("dbo.Categories", "Discriminator");
        }
    }
}
