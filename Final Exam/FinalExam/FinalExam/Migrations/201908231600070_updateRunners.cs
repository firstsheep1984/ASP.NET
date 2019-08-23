namespace FinalExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRunners : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Runners", "State_Id", "dbo.States");
            DropIndex("dbo.Runners", new[] { "State_Id" });
            AddColumn("dbo.Runners", "State", c => c.String());
            DropColumn("dbo.Runners", "State_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Runners", "State_Id", c => c.Int());
            DropColumn("dbo.Runners", "State");
            CreateIndex("dbo.Runners", "State_Id");
            AddForeignKey("dbo.Runners", "State_Id", "dbo.States", "Id");
        }
    }
}
