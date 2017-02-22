namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wetoin1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckBoxViewModels", "CheckBoxViewModel_CategoryID", "dbo.CheckBoxViewModels");
            DropForeignKey("dbo.CheckBoxViewModels", "Category_vm_CategoryId", "dbo.Category_vm");
            DropIndex("dbo.CheckBoxViewModels", new[] { "CheckBoxViewModel_CategoryID" });
            DropIndex("dbo.CheckBoxViewModels", new[] { "Category_vm_CategoryId" });
            DropTable("dbo.CheckBoxViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CheckBoxViewModels",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CheckBoxViewModel_CategoryID = c.Int(),
                        Category_vm_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateIndex("dbo.CheckBoxViewModels", "Category_vm_CategoryId");
            CreateIndex("dbo.CheckBoxViewModels", "CheckBoxViewModel_CategoryID");
            AddForeignKey("dbo.CheckBoxViewModels", "Category_vm_CategoryId", "dbo.Category_vm", "CategoryId");
            AddForeignKey("dbo.CheckBoxViewModels", "CheckBoxViewModel_CategoryID", "dbo.CheckBoxViewModels", "CategoryID");
        }
    }
}
