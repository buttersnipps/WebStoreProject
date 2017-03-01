namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Orders_ID", "dbo.Orders");
            DropForeignKey("dbo.Products", "Order_ID", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Orders_ID" });
            DropIndex("dbo.Products", new[] { "Order_ID" });
            RenameColumn(table: "dbo.Orders", name: "currentOrder_ProductId", newName: "Product_ProductId");
            RenameIndex(table: "dbo.Orders", name: "IX_currentOrder_ProductId", newName: "IX_Product_ProductId");
            CreateTable(
                "dbo.OrderToProducts",
                c => new
                    {
                        OrderToProductID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderToProductID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            DropColumn("dbo.Products", "OrderName");
            DropColumn("dbo.Products", "Orders_ID");
            DropColumn("dbo.Products", "Order_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Order_ID", c => c.Int());
            AddColumn("dbo.Products", "Orders_ID", c => c.Int());
            AddColumn("dbo.Products", "OrderName", c => c.String());
            DropForeignKey("dbo.OrderToProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderToProducts", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderToProducts", new[] { "ProductID" });
            DropIndex("dbo.OrderToProducts", new[] { "OrderID" });
            DropTable("dbo.OrderToProducts");
            RenameIndex(table: "dbo.Orders", name: "IX_Product_ProductId", newName: "IX_currentOrder_ProductId");
            RenameColumn(table: "dbo.Orders", name: "Product_ProductId", newName: "currentOrder_ProductId");
            CreateIndex("dbo.Products", "Order_ID");
            CreateIndex("dbo.Products", "Orders_ID");
            AddForeignKey("dbo.Products", "Order_ID", "dbo.Orders", "ID");
            AddForeignKey("dbo.Products", "Orders_ID", "dbo.Orders", "ID");
        }
    }
}
