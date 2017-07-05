using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments.Models
{
    public class _RegistrationViewModel
    {
        public Guid ClubId { get; set; }
        public IList<RegistrantViewModel> Registrants { get; set; }
        public Guid TournamentId { get; set; }

        public class RegistrantViewModel
        {
            public DateTime? DateOfBirth { get; set; }
            public string FirstName { get; set; }
            public Guid RegistrantId { get; set; }
            public string LastName { get; set; }
            public IList<Guid> SelectedDivisionIds { get; set; }
            public IEnumerable<SelectListItem> Divisions { get; set; }
        }
    }
}
