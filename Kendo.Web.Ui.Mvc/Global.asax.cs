using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Mappers.Interfaces;
using Kendo.Modules.Tournaments;
using Kendo.Web.Ui.Mvc.Areas.Tournaments;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Kendo.Web.Ui.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private IMapper mapper;

        private IMapper Mapper
        {
            get
            {
                if (mapper == null)
                {
                    mapper = Container.Instance.Resolve<IMapper>();
                }
                return mapper;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.RegisterMappingDefinitions(
                new TournamentMappingDefinition(),
                new TournamentsViewModelMappingDefinition(),
                new KendoMappingDefinition());
        }
    }
}
