﻿using Advance.Framework.PersonService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Framework.PersonService.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Entities.Person> ListAll();

        Person GetById(Guid id);

        void Add(Entities.Person person);

        void Update(Entities.Person person);

        void Delete(Entities.Person person);
    }
}
