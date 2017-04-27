namespace Advance.Framework.People.Repositories.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PersonDateOfBirth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "DateOfBirth", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.People", "DateOfBirth");
        }
    }
}
