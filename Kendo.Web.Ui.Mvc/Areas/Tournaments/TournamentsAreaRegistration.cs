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
                new { action = "Index", id = UrlParameter.Optional, controller = "Default", }
            );
        }
    }
}
