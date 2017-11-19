namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportsFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "PurchaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "PurchaseDate", c => c.DateTime());
        }
    }
}
