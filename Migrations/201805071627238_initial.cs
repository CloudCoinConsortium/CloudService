namespace CloudService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        NameOnCheck = c.String(),
                        EMailAddress = c.String(),
                        PhoneNumber = c.String(),
                        AddressOnCheck = c.String(),
                        CityOnCheck = c.String(),
                        StateOnCheck = c.String(),
                        ZipCodeOnCheck = c.String(),
                        BankName = c.String(),
                        AccountingNumber = c.String(),
                        RoutingNumber = c.String(),
                        TotalPrice = c.Double(nullable: false),
                        ExportFileName = c.String(),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
