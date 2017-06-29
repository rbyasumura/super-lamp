namespace Kendo.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        DivisionId = c.Guid(nullable: false),
                        Name = c.String(),
                        Tournament_TournamentId = c.Guid(),
                    })
                .PrimaryKey(t => t.DivisionId)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_TournamentId)
                .Index(t => t.Tournament_TournamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Divisions", "Tournament_TournamentId", "dbo.Tournaments");
            DropIndex("dbo.Divisions", new[] { "Tournament_TournamentId" });
            DropTable("dbo.Divisions");
        }
    }
}
