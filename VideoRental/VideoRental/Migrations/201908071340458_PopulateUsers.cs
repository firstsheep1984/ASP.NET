namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bf5270d3-83d7-4682-9a7c-bc95947eb9a9', N'admin@test.com', 0, N'AKBYbpAs+FLhUY8R69jto9jcDEowLaRrdbYo6APMbIoeLJEQds//9nZbzotK+4jFUQ==', N'3d43f2e1-845f-4277-b844-838d92a31a58', NULL, 0, 0, NULL, 1, 0, N'admin@test.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'CanManage')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bf5270d3-83d7-4682-9a7c-bc95947eb9a9', N'1')"
            );
        }
        
        public override void Down()
        {
        }
    }
}
