namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyStyles",
                c => new
                    {
                        BodyStyleId = c.Int(nullable: false, identity: true),
                        BodyStyleName = c.String(),
                    })
                .PrimaryKey(t => t.BodyStyleId);
            
            CreateTable(
                "dbo.CarMakes",
                c => new
                    {
                        CarMakeId = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CarMakeId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        CarModelId = c.Int(nullable: false, identity: true),
                        CarModelName = c.String(),
                        CarMakeId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CarModelId)
                .ForeignKey("dbo.CarMakes", t => t.CarMakeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CarMakeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ContactRequests",
                c => new
                    {
                        ContactRequestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                        RequestTime = c.DateTime(nullable: false),
                        ResponseTime = c.DateTime(nullable: false),
                        Vin = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContactRequestId)
                .ForeignKey("dbo.Vehicles", t => t.Vin)
                .Index(t => t.Vin);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Vin = c.String(nullable: false, maxLength: 128),
                        CarModelId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        Msrp = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransmissionId = c.Int(nullable: false),
                        InteriorColorId = c.Int(nullable: false),
                        ExteriorColorId = c.Int(nullable: false),
                        BodyStyleId = c.Int(nullable: false),
                        VehicleTypeId = c.Int(nullable: false),
                        PromoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Vin)
                .ForeignKey("dbo.BodyStyles", t => t.BodyStyleId, cascadeDelete: true)
                .ForeignKey("dbo.CarModels", t => t.CarModelId, cascadeDelete: true)
                .ForeignKey("dbo.ExteriorColors", t => t.ExteriorColorId, cascadeDelete: true)
                .ForeignKey("dbo.InteriorColors", t => t.InteriorColorId, cascadeDelete: true)
                .ForeignKey("dbo.Promoes", t => t.PromoId, cascadeDelete: true)
                .ForeignKey("dbo.Transmissions", t => t.TransmissionId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.CarModelId)
                .Index(t => t.TransmissionId)
                .Index(t => t.InteriorColorId)
                .Index(t => t.ExteriorColorId)
                .Index(t => t.BodyStyleId)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.PromoId);
            
            CreateTable(
                "dbo.ExteriorColors",
                c => new
                    {
                        ExteriorColorId = c.Int(nullable: false, identity: true),
                        ExteriorColorName = c.String(),
                    })
                .PrimaryKey(t => t.ExteriorColorId);
            
            CreateTable(
                "dbo.InteriorColors",
                c => new
                    {
                        InteriorColorId = c.Int(nullable: false, identity: true),
                        InteriorColorName = c.String(),
                    })
                .PrimaryKey(t => t.InteriorColorId);
            
            CreateTable(
                "dbo.Promoes",
                c => new
                    {
                        PromoId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PromoId);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        TransmissionId = c.Int(nullable: false, identity: true),
                        TransmissionType = c.String(),
                        TransmissionName = c.String(),
                    })
                .PrimaryKey(t => t.TransmissionId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeId = c.Int(nullable: false, identity: true),
                        VehicleTypeName = c.String(),
                    })
                .PrimaryKey(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        StateAbbreviation = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.States", t => t.StateAbbreviation)
                .Index(t => t.StateAbbreviation);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateAbbreviation = c.String(nullable: false, maxLength: 128),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateAbbreviation);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseTypeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Vin = c.String(maxLength: 128),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseTypes", t => t.PurchaseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Vehicles", t => t.Vin)
                .Index(t => t.PurchaseTypeId)
                .Index(t => t.CustomerId)
                .Index(t => t.Vin)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeId = c.Int(nullable: false, identity: true),
                        PurchaseTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTypeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Invoices", "Vin", "dbo.Vehicles");
            DropForeignKey("dbo.Invoices", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invoices", "PurchaseTypeId", "dbo.PurchaseTypes");
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "StateAbbreviation", "dbo.States");
            DropForeignKey("dbo.ContactRequests", "Vin", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "TransmissionId", "dbo.Transmissions");
            DropForeignKey("dbo.Vehicles", "PromoId", "dbo.Promoes");
            DropForeignKey("dbo.Vehicles", "InteriorColorId", "dbo.InteriorColors");
            DropForeignKey("dbo.Vehicles", "ExteriorColorId", "dbo.ExteriorColors");
            DropForeignKey("dbo.Vehicles", "CarModelId", "dbo.CarModels");
            DropForeignKey("dbo.Vehicles", "BodyStyleId", "dbo.BodyStyles");
            DropForeignKey("dbo.CarModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CarModels", "CarMakeId", "dbo.CarMakes");
            DropForeignKey("dbo.CarMakes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Invoices", new[] { "UserId" });
            DropIndex("dbo.Invoices", new[] { "Vin" });
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropIndex("dbo.Invoices", new[] { "PurchaseTypeId" });
            DropIndex("dbo.Customers", new[] { "StateAbbreviation" });
            DropIndex("dbo.Vehicles", new[] { "PromoId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            DropIndex("dbo.Vehicles", new[] { "BodyStyleId" });
            DropIndex("dbo.Vehicles", new[] { "ExteriorColorId" });
            DropIndex("dbo.Vehicles", new[] { "InteriorColorId" });
            DropIndex("dbo.Vehicles", new[] { "TransmissionId" });
            DropIndex("dbo.Vehicles", new[] { "CarModelId" });
            DropIndex("dbo.ContactRequests", new[] { "Vin" });
            DropIndex("dbo.CarModels", new[] { "UserId" });
            DropIndex("dbo.CarModels", new[] { "CarMakeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CarMakes", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Invoices");
            DropTable("dbo.States");
            DropTable("dbo.Customers");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Promoes");
            DropTable("dbo.InteriorColors");
            DropTable("dbo.ExteriorColors");
            DropTable("dbo.Vehicles");
            DropTable("dbo.ContactRequests");
            DropTable("dbo.CarModels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CarMakes");
            DropTable("dbo.BodyStyles");
        }
    }
}
