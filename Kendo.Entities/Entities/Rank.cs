using System;
using Kendo.Entities.Enums;

using System;

namespace Kendo.Entities
{
    public class Rank
    {
        public Guid RankId { get; set; }
        public int RankNumber { get; set; }
        public RankType Type { get; set; }
        public Title Title { get; set; }
        public Discipline Discipline { get; set; }
        public DateTime? ObtainedAt { get; set; }
    }
}
