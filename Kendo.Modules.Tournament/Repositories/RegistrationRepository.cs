using Advance.Framework.Repositories;
using Kendo.Modules.Tournaments.Entities;
using Kendo.Modules.Tournaments.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Repositories
{
    public class RegistrationRepository : RepositoryBase<Registration>
            , IRegistrationRepository
    {
        public RegistrationRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
