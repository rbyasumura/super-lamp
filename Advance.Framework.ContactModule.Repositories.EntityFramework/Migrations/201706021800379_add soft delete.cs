namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsoftdelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "DeletedAt", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.PhoneNumbers", "DeletedAt", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhoneNumbers", "DeletedAt");
            DropColumn("dbo.People", "DeletedAt");
        }
    }
}
