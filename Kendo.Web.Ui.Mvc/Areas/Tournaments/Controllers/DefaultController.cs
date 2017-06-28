using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Mappers;
using Kendo.Modules.Tournaments.Interfaces.Services;
using Kendo.Web.Ui.Mvc.Areas.Tournaments.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments.Controllers
{
    public class DefaultController : Controller
    {
        private ITournamentService service;

        private ITournamentService Service
        {
            get
            {
                if (service == null)
                {
                    service = Container.Instance.Resolve<ITournamentService>();
                }
                return service;
            }
        }

        public ActionResult Register(Guid id)
        {
            return View();
        }

        public ActionResult GetDetail(Guid id)
        {
            var tournament = Service.GetById(id);
            var model = Mapper.Instance.Map<GetDetailViewModel>(tournament);
            return View(model);
        }

        public ActionResult Index()
        {
            var tournaments = Service.ListAll();
            var model = Mapper.Instance.Map<IndexViewModel>(tournaments);
            return View(model);
        }
    }
}
