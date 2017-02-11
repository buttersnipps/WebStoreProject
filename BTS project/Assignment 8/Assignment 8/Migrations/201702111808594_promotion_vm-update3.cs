namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promotion_vmupdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotion_vm", "ProductList_DataGroupField", c => c.String());
            AddColumn("dbo.Promotion_vm", "ProductList_DataTextField", c => c.String());
            AddColumn("dbo.Promotion_vm", "ProductList_DataValueField", c => c.String());
            AddColumn("dbo.Promotion_vm", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Promotion_vm", "PercentageOff", c => c.Double());
            AlterColumn("dbo.Promotion_vm", "BeginDate", c => c.DateTime());
            AlterColumn("dbo.Promotion_vm", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Promotion_vm", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Promotion_vm", "BeginDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Promotion_vm", "PercentageOff", c => c.Double(nullable: false));
            DropColumn("dbo.Promotion_vm", "Discriminator");
            DropColumn("dbo.Promotion_vm", "ProductList_DataValueField");
            DropColumn("dbo.Promotion_vm", "ProductList_DataTextField");
            DropColumn("dbo.Promotion_vm", "ProductList_DataGroupField");
        }
    }
}
