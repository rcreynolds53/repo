namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComputeDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarMakes", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.CarModels", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarModels", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CarMakes", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
