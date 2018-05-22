namespace CloudService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CheckNumber", c => c.String());
            AddColumn("dbo.Orders", "CheckID", c => c.String());
            AddColumn("dbo.Orders", "VerificationResultCode", c => c.String());
            AddColumn("dbo.Orders", "VerificationResultDesc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "VerificationResultDesc");
            DropColumn("dbo.Orders", "VerificationResultCode");
            DropColumn("dbo.Orders", "CheckID");
            DropColumn("dbo.Orders", "CheckNumber");
        }
    }
}
