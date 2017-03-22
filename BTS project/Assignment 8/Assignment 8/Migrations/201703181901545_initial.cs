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
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CartId = c.String(),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ShoppingCartViewModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.ShoppingCartViewModels", t => t.ShoppingCartViewModel_ID)
                .Index(t => t.ProductId)
                .Index(t => t.ShoppingCartViewModel_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductDescription = c.String(),
                        ProductImage = c.String(),
                        Quantity = c.Int(nullable: false),
                        ReloadValue = c.Int(nullable: false),
                        ProductWeight = c.Double(nullable: false),
                        ProductLength = c.Double(nullable: false),
                        ProductWidth = c.Double(nullable: false),
                        ProductHeight = c.Double(nullable: false),
                        PromotionId = c.Int(nullable: false),
                        PromoPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderName = c.String(),
                        Condition_ConditionId = c.Int(),
                        Manufacture_ManufactureId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Conditions", t => t.Condition_ConditionId)
                .ForeignKey("dbo.Manufactures", t => t.Manufacture_ManufactureId)
                .ForeignKey("dbo.Promotions", t => t.PromotionId)
                .Index(t => t.PromotionId)
                .Index(t => t.Condition_ConditionId)
                .Index(t => t.Manufacture_ManufactureId);
            
            CreateTable(
                "dbo.CategoryToProducts",
                c => new
                    {
                        CategoryToProductID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryToProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.CategoryID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDeatilId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDeatilId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PromotionName = c.String(),
                        PercentageOff = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductDescription = c.String(),
                        Quantity = c.Int(nullable: false),
                        ReloadValue = c.Int(nullable: false),
                        ProductImage = c.String(),
                        ProductWeight = c.Double(nullable: false),
                        ProductLength = c.Double(nullable: false),
                        ProductWidth = c.Double(nullable: false),
                        ProductHeight = c.Double(nullable: false),
                        PromotionId = c.Int(nullable: false),
                        PromoPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Promotion_PromotionId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Promotion_vm", t => t.Promotion_PromotionId)
                .ForeignKey("dbo.PromotionAddForms", t => t.PromotionId)
                .ForeignKey("dbo.PromotionDeleteForms", t => t.PromotionId)
                .ForeignKey("dbo.PromotionDetailsPages", t => t.PromotionId)
                .ForeignKey("dbo.PromotionEditForms", t => t.PromotionId)
                .Index(t => t.PromotionId)
                .Index(t => t.Promotion_PromotionId);
            
            CreateTable(
                "dbo.Promotion_vm",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PercentageOff = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionName = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Product_vm_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.PromotionId)
                .ForeignKey("dbo.Product_vm", t => t.Product_vm_ProductId)
                .Index(t => t.Product_vm_ProductId);
            
            CreateTable(
                "dbo.PromotionAddForms",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PercentageOff = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionName = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            CreateTable(
                "dbo.PromotionDeleteForms",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PercentageOff = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionName = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            CreateTable(
                "dbo.PromotionDetailsPages",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PercentageOff = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionName = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            CreateTable(
                "dbo.PromotionEditForms",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        PercentageOff = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionName = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ProductIdToEdit = c.Int(nullable: false),
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
                "dbo.SalesReports",
                c => new
                    {
                        SalesReportId = c.Int(nullable: false, identity: true),
                        SalesReportName = c.String(),
                        Month = c.DateTime(nullable: false),
                        Total = c.Single(nullable: false),
                        PercentageChange = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.SalesReportId);
            
            CreateTable(
                "dbo.ShoppingCartViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CartTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
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
            DropForeignKey("dbo.Carts", "ShoppingCartViewModel_ID", "dbo.ShoppingCartViewModels");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionEditForms");
            DropForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionDetailsPages");
            DropForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionDeleteForms");
            DropForeignKey("dbo.Product_vm", "PromotionId", "dbo.PromotionAddForms");
            DropForeignKey("dbo.Promotion_vm", "Product_vm_ProductId", "dbo.Product_vm");
            DropForeignKey("dbo.Product_vm", "Promotion_PromotionId", "dbo.Promotion_vm");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "Manufacture_ManufactureId", "dbo.Manufactures");
            DropForeignKey("dbo.Models", "Manufacture_ManufactureId", "dbo.Manufactures");
            DropForeignKey("dbo.Products", "Condition_ConditionId", "dbo.Conditions");
            DropForeignKey("dbo.CategoryToProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.CategoryToProducts", "CategoryID", "dbo.Categories");
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
            DropIndex("dbo.Promotion_vm", new[] { "Product_vm_ProductId" });
            DropIndex("dbo.Product_vm", new[] { "Promotion_PromotionId" });
            DropIndex("dbo.Product_vm", new[] { "PromotionId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Models", new[] { "Manufacture_ManufactureId" });
            DropIndex("dbo.CategoryToProducts", new[] { "ProductID" });
            DropIndex("dbo.CategoryToProducts", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "Manufacture_ManufactureId" });
            DropIndex("dbo.Products", new[] { "Condition_ConditionId" });
            DropIndex("dbo.Products", new[] { "PromotionId" });
            DropIndex("dbo.Carts", new[] { "ShoppingCartViewModel_ID" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Genders");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Addresses");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ShoppingCartViewModels");
            DropTable("dbo.SalesReports");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RoleClaims");
            DropTable("dbo.PromotionEditForms");
            DropTable("dbo.PromotionDetailsPages");
            DropTable("dbo.PromotionDeleteForms");
            DropTable("dbo.PromotionAddForms");
            DropTable("dbo.Promotion_vm");
            DropTable("dbo.Product_vm");
            DropTable("dbo.Promotions");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Models");
            DropTable("dbo.Manufactures");
            DropTable("dbo.Conditions");
            DropTable("dbo.Categories");
            DropTable("dbo.CategoryToProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
            DropTable("dbo.ApplicationUserBases");
        }
    }
}
