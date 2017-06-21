using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Contacts.Interfaces.Repositories;
using Advance.Framework.Repositories;

namespace Advance.Framework.Modules.Contacts.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>
            , IContactRepository
    {
        protected ContactRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
