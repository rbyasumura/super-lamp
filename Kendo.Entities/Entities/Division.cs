using System;
using System.Linq;

namespace Kendo.Entities
{
    public class Division
    {
        public Guid DivisionId { get; set; }
        public Tournament Tournament { get; set; }
        public string Name { get; set; }
    }
}
