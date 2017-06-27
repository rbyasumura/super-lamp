using Advance.Framework.Modules.Core.Entities;
using System.Data.Entity.Migrations;

namespace Kendo.Contexts.EntityFramework.Migrations
{
    partial class Configuration
    {
        private Configuration SeedCountry(Context context)
        {
            context.Set<Country>().AddOrUpdate(new Country
            {
                CountryId = "CA",
                Name = "Canada",
            });
            context.SaveChanges();

            return this;
        }
    }
}
