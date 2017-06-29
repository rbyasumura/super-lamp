using Kendo.Web.Ui.Mvc.Areas.Tournaments.Controllers;
using System;
using System.Linq;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments.Models
{
    public class GetDetailViewModel
    {
        private static _Actions _actions = new _Actions();

        public _Actions Actions
        {
            get
            {
                return _actions;
            }
        }

        public Guid TournamentId { get; set; }

        public class _Actions
        {
            public readonly string Register = nameof(RegistrationController.Register);
        }
    }
}
