using System.Data.Entity.Migrations;

namespace Kendo.Contexts.EntityFramework.Migrations
{
    internal sealed partial class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            SeedCountry(context)
                .SeedState(context);
        }
    }
}
