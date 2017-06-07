using Advance.Framework.ContactModule.Entities;
using Advance.Framework.Repositories.EntityFramework;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class PersonRepository : Repository<Person>
        , IPersonRepository
    {
        public PersonRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}