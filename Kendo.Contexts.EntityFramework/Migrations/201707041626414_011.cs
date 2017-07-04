namespace Kendo.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _011 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Guid(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                        Club_ClubId = c.Guid(),
                        Tournament_TournamentId = c.Guid(),
                    })
                .PrimaryKey(t => t.RegistrationId)
                .ForeignKey("dbo.Clubs", t => t.Club_ClubId)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_TournamentId)
                .Index(t => t.Club_ClubId)
                .Index(t => t.Tournament_TournamentId);
            
            AddColumn("dbo.Registrants", "Registration_RegistrationId", c => c.Guid());
            CreateIndex("dbo.Registrants", "Registration_RegistrationId");
            AddForeignKey("dbo.Registrants", "Registration_RegistrationId", "dbo.Registrations", "RegistrationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "Tournament_TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.Registrants", "Registration_RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.Registrations", "Club_ClubId", "dbo.Clubs");
            DropIndex("dbo.Registrations", new[] { "Tournament_TournamentId" });
            DropIndex("dbo.Registrations", new[] { "Club_ClubId" });
            DropIndex("dbo.Registrants", new[] { "Registration_RegistrationId" });
            DropColumn("dbo.Registrants", "Registration_RegistrationId");
            DropTable("dbo.Registrations");
        }
    }
}
