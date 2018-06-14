namespace CloudService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Affiliate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Affiliate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Affiliate");
        }
    }
}
