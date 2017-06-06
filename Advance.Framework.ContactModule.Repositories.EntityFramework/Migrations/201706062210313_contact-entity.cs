namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class contactentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People");
            DropIndex("dbo.PhoneNumbers", new[] { "Person_PersonId" });
            CreateTable(
                "dbo.Contacts",
                c => new
                {
                    ContactId = c.Guid(nullable: false),
                    CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    UpdatedAt = c.DateTimeOffset(precision: 7),
                    DeletedAt = c.DateTimeOffset(precision: 7),
                    Person_PersonId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.People", t => t.Person_PersonId, cascadeDelete: true)
                .Index(t => t.Person_PersonId);

            AddColumn("dbo.PhoneNumbers", "Contact_ContactId", c => c.Guid());
            CreateIndex("dbo.PhoneNumbers", "Contact_ContactId");
            AddForeignKey("dbo.PhoneNumbers", "Contact_ContactId", "dbo.Contacts", "ContactId");
            DropColumn("dbo.PhoneNumbers", "Person_PersonId");
        }

        public override void Down()
        {
            AddColumn("dbo.PhoneNumbers", "Person_PersonId", c => c.Guid());
            DropForeignKey("dbo.PhoneNumbers", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Contacts", new[] { "Person_PersonId" });
            DropIndex("dbo.PhoneNumbers", new[] { "Contact_ContactId" });
            DropColumn("dbo.PhoneNumbers", "Contact_ContactId");
            DropTable("dbo.Contacts");
            CreateIndex("dbo.PhoneNumbers", "Person_PersonId");
            AddForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People", "PersonId");
        }
    }
}
