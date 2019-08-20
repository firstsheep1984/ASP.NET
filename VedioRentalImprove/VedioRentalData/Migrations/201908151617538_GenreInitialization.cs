namespace VedioRentalData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreInitialization : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Action')
                INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Thriller')
                INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Family')
                INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Romance')
                INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (5, N'Comedy')"
            );
        }
        
        public override void Down()
        {
        }
    }
}
