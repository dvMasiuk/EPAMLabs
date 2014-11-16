namespace ATS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Cost = c.Double(),
                        Duration = c.Time(precision: 0),
                        Ended = c.Boolean(nullable: false),
                        SubscriberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscribers", t => t.SubscriberId)
                .Index(t => t.SubscriberId);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastTariffPlanChanged = c.DateTime(nullable: false),
                        DateOfLoan = c.DateTime(nullable: false),
                        ExpiryDateOfLoan = c.DateTime(nullable: false),
                        LoanAmount = c.Double(nullable: false),
                        TerminalId = c.Int(nullable: false),
                        TelephoneNumberId = c.Int(nullable: false),
                        TariffPlanId = c.Int(nullable: false),
                        PortId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TariffPlans", t => t.TariffPlanId)
                .Index(t => t.TariffPlanId);
            
            CreateTable(
                "dbo.TariffPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        PortState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TelephoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 8, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Terminals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscribers", "TariffPlanId", "dbo.TariffPlans");
            DropForeignKey("dbo.Calls", "SubscriberId", "dbo.Subscribers");
            DropIndex("dbo.Subscribers", new[] { "TariffPlanId" });
            DropIndex("dbo.Calls", new[] { "SubscriberId" });
            DropTable("dbo.Terminals");
            DropTable("dbo.TelephoneNumbers");
            DropTable("dbo.Ports");
            DropTable("dbo.TariffPlans");
            DropTable("dbo.Subscribers");
            DropTable("dbo.Calls");
        }
    }
}
