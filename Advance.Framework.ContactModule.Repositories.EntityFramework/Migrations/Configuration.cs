using System.Data.Entity.Migrations;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ContactModuleContext>
    {
        #region Public Constructors

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void Seed(ContactModuleContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method to avoid creating
            // duplicate seed data. E.g.
            //
            // context.People.AddOrUpdate( p => p.FullName, new Person { FullName = "Andrew Peters"
            // }, new Person { FullName = "Brice Lambson" }, new Person { FullName = "Rowan Miller" } );
        }

        #endregion Protected Methods
    }
}