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
    public class RegistrationController : Controller
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
            var divisions = Service.ListDivisionsByTournamentId(id)
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.DivisionId.ToString(),
                })
                .ToList();
            divisions.Insert(0, new SelectListItem
            {
                Text = string.Empty,
            });

            var model = new RegisterViewModel
            {
                TournamentId = id,
                Divisions = divisions,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(Guid id, RegisterViewModel model)
        {
            var dto = Mapper.Instance.Map<RegistrationDto>(model);
            var registrationId = Service.Register(dto);

            return RedirectToAction(nameof(Confirm), new { id = registrationId });
        }

        public ActionResult Confirm(Guid id)
        {
            var registration = Service.GetRegistrationById(id);
            var model = Mapper.Instance.Map<ConfirmViewModel>(registration);
            return View(model);
        }

        public ActionResult GetDetail(Guid id)
        {
            var tournament = Service.GetTournamentById(id);
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
