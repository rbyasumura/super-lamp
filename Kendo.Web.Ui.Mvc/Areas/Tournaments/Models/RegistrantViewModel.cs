using System;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments.Models
{
    public class RegistrantViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid SelectedDivisionId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
