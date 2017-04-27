namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                {
                    PersonId = c.Guid(nullable: false),
                    FirstName = c.String(),
                    LastName = c.String(),
                    DateOfBirth = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.PersonId);

        }

        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
