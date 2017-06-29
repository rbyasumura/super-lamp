using Advance.Framework.Repositories;
using Kendo.Entities;
using Kendo.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Repositories
{
    public class RegistrantRepository : RepositoryBase<Registrant>
            , IRegistrantRepository
    {
        public RegistrantRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
