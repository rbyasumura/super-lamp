﻿using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Contacts.Interfaces.Repositories;
using Advance.Framework.Repositories;

namespace Advance.Framework.Modules.Contacts.Repositories
{
    public class PersonRepository : RepositoryBase<Person>
        , IPersonRepository
    {
        public PersonRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
