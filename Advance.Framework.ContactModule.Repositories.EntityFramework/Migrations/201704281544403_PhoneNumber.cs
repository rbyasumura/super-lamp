namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneNumber : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People");
            DropIndex("dbo.PhoneNumbers", new[] { "Person_PersonId" });
            DropTable("dbo.PhoneNumbers");
        }
    }
}
