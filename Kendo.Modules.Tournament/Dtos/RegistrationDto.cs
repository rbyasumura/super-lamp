using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Dtos
{
    public class RegistrationDto
    {
        public IEnumerable<RegistrantDto> Registrants { get; set; }
    }
}
