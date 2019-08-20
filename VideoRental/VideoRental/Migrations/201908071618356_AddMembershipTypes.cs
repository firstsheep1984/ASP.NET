namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[MembershipTypes] ([Id], [Name], [SignUpFee], [DurationInMonths], [DiscountRate]) VALUES (1, N'Pay as you go', 0, 0, 0)
            INSERT INTO [dbo].[MembershipTypes] ([Id], [Name], [SignUpFee], [DurationInMonths], [DiscountRate]) VALUES (2, N'Monthly', 30, 1, 10)
            INSERT INTO [dbo].[MembershipTypes] ([Id], [Name], [SignUpFee], [DurationInMonths], [DiscountRate]) VALUES (3, N'Quarterly', 90, 3, 15)
            INSERT INTO [dbo].[MembershipTypes] ([Id], [Name], [SignUpFee], [DurationInMonths], [DiscountRate]) VALUES (4, N'Annual', 300, 12, 20)
            ");
        }
        
        public override void Down()
        {
        }
    }
}
