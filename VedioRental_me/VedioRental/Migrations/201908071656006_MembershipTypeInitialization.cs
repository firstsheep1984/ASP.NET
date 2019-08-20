namespace VedioRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeInitialization : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[MembershipTypes] ( [Name],  [SingUpfee], [DurationInMonths], [DiscountRate]) VALUES ( N'Pay as you go', 0, 0,0)

INSERT INTO [dbo].[MembershipTypes] ( [Name],  [SingUpfee], [DurationInMonths], [DiscountRate]) VALUES ( N'Monthly', 50, 6, 40)
INSERT INTO [dbo].[MembershipTypes] ( [Name],  [SingUpfee], [DurationInMonths], [DiscountRate]) VALUES ( N'Seasonly', 70, 9, 60)
INSERT INTO [dbo].[MembershipTypes] ( [Name],  [SingUpfee], [DurationInMonths], [DiscountRate]) VALUES ( N'Yearly', 90, 12, 80)");
        }
        
        public override void Down()
        {
        }
    }
}
