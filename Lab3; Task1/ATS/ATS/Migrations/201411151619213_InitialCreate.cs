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
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Cost = c.Int(nullable: false),
                        Duration = c.Time(nullable: false, precision: 0),
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
                        LastTariffPlanChanged = c.DateTime(nullable: false, storeType: "date"),
                        DateOfLoan = c.DateTime(nullable: false, storeType: "date"),
                        ExpiryDateOfLoan = c.DateTime(nullable: false, storeType: "date"),
                        LoanAmount = c.Int(nullable: false),
                        TerminalId = c.Int(nullable: false),
                        TelephoneNumberId = c.Int(nullable: false),
                        TariffPlanId = c.Int(nullable: false),
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
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Ports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Assigned = c.Boolean(nullable: false, defaultValue: false),
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
