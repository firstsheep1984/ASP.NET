namespace BlogMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2823048c-8cd6-401a-831d-6f00a5ab1339', N'Yang', N'test@g.com', 0, N'AEsX/UOznxJWqYsi3rz0OPdtvKvxynbGoVIF/WpzPsaLapN3V0SXdfGzslXJO5g3MQ==', N'b560ea93-c2e8-4c22-a147-48ecd334fec2', NULL, 0, 0, NULL, 1, 0, N'test@g.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'CanManage')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2823048c-8cd6-401a-831d-6f00a5ab1339', N'1')"
            );
        }
        
        public override void Down()
        {
        }
    }
}
