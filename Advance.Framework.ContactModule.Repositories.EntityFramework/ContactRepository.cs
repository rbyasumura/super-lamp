using Advance.Framework.ContactModule.Entities;
using Advance.Framework.Repositories.EntityFramework;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class ContactRepository : Repository<Contact>
        , IContactRepository
    {
        public ContactRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}