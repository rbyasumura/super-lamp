using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Contacts.Interfaces.Repositories;
using Advance.Framework.Repositories;

namespace Advance.Framework.Modules.Contacts.Repositories
{
    public class PersonRepository : Repository<Person>
        , IPersonRepository
    {
        public PersonRepository(UnitOfWorkBase unitOfWork) : base(unitOfWork)
        {
        }
    }
}
