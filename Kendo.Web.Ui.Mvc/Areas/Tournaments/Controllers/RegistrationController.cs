using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Mappers;
using Kendo.Modules.Tournaments.Dtos;
using Kendo.Modules.Tournaments.Interfaces.Services;
using Kendo.Web.Ui.Mvc.Areas.Tournaments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments.Controllers
{
    public class RegistrationController : Controller
    {
        private const int MAX_REGISTRANT_COUNT = 20;
        private IEnumerable<DivisionDto> divisions;
        private ITournamentService service;

        private IEnumerable<DivisionDto> Divisions
        {
            get
            {
                if (divisions == null)
                {
                    divisions = Service.ListDivisionsByTournamentId(TournamentId);
                }
                return divisions;
            }
        }
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
        private Guid TournamentId { get; set; }

        public ActionResult Confirm(Guid id)
        {
            var registration = Service.GetRegistrationById(id);
            var model = Mapper.Instance.Map<ConfirmViewModel>(registration);

            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            var registration = Service.GetRegistrationById(id);
            TournamentId = registration.TournamentId;

            var model = Mapper.Instance.Map<EditViewModel>(registration);
            var divisions = ListDivisionsSelectListItems();
            for (var i = 0; i < MAX_REGISTRANT_COUNT; i++)
            {
                if (i < model.Registration.Registrants.Count)
                {
                    var registrant = model.Registration.Registrants[i];
                    registrant.Divisions = ListDivisionsSelectListItems(registrant.SelectedDivisionIds.Single());
                }
                else
                {
                    model.Registration.Registrants.Add(new _RegistrationViewModel.RegistrantViewModel
                    {
                        Divisions = divisions,
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, EditViewModel model)
        {
            throw new NotImplementedException();
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

        public ActionResult Register(Guid id)
        {
            TournamentId = id;
            var registration = new _RegistrationViewModel
            {
                TournamentId = id,
            };

            var divisions = ListDivisionsSelectListItems();
            for (var i = 0; i < MAX_REGISTRANT_COUNT; i++)
            {
                registration.Registrants.Add(new _RegistrationViewModel.RegistrantViewModel
                {
                    Divisions = divisions,
                });
            }

            var model = new RegisterViewModel
            {
                Registration = registration,
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

        private IEnumerable<SelectListItem> ListDivisionsSelectListItems(Guid? selectedDivisionId = null)
        {
            var divisions = Divisions
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.DivisionId.ToString(),
                    Selected = i.DivisionId == selectedDivisionId,
                })
                .ToList();
            divisions.Insert(0, new SelectListItem
            {
                Text = string.Empty,
            });
            return divisions;
        }
    }
}
