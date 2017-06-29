namespace Kendo.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrants", "Division_DivisionId", c => c.Guid());
            CreateIndex("dbo.Registrants", "Division_DivisionId");
            AddForeignKey("dbo.Registrants", "Division_DivisionId", "dbo.Divisions", "DivisionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrants", "Division_DivisionId", "dbo.Divisions");
            DropIndex("dbo.Registrants", new[] { "Division_DivisionId" });
            DropColumn("dbo.Registrants", "Division_DivisionId");
        }
    }
}
