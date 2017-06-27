using Advance.Framework.Modules.Core.Entities;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Kendo.Contexts.EntityFramework.Migrations
{
    partial class Configuration
    {
        private Configuration SeedState(Context context)
        {
            var canada = context.Set<Country>().Single(i => i.CountryId == "CA");
            context.Set<State>().AddOrUpdate(
                new State
                {
                    StateId = "CA-BC",
                    Country = canada,
                    Code = "BC",
                    Name = "British Columbia",
                },
                new State
                {
                    StateId = "CA-AB",
                    Country = canada,
                    Code = "AB",
                    Name = "Alberta",
                },
                new State
                {
                    StateId = "CA-SK",
                    Country = canada,
                    Code = "SK",
                    Name = "Saskatchewan",
                },
                new State
                {
                    StateId = "CA-MB",
                    Country = canada,
                    Code = "MB",
                    Name = "Manitoba",
                },
                new State
                {
                    StateId = "CA-ON",
                    Country = canada,
                    Code = "ON",
                    Name = "Ontario",
                },
                new State
                {
                    StateId = "CA-QC",
                    Country = canada,
                    Code = "QC",
                    Name = "Quebec",
                },
                new State
                {
                    StateId = "CA-NB",
                    Country = canada,
                    Code = "NB",
                    Name = "New Brunswick",
                },
                new State
                {
                    StateId = "CA-NS",
                    Country = canada,
                    Code = "NS",
                    Name = "Nova Scotia",
                },
                new State
                {
                    StateId = "CA-NL",
                    Country = canada,
                    Code = "NL",
                    Name = "Newfoundland and Labrador",
                },
                new State
                {
                    StateId = "CA-PE",
                    Country = canada,
                    Code = "PE",
                    Name = "Prince Edward Island",
                },
                new State
                {
                    StateId = "CA-YK",
                    Country = canada,
                    Code = "YK",
                    Name = "Yukon",
                },
                new State
                {
                    StateId = "CA-NT",
                    Country = canada,
                    Code = "NT",
                    Name = "Northwest Territories",
                },
                new State
                {
                    StateId = "CA-NU",
                    Country = canada,
                    Code = "NU",
                    Name = "Nunavut",
                });

            return this;
        }
    }
}
