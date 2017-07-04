namespace Kendo.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _009 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tournaments", "Location_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Registrants", "Club_ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Registrants", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Divisions", "Tournament_TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.RegistrantDivisions", "Registrant_RegistrantId", "dbo.Registrants");
            DropForeignKey("dbo.RegistrantDivisions", "Division_DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Registrants", "Rank_RankId", "dbo.Ranks");
            DropForeignKey("dbo.Registrants", "Tournament_TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.Tournaments", "Series_TournamentSeriesId", "dbo.TournamentSeries");
            DropIndex("dbo.Tournaments", new[] { "Location_AddressId" });
            DropIndex("dbo.Tournaments", new[] { "Series_TournamentSeriesId" });
            DropIndex("dbo.Registrants", new[] { "Club_ClubId" });
            DropIndex("dbo.Registrants", new[] { "Contact_ContactId" });
            DropIndex("dbo.Registrants", new[] { "Rank_RankId" });
            DropIndex("dbo.Registrants", new[] { "Tournament_TournamentId" });
            DropIndex("dbo.Divisions", new[] { "Tournament_TournamentId" });
            DropIndex("dbo.RegistrantDivisions", new[] { "Registrant_RegistrantId" });
            DropIndex("dbo.RegistrantDivisions", new[] { "Division_DivisionId" });
            DropTable("dbo.Tournaments");
            DropTable("dbo.Registrants");
            DropTable("dbo.Divisions");
            DropTable("dbo.TournamentSeries");
            DropTable("dbo.RegistrantDivisions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegistrantDivisions",
                c => new
                    {
                        Registrant_RegistrantId = c.Guid(nullable: false),
                        Division_DivisionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Registrant_RegistrantId, t.Division_DivisionId });
            
            CreateTable(
                "dbo.TournamentSeries",
                c => new
                    {
                        TournamentSeriesId = c.Guid(nullable: false),
                        SeriesName = c.String(),
                    })
                .PrimaryKey(t => t.TournamentSeriesId);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        DivisionId = c.Guid(nullable: false),
                        Name = c.String(),
                        Tournament_TournamentId = c.Guid(),
                    })
                .PrimaryKey(t => t.DivisionId);
            
            CreateTable(
                "dbo.Registrants",
                c => new
                    {
                        RegistrantId = c.Guid(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                        Club_ClubId = c.Guid(),
                        Contact_ContactId = c.Guid(),
                        Rank_RankId = c.Guid(),
                        Tournament_TournamentId = c.Guid(),
                    })
                .PrimaryKey(t => t.RegistrantId);
            
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
                .PrimaryKey(t => t.TournamentId);
            
            CreateIndex("dbo.RegistrantDivisions", "Division_DivisionId");
            CreateIndex("dbo.RegistrantDivisions", "Registrant_RegistrantId");
            CreateIndex("dbo.Divisions", "Tournament_TournamentId");
            CreateIndex("dbo.Registrants", "Tournament_TournamentId");
            CreateIndex("dbo.Registrants", "Rank_RankId");
            CreateIndex("dbo.Registrants", "Contact_ContactId");
            CreateIndex("dbo.Registrants", "Club_ClubId");
            CreateIndex("dbo.Tournaments", "Series_TournamentSeriesId");
            CreateIndex("dbo.Tournaments", "Location_AddressId");
            AddForeignKey("dbo.Tournaments", "Series_TournamentSeriesId", "dbo.TournamentSeries", "TournamentSeriesId");
            AddForeignKey("dbo.Registrants", "Tournament_TournamentId", "dbo.Tournaments", "TournamentId");
            AddForeignKey("dbo.Registrants", "Rank_RankId", "dbo.Ranks", "RankId");
            AddForeignKey("dbo.RegistrantDivisions", "Division_DivisionId", "dbo.Divisions", "DivisionId", cascadeDelete: true);
            AddForeignKey("dbo.RegistrantDivisions", "Registrant_RegistrantId", "dbo.Registrants", "RegistrantId", cascadeDelete: true);
            AddForeignKey("dbo.Divisions", "Tournament_TournamentId", "dbo.Tournaments", "TournamentId");
            AddForeignKey("dbo.Registrants", "Contact_ContactId", "dbo.Contacts", "ContactId");
            AddForeignKey("dbo.Registrants", "Club_ClubId", "dbo.Clubs", "ClubId");
            AddForeignKey("dbo.Tournaments", "Location_AddressId", "dbo.Addresses", "AddressId");
        }
    }
}
