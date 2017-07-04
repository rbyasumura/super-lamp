using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments.Models
{
    public class ConfirmViewModel
    {
        public string ClubName { get; set; }
        public IList<RegistrantViewModel> Registrants { get; set; }

        public class RegistrantViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DivisionName { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}
