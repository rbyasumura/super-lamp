namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class removecascadedelete : DbMigration
    {
        #region Public Methods

        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People");
            AddForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People", "PersonId", cascadeDelete: true);
        }

        public override void Up()
        {
            DropForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People");
            AddForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People", "PersonId");
        }

        #endregion Public Methods
    }
}