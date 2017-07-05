using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Dtos
{
    public class RegistrantDto
    {
        public Guid RegistrantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<DivisionDto> Divisions { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
