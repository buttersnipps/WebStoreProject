namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promotionDeleteForm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PromotionDeleteForms",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PercentageOff = c.Double(nullable: false),
                        PromotionName = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            AddForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionDeleteForms", "PromotionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionDeleteForms");
            DropTable("dbo.PromotionDeleteForms");
        }
    }
}
