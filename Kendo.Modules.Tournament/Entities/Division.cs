using System;
using System.Linq;

namespace Kendo.Modules.Tournaments.Entities
{
    public class Division
    {
        public Guid DivisionId { get; set; }
        public Tournament Tournament { get; set; }
        public string Name { get; set; }
    }
}
