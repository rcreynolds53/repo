namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatesGone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "StateAbbreviation", "dbo.States");
            DropForeignKey("dbo.Invoices", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Customers", new[] { "StateAbbreviation" });
            DropIndex("dbo.Invoices", new[] { "Customer_CustomerId" });
            AddColumn("dbo.Vehicles", "IsFeatured", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vehicles", "IsVehicleSold", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "Name", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "StateAb", c => c.String());
            AddColumn("dbo.Customers", "PurchasePrice", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Vehicle_VehicleId", c => c.Int());
            AddColumn("dbo.Invoices", "Name", c => c.String());
            AddColumn("dbo.Invoices", "Email", c => c.String());
            AddColumn("dbo.Invoices", "Street1", c => c.String());
            AddColumn("dbo.Invoices", "Street2", c => c.String());
            AddColumn("dbo.Invoices", "City", c => c.String());
            AddColumn("dbo.Invoices", "StateAb", c => c.String());
            AddColumn("dbo.Invoices", "ZipCode", c => c.String());
            AddColumn("dbo.Invoices", "Phone", c => c.String());
            AlterColumn("dbo.Customers", "Phone", c => c.String());
            AlterColumn("dbo.Invoices", "PurchasePrice", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "Vehicle_VehicleId");
            AddForeignKey("dbo.Customers", "Vehicle_VehicleId", "dbo.Vehicles", "VehicleId");
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "StateAbbreviation");
            DropColumn("dbo.Invoices", "Customer_CustomerId");
            DropTable("dbo.States");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateAbbreviation = c.String(nullable: false, maxLength: 128),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateAbbreviation);
            
            AddColumn("dbo.Invoices", "Customer_CustomerId", c => c.Int());
            AddColumn("dbo.Customers", "StateAbbreviation", c => c.String(maxLength: 128));
            AddColumn("dbo.Customers", "LastName", c => c.String());
            AddColumn("dbo.Customers", "FirstName", c => c.String());
            DropForeignKey("dbo.Customers", "Vehicle_VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Customers", new[] { "Vehicle_VehicleId" });
            AlterColumn("dbo.Invoices", "PurchasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Customers", "Phone", c => c.Int(nullable: false));
            DropColumn("dbo.Invoices", "Phone");
            DropColumn("dbo.Invoices", "ZipCode");
            DropColumn("dbo.Invoices", "StateAb");
            DropColumn("dbo.Invoices", "City");
            DropColumn("dbo.Invoices", "Street2");
            DropColumn("dbo.Invoices", "Street1");
            DropColumn("dbo.Invoices", "Email");
            DropColumn("dbo.Invoices", "Name");
            DropColumn("dbo.Customers", "Vehicle_VehicleId");
            DropColumn("dbo.Customers", "PurchasePrice");
            DropColumn("dbo.Customers", "StateAb");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Name");
            DropColumn("dbo.Vehicles", "IsVehicleSold");
            DropColumn("dbo.Vehicles", "IsFeatured");
            CreateIndex("dbo.Invoices", "Customer_CustomerId");
            CreateIndex("dbo.Customers", "StateAbbreviation");
            AddForeignKey("dbo.Invoices", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Customers", "StateAbbreviation", "dbo.States", "StateAbbreviation");
        }
    }
}
