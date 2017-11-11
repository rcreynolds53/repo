namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transmissions", "TransmissionName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transmissions", "TransmissionName", c => c.String());
        }
    }
}
