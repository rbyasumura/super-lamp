namespace Kendo.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _008 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Divisions", "Registrant_RegistrantId", "dbo.Registrants");
            DropIndex("dbo.Divisions", new[] { "Registrant_RegistrantId" });
            CreateTable(
                "dbo.RegistrantDivisions",
                c => new
                    {
                        Registrant_RegistrantId = c.Guid(nullable: false),
                        Division_DivisionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Registrant_RegistrantId, t.Division_DivisionId })
                .ForeignKey("dbo.Registrants", t => t.Registrant_RegistrantId, cascadeDelete: true)
                .ForeignKey("dbo.Divisions", t => t.Division_DivisionId, cascadeDelete: true)
                .Index(t => t.Registrant_RegistrantId)
                .Index(t => t.Division_DivisionId);
            
            DropColumn("dbo.Divisions", "Registrant_RegistrantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Divisions", "Registrant_RegistrantId", c => c.Guid());
            DropForeignKey("dbo.RegistrantDivisions", "Division_DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.RegistrantDivisions", "Registrant_RegistrantId", "dbo.Registrants");
            DropIndex("dbo.RegistrantDivisions", new[] { "Division_DivisionId" });
            DropIndex("dbo.RegistrantDivisions", new[] { "Registrant_RegistrantId" });
            DropTable("dbo.RegistrantDivisions");
            CreateIndex("dbo.Divisions", "Registrant_RegistrantId");
            AddForeignKey("dbo.Divisions", "Registrant_RegistrantId", "dbo.Registrants", "RegistrantId");
        }
    }
}
