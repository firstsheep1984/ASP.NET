namespace VedioRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9b8e8038-52fd-4c30-8d85-ffb927a76ba0', N'123@g.com', 0, N'AEI8rlG6PNv7EVIfIHkWQBD3Ht/QAld/Qjs0nYp8B0NBnKHvLhjy9ISi94uVQpvapQ==', N'e3f071f8-67c3-4c9a-b871-da76126fe9ed', NULL, 0, 0, NULL, 1, 0, N'123@g.com')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'CanManage')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9b8e8038-52fd-4c30-8d85-ffb927a76ba0', N'1')
");
        }
        
        public override void Down()
        {
        }
    }
}
