namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                "dbo.Category_vm",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductPrice = c.Double(nullable: false),
                        ProductDescription = c.String(),
                        ProductImage = c.String(),
                        Quantity = c.Int(nullable: false),
                        ReloadValue = c.Int(nullable: false),
                        ProductWeight = c.Double(nullable: false),
                        ProductLength = c.Double(nullable: false),
                        ProductWidth = c.Double(nullable: false),
                        ProductHeight = c.Double(nullable: false),
                        ConditionId_ConditionId = c.Int(),
                        ManufactureId_ManufactureId = c.Int(),
                        Promotions_PromotionId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Conditions", t => t.ConditionId_ConditionId)
                .ForeignKey("dbo.Manufactures", t => t.ManufactureId_ManufactureId)
                .ForeignKey("dbo.Promotions", t => t.Promotions_PromotionId)
                .Index(t => t.ConditionId_ConditionId)
                .Index(t => t.ManufactureId_ManufactureId)
                .Index(t => t.Promotions_PromotionId);
            
            CreateTable(
                "dbo.Conditions",
                c => new
                    {
                        ConditionId = c.Int(nullable: false, identity: true),
                        Quality = c.String(),
                    })
                .PrimaryKey(t => t.ConditionId);
            
            CreateTable(
                "dbo.Manufactures",
                c => new
                    {
                        ManufactureId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ManufactureId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PartNumber = c.String(),
                        Manufacture_ManufactureId = c.Int(),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Manufactures", t => t.Manufacture_ManufactureId)
                .Index(t => t.Manufacture_ManufactureId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PromotionName = c.String(),
                        PercentageOff = c.Double(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            CreateTable(
                "dbo.Product_vm",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductPrice = c.Double(nullable: false),
                        ProductDescription = c.String(),
                        Quantity = c.Int(nullable: false),
                        ReloadValue = c.Int(nullable: false),
                        ProductImage = c.String(),
                        ProductWeight = c.Double(nullable: false),
                        ProductLength = c.Double(nullable: false),
                        ProductWidth = c.Double(nullable: false),
                        ProductHeight = c.Double(nullable: false),
                        PromotionId_PromotionId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Promotion_vm", t => t.PromotionId_PromotionId)
                .Index(t => t.PromotionId_PromotionId);
            
            CreateTable(
                "dbo.Promotion_vm",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PercentageOff = c.Double(nullable: false),
                        PromotionName = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            CreateTable(
                "dbo.PromotionAddForms",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PercentageOff = c.Double(nullable: false),
                        PromotionName = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ProductList_DataGroupField = c.String(),
                        ProductList_DataTextField = c.String(),
                        ProductList_DataValueField = c.String(),
                    })
                .PrimaryKey(t => t.PromotionId);
            
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
                        gender_GenderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.address_AddressId)
                .ForeignKey("dbo.Genders", t => t.gender_GenderId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.address_AddressId)
                .Index(t => t.gender_GenderId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        StreetNumber = c.Int(nullable: false),
                        City_CityId = c.Int(),
                        Country_CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Cities", t => t.City_CityId)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId)
                .Index(t => t.City_CityId)
                .Index(t => t.Country_CountryId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId)
                .Index(t => t.Country_CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
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
                        GenderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
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
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Category_CategoryId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "gender_GenderId", "dbo.Genders");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "City_CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Product_vm", "PromotionId_PromotionId", "dbo.Promotion_vm");
            DropForeignKey("dbo.Products", "Promotions_PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.Products", "ManufactureId_ManufactureId", "dbo.Manufactures");
            DropForeignKey("dbo.Models", "Manufacture_ManufactureId", "dbo.Manufactures");
            DropForeignKey("dbo.Products", "ConditionId_ConditionId", "dbo.Conditions");
            DropForeignKey("dbo.ProductCategories", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Category_CategoryId" });
            DropIndex("dbo.ProductCategories", new[] { "Product_ProductId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Cities", new[] { "Country_CountryId" });
            DropIndex("dbo.Addresses", new[] { "Country_CountryId" });
            DropIndex("dbo.Addresses", new[] { "City_CityId" });
            DropIndex("dbo.AspNetUsers", new[] { "gender_GenderId" });
            DropIndex("dbo.AspNetUsers", new[] { "address_AddressId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Product_vm", new[] { "PromotionId_PromotionId" });
            DropIndex("dbo.Models", new[] { "Manufacture_ManufactureId" });
            DropIndex("dbo.Products", new[] { "Promotions_PromotionId" });
            DropIndex("dbo.Products", new[] { "ManufactureId_ManufactureId" });
            DropIndex("dbo.Products", new[] { "ConditionId_ConditionId" });
            DropTable("dbo.ProductCategories");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Genders");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Addresses");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RoleClaims");
            DropTable("dbo.PromotionAddForms");
            DropTable("dbo.Promotion_vm");
            DropTable("dbo.Product_vm");
            DropTable("dbo.Promotions");
            DropTable("dbo.Models");
            DropTable("dbo.Manufactures");
            DropTable("dbo.Conditions");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Category_vm");
            DropTable("dbo.ApplicationUserBases");
        }
    }
}
