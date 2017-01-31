namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserBases",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        GivenName = c.String(),
                        Surname = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicationUserBases");
        }
    }
}
