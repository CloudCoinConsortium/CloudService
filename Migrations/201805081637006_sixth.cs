namespace CloudService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "FileName");
        }
    }
}
