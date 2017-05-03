namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneNumberPersonrequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People");
            DropIndex("dbo.PhoneNumbers", new[] { "Person_PersonId" });
            AlterColumn("dbo.PhoneNumbers", "Person_PersonId", c => c.Guid(nullable: false));
            CreateIndex("dbo.PhoneNumbers", "Person_PersonId");
            AddForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People", "PersonId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People");
            DropIndex("dbo.PhoneNumbers", new[] { "Person_PersonId" });
            AlterColumn("dbo.PhoneNumbers", "Person_PersonId", c => c.Guid());
            CreateIndex("dbo.PhoneNumbers", "Person_PersonId");
            AddForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People", "PersonId");
        }
    }
}
