namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Count", c => c.Int());
            AddColumn("dbo.Vehicles", "StockValue", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Vehicles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Invoices", "TotalSales", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Invoices", "TotalVehicles", c => c.Int());
            AddColumn("dbo.Invoices", "FromDate", c => c.DateTime());
            AddColumn("dbo.Invoices", "ToDate", c => c.DateTime());
            AddColumn("dbo.Invoices", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Discriminator");
            DropColumn("dbo.Invoices", "ToDate");
            DropColumn("dbo.Invoices", "FromDate");
            DropColumn("dbo.Invoices", "TotalVehicles");
            DropColumn("dbo.Invoices", "TotalSales");
            DropColumn("dbo.Vehicles", "Discriminator");
            DropColumn("dbo.Vehicles", "StockValue");
            DropColumn("dbo.Vehicles", "Count");
        }
    }
}
