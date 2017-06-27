using Advance.Framework.Modules.Core.Entities;
using Advance.Framework.Modules.Core.Interfaces.Repositories;
using Advance.Framework.Repositories;

namespace Advance.Framework.Modules.Core.Repositories
{
    public class PersonRepository : RepositoryBase<Person>
        , IPersonRepository
    {
        public PersonRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
