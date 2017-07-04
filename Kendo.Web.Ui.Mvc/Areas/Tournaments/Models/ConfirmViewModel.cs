using Kendo.Web.Ui.Mvc.Areas.Tournaments.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments.Models
{
    public class ConfirmViewModel
    {
        private static _Actions _actions = new _Actions();

        public _Actions Actions
        {
            get
            {
                return _actions;
            }
        }
        public string ClubName { get; set; }
        public IList<RegistrantViewModel> Registrants { get; set; }
        public Guid RegistrationId { get; set; }

        public class _Actions
        {
            public readonly string Edit = nameof(RegistrationController.Edit);
        }

        public class RegistrantViewModel
        {
            public DateTime DateOfBirth { get; set; }
            public string DivisionName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
