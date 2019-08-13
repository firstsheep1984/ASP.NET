namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'CanManage')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7247572b-be9b-4a3e-af76-609c91c88a37', N'Ricardo Artola', N'admin@test.com', 0, N'AJeNPsuIbchqKmrZLP10vxjzkIScWsyyb7vSneBfFyVM7/dSTfLdgFXILfRJdseqJw==', N'19581961-50c0-4265-a4f1-378802fe3fc5', NULL, 0, 0, NULL, 1, 0, N'admin@test.com')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7247572b-be9b-4a3e-af76-609c91c88a37', N'1')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
