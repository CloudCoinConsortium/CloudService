namespace CloudService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class three : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OnesOrdered", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "FivesOrdered", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TwentyFivesOrdered", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "HundredsOrdered", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TwoHundredFiftiesOrdered", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TotalCoinsOrdered", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalCoinsOrdered");
            DropColumn("dbo.Orders", "TwoHundredFiftiesOrdered");
            DropColumn("dbo.Orders", "HundredsOrdered");
            DropColumn("dbo.Orders", "TwentyFivesOrdered");
            DropColumn("dbo.Orders", "FivesOrdered");
            DropColumn("dbo.Orders", "OnesOrdered");
        }
    }
}
