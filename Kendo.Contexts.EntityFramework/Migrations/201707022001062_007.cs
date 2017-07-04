namespace Kendo.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _007 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Registrants", "Division_DivisionId", "dbo.Divisions");
            DropIndex("dbo.Registrants", new[] { "Division_DivisionId" });
            AddColumn("dbo.Divisions", "Registrant_RegistrantId", c => c.Guid());
            CreateIndex("dbo.Divisions", "Registrant_RegistrantId");
            AddForeignKey("dbo.Divisions", "Registrant_RegistrantId", "dbo.Registrants", "RegistrantId");
            DropColumn("dbo.Registrants", "Division_DivisionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registrants", "Division_DivisionId", c => c.Guid());
            DropForeignKey("dbo.Divisions", "Registrant_RegistrantId", "dbo.Registrants");
            DropIndex("dbo.Divisions", new[] { "Registrant_RegistrantId" });
            DropColumn("dbo.Divisions", "Registrant_RegistrantId");
            CreateIndex("dbo.Registrants", "Division_DivisionId");
            AddForeignKey("dbo.Registrants", "Division_DivisionId", "dbo.Divisions", "DivisionId");
        }
    }
}
