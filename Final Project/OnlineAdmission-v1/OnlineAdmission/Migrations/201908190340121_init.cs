namespace OnlineAdmission.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applications", "Photo", c => c.Binary());
        }
    }
}
