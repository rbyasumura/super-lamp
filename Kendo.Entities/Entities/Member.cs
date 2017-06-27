using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Advance.Framework.Modules.Core.Entities;

namespace Kendo.Entities
{
    public class Member : Person
    {
        [NotMapped]
        public Guid MemberId { get => PersonId; set => PersonId = value; }

        public IList<Club> Clubs { get; set; }

        public ICollection<Rank> Ranks { get; set; }
    }
}
