namespace OnlineAdmission.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changephototobyte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applications", "Photo", c => c.String());
        }
    }
}
