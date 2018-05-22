namespace CloudService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "GPResult", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "GPResult");
        }
    }
}
