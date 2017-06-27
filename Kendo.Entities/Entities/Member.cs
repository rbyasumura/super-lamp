using System.Collections.Generic;
using Advance.Framework.Modules.Core.Entities;

namespace Kendo.Entities
{
    public class Member : Person
    {
        public IList<Club> Clubs { get; set; }

        public ICollection<Rank> Ranks { get; set; }
    }
}
