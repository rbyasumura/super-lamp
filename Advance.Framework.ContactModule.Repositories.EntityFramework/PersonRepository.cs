using Advance.Framework.ContactModule.Entities;

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
