using Advance.Framework.Repositories;
using Kendo.Entities;
using Kendo.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Repositories
{
    public class ClubRepository : RepositoryBase<Club>
        , IClubRepository
    {
        public ClubRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
