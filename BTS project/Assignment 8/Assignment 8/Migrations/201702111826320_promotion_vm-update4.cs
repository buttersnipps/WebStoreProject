namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promotion_vmupdate4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Promotion_vm", "PercentageOff", c => c.Double(nullable: false));
            AlterColumn("dbo.Promotion_vm", "BeginDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Promotion_vm", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Promotion_vm", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Promotion_vm", "BeginDate", c => c.DateTime());
            AlterColumn("dbo.Promotion_vm", "PercentageOff", c => c.Double());
        }
    }
}
