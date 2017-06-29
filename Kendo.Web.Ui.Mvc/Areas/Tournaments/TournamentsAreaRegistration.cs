using Kendo.Web.Ui.Mvc.Areas.Tournaments.Controllers;
using System;
using System.Web.Mvc;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments
{
    public class TournamentsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Tournaments";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Tournaments_default",
                "Tournaments/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, controller = GetControllerName(nameof(RegistrationController)), }
            );
        }

        private static string GetControllerName(string controllerName)
        {
            var _controllerName = controllerName;
            var index = _controllerName.LastIndexOf("Controller", StringComparison.CurrentCultureIgnoreCase);
            return _controllerName.Substring(0, index);
        }
    }
}
