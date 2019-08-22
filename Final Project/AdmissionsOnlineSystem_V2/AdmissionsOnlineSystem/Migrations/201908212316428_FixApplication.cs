namespace AdmissionsOnlineSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "RegistrationDate", c => c.DateTime());
            AddColumn("dbo.Applications", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "Status");
            DropColumn("dbo.Applications", "RegistrationDate");
        }
    }
}
