namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roles_changes : DbMigration
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
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category_vm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
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
                        productPromo_promotionId = c.Int(),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.Promotions", t => t.productPromo_promotionId)
                .Index(t => t.productPromo_promotionId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        promotionId = c.Int(nullable: false, identity: true),
                        promotionPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.promotionId);
            
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
            
            CreateTable(
                "dbo.RoleClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        address_AddressId = c.Int(),
                        gender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.address_AddressId)
                .ForeignKey("dbo.Genders", t => t.gender_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.address_AddressId)
                .Index(t => t.gender_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        StreetNumber = c.Int(nullable: false),
                        Country_CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId)
                .Index(t => t.Country_CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        city_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Cities", t => t.city_CityId)
                .Index(t => t.city_CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "gender_Id", "dbo.Genders");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "city_CityId", "dbo.Cities");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Product_vm", "productPromo_promotionId", "dbo.Promotion_vm");
            DropForeignKey("dbo.Products", "productPromo_promotionId", "dbo.Promotions");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Countries", new[] { "city_CityId" });
            DropIndex("dbo.Addresses", new[] { "Country_CountryId" });
            DropIndex("dbo.AspNetUsers", new[] { "gender_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "address_AddressId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Product_vm", new[] { "productPromo_promotionId" });
            DropIndex("dbo.Products", new[] { "productPromo_promotionId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Genders");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Cities");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RoleClaims");
            DropTable("dbo.Promotion_vm");
            DropTable("dbo.Product_vm");
            DropTable("dbo.Promotions");
            DropTable("dbo.Products");
            DropTable("dbo.Category_vm");
            DropTable("dbo.Categories");
            DropTable("dbo.ApplicationUserBases");
        }
    }
}
