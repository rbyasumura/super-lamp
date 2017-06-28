using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Mappers;
using Kendo.Modules.Tournaments.Dtos;
using Kendo.Modules.Tournaments.Interfaces.Services;
using Kendo.Web.Ui.Mvc.Areas.Tournaments.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            var service = Container.Instance.Resolve<ITournamentService>();
            var tournaments = service.ListAll();
            var model = Mapper.Instance.Map<TournamentDto, IndexViewModel>(tournaments);
            return View(model);
        }
    }
}
