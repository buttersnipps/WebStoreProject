namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtype : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PromotionEditForms", "ProductIds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PromotionEditForms", "ProductIds", c => c.String());
        }
    }
}
