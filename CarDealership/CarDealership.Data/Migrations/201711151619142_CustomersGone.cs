namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomersGone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Vehicle_VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Customers", new[] { "Vehicle_VehicleId" });
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        StateAb = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Phone = c.String(),
                        PurchasePrice = c.Int(nullable: false),
                        Vehicle_VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateIndex("dbo.Customers", "Vehicle_VehicleId");
            AddForeignKey("dbo.Customers", "Vehicle_VehicleId", "dbo.Vehicles", "VehicleId");
        }
    }
}
