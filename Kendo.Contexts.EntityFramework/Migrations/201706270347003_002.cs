namespace Kendo.Contexts.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        ClubId = c.Guid(nullable: false),
                        Name = c.String(),
                        Address_AddressId = c.Guid(),
                        Member_PersonId = c.Guid(),
                    })
                .PrimaryKey(t => t.ClubId)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .ForeignKey("dbo.People", t => t.Member_PersonId)
                .Index(t => t.Address_AddressId)
                .Index(t => t.Member_PersonId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Guid(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Country_CountryId = c.String(maxLength: 128),
                        State_StateId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId)
                .ForeignKey("dbo.States", t => t.State_StateId)
                .Index(t => t.Country_CountryId)
                .Index(t => t.State_StateId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Country_CountryId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StateId)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId)
                .Index(t => t.Country_CountryId);
            
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        RankId = c.Guid(nullable: false),
                        RankNumber = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Title = c.Int(nullable: false),
                        Discipline = c.Int(nullable: false),
                        ObtainedAt = c.DateTime(nullable: false),
                        Member_PersonId = c.Guid(),
                    })
                .PrimaryKey(t => t.RankId)
                .ForeignKey("dbo.People", t => t.Member_PersonId)
                .Index(t => t.Member_PersonId);
            
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ranks", "Member_PersonId", "dbo.People");
            DropForeignKey("dbo.Clubs", "Member_PersonId", "dbo.People");
            DropForeignKey("dbo.Clubs", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "State_StateId", "dbo.States");
            DropForeignKey("dbo.States", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "Country_CountryId", "dbo.Countries");
            DropIndex("dbo.Ranks", new[] { "Member_PersonId" });
            DropIndex("dbo.States", new[] { "Country_CountryId" });
            DropIndex("dbo.Addresses", new[] { "State_StateId" });
            DropIndex("dbo.Addresses", new[] { "Country_CountryId" });
            DropIndex("dbo.Clubs", new[] { "Member_PersonId" });
            DropIndex("dbo.Clubs", new[] { "Address_AddressId" });
            DropColumn("dbo.People", "Discriminator");
            DropTable("dbo.Ranks");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
            DropTable("dbo.Clubs");
        }
    }
}
