namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People");
            DropIndex("dbo.PhoneNumbers", new[] { "Person_PersonId" });
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.People");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                {
                    PersonId = c.Guid(nullable: false),
                    FirstName = c.String(),
                    LastName = c.String(),
                    DateOfBirth = c.DateTime(),
                })
                .PrimaryKey(t => t.PersonId);

            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                {
                    PhoneNumberId = c.Guid(nullable: false),
                    Number = c.String(),
                    Type = c.Int(nullable: false),
                    Person_PersonId = c.Guid(),
                })
                .PrimaryKey(t => t.PhoneNumberId)
                .ForeignKey("dbo.People", t => t.Person_PersonId, cascadeDelete: true)
                .Index(t => t.Person_PersonId);
        }
    }
}