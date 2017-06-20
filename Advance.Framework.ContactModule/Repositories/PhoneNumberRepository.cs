using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Contacts.Interfaces.Repositories;
using Advance.Framework.Repositories;

namespace Advance.Framework.Modules.Contacts.Repositories
{
    public class PhoneNumberRepository : Repository<PhoneNumber>
        , IPhoneNumberRepository
    {
        protected PhoneNumberRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
