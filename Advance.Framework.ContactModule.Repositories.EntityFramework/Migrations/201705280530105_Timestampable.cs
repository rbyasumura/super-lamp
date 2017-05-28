namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Timestampable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.People", "UpdatedAt", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.PhoneNumbers", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.PhoneNumbers", "UpdatedAt", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhoneNumbers", "UpdatedAt");
            DropColumn("dbo.PhoneNumbers", "CreatedAt");
            DropColumn("dbo.People", "UpdatedAt");
            DropColumn("dbo.People", "CreatedAt");
        }
    }
}
