using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments.Models
{
    public class RegisterViewModel
    {
        public Guid ClubId { get; set; }
        public IList<RegistrantViewModel> Registrants { get; set; }
        public IEnumerable<SelectListItem> Divisions { get; set; }
    }
}
