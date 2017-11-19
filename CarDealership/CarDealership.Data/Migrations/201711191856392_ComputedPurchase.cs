namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComputedPurchase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "PurchaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "PurchaseDate", c => c.DateTime(nullable: false));
        }
    }
}
