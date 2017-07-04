namespace Kendo.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _010 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentId = c.Guid(nullable: false),
                        Name = c.String(),
                        StartAt = c.DateTimeOffset(nullable: false, precision: 7),
                        EndAt = c.DateTimeOffset(precision: 7),
                        Location_AddressId = c.Guid(),
                        Series_TournamentSeriesId = c.Guid(),
                    })
                .PrimaryKey(t => t.TournamentId)
                .ForeignKey("dbo.Addresses", t => t.Location_AddressId)
                .ForeignKey("dbo.TournamentSeries", t => t.Series_TournamentSeriesId)
                .Index(t => t.Location_AddressId)
                .Index(t => t.Series_TournamentSeriesId);
            
            CreateTable(
                "dbo.Registrants",
                c => new
                    {
                        RegistrantId = c.Guid(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                        Contact_ContactId = c.Guid(),
                        Rank_RankId = c.Guid(),
                        Tournament_TournamentId = c.Guid(),
                    })
                .PrimaryKey(t => t.RegistrantId)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId)
                .ForeignKey("dbo.Ranks", t => t.Rank_RankId)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_TournamentId)
                .Index(t => t.Contact_ContactId)
                .Index(t => t.Rank_RankId)
                .Index(t => t.Tournament_TournamentId);
            
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
            
            CreateTable(
                "dbo.TournamentSeries",
                c => new
                    {
                        TournamentSeriesId = c.Guid(nullable: false),
                        SeriesName = c.String(),
                    })
                .PrimaryKey(t => t.TournamentSeriesId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournaments", "Series_TournamentSeriesId", "dbo.TournamentSeries");
            DropForeignKey("dbo.Registrants", "Tournament_TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.Registrants", "Rank_RankId", "dbo.Ranks");
            DropForeignKey("dbo.RegistrantDivisions", "Division_DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.RegistrantDivisions", "Registrant_RegistrantId", "dbo.Registrants");
            DropForeignKey("dbo.Divisions", "Tournament_TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.Registrants", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Tournaments", "Location_AddressId", "dbo.Addresses");
            DropIndex("dbo.RegistrantDivisions", new[] { "Division_DivisionId" });
            DropIndex("dbo.RegistrantDivisions", new[] { "Registrant_RegistrantId" });
            DropIndex("dbo.Divisions", new[] { "Tournament_TournamentId" });
            DropIndex("dbo.Registrants", new[] { "Tournament_TournamentId" });
            DropIndex("dbo.Registrants", new[] { "Rank_RankId" });
            DropIndex("dbo.Registrants", new[] { "Contact_ContactId" });
            DropIndex("dbo.Tournaments", new[] { "Series_TournamentSeriesId" });
            DropIndex("dbo.Tournaments", new[] { "Location_AddressId" });
            DropTable("dbo.RegistrantDivisions");
            DropTable("dbo.TournamentSeries");
            DropTable("dbo.Divisions");
            DropTable("dbo.Registrants");
            DropTable("dbo.Tournaments");
        }
    }
}
