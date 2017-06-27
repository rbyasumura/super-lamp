namespace Kendo.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
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
                        Club_ClubId = c.Guid(),
                        Contact_ContactId = c.Guid(),
                        Rank_RankId = c.Guid(),
                        Tournament_TournamentId = c.Guid(),
                    })
                .PrimaryKey(t => t.RegistrantId)
                .ForeignKey("dbo.Clubs", t => t.Club_ClubId)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId)
                .ForeignKey("dbo.Ranks", t => t.Rank_RankId)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_TournamentId)
                .Index(t => t.Club_ClubId)
                .Index(t => t.Contact_ContactId)
                .Index(t => t.Rank_RankId)
                .Index(t => t.Tournament_TournamentId);
            
            CreateTable(
                "dbo.TournamentSeries",
                c => new
                    {
                        TournamentSeriesId = c.Guid(nullable: false),
                        SeriesName = c.String(),
                    })
                .PrimaryKey(t => t.TournamentSeriesId);
            
            AddColumn("dbo.Contacts", "VersionId", c => c.Guid(nullable: false));
            AddColumn("dbo.Contacts", "PreviousVersionId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournaments", "Series_TournamentSeriesId", "dbo.TournamentSeries");
            DropForeignKey("dbo.Registrants", "Tournament_TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.Registrants", "Rank_RankId", "dbo.Ranks");
            DropForeignKey("dbo.Registrants", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Registrants", "Club_ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Tournaments", "Location_AddressId", "dbo.Addresses");
            DropIndex("dbo.Registrants", new[] { "Tournament_TournamentId" });
            DropIndex("dbo.Registrants", new[] { "Rank_RankId" });
            DropIndex("dbo.Registrants", new[] { "Contact_ContactId" });
            DropIndex("dbo.Registrants", new[] { "Club_ClubId" });
            DropIndex("dbo.Tournaments", new[] { "Series_TournamentSeriesId" });
            DropIndex("dbo.Tournaments", new[] { "Location_AddressId" });
            DropColumn("dbo.Contacts", "PreviousVersionId");
            DropColumn("dbo.Contacts", "VersionId");
            DropTable("dbo.TournamentSeries");
            DropTable("dbo.Registrants");
            DropTable("dbo.Tournaments");
        }
    }
}
