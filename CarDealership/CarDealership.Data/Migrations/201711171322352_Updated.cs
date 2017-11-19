namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "Count");
            DropColumn("dbo.Vehicles", "StockValue");
            DropColumn("dbo.Vehicles", "Discriminator");
            DropColumn("dbo.Invoices", "TotalSales");
            DropColumn("dbo.Invoices", "TotalVehicles");
            DropColumn("dbo.Invoices", "FromDate");
            DropColumn("dbo.Invoices", "ToDate");
            DropColumn("dbo.Invoices", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Invoices", "ToDate", c => c.DateTime());
            AddColumn("dbo.Invoices", "FromDate", c => c.DateTime());
            AddColumn("dbo.Invoices", "TotalVehicles", c => c.Int());
            AddColumn("dbo.Invoices", "TotalSales", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Vehicles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Vehicles", "StockValue", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Vehicles", "Count", c => c.Int());
        }
    }
}
